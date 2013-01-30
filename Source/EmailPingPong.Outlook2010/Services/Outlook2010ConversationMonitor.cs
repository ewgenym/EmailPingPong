﻿using System.Collections.Generic;
using System.Runtime.InteropServices;
using EmailPingPong.Core.Commands;
using EmailPingPong.Infrastructure;
using EmailPingPong.Infrastructure.Events;
using EmailPingPong.Infrastructure.Repositories;
using EmailPingPong.Outlook.Common.Conversation.Implementation;
using Microsoft.Office.Interop.Outlook;
using Microsoft.Practices.Prism.Events;

namespace EmailPingPong.Outlook2010.Services
{
	public class Outlook2010ConversationMonitor : ConversationMonitorBase
	{
		private readonly ConversationContext _context;
		private readonly ICommandDispatcher _commands;
		private Dictionary<Folder, Items> _folderItems;
		private readonly IConversationBinder _conversationBinder;
		private readonly IEventAggregator _eventAggregator;
		private Explorer _explorer;
		private MailItem _selectedItem;
		private readonly IFolderBinder _folderBinder;
		private readonly IConversationMetadataTracker _conversationMetadataTracker;

		public Outlook2010ConversationMonitor(ConversationContext context,
											  ICommandDispatcher commands,
											  IConversationBinder conversationBinder,
											  IEventAggregator eventAggregator,
											  IFolderBinder folderBinder, IConversationMetadataTracker conversationMetadataTracker)
		{
			_context = context;
			_commands = commands;
			_conversationBinder = conversationBinder;
			_eventAggregator = eventAggregator;
			_folderBinder = folderBinder;
			_conversationMetadataTracker = conversationMetadataTracker;
		}

		public override void StartWatch()
		{
			_explorer = Globals.ThisAddIn.Application.ActiveExplorer();
			_explorer.FolderSwitch += OnFolderSwitch;
			_explorer.SelectionChange += OnSelectionChange;

			foreach (Account account in Globals.ThisAddIn.Application.Session.Accounts)
			{
				var store = account.DeliveryStore;
				if (!store.IsOpen)
				{
					continue;
				}

				// New email received or moved from another folder
				var inbox = (Folder)store.GetDefaultFolder(OlDefaultFolders.olFolderInbox);
				WatchFolderHierarchy(inbox);

				// Email was saved to draft folder
				var draft = (Folder)store.GetDefaultFolder(OlDefaultFolders.olFolderDrafts);
				WatchFolder(draft);

				// -New e-mail is sent. When there is no connection with server as well. (Two options here: 1) monitor Sent folder 2) monitor Application.ItemSend event)
				var sent = (Folder)store.GetDefaultFolder(OlDefaultFolders.olFolderSentMail);
				WatchFolder(sent);
			}

			SetupWatch();

			// -New e-mail is sent. When there is no connection with server as well. (Two options here: 1) monitor Sent folder 2) monitor Application.ItemSend event)
			//var sent = this.Application.Session.GetDefaultFolder(OlDefaultFolders.olFolderSentMail);
			//_sentItems = sent.Items;
			//_sentItems.ItemAdd += SyncConversation;
		}

		private void WatchFolder(Folder folder)
		{
			if (_folderItems == null)
			{
				_folderItems = new Dictionary<Folder, Items>();
			}

			_folderItems.Add(folder, folder.Items);
		}

		private void WatchFolderHierarchy(Folder root)
		{
			if (root.DefaultItemType == OlItemType.olMailItem)
			{
				WatchFolder(root);

				if (root.Folders.Count <= 0)
				{
					return;
				}

				foreach (Folder folder in root.Folders)
				{
					WatchFolderHierarchy(folder);
				}
			}
		}

		private void SetupWatch()
		{
			foreach (var folderItem in _folderItems)
			{
				var folder = folderItem.Key;
				var items = folderItem.Value;

				items.ItemAdd += OnMailItemAdded;
				items.ItemChange += OnMailItemChanged;

				folder.BeforeItemMove += MailItemRemoved;
			}
		}

		private void OnMailItemAdded(object item)
		{
			var conversation = _conversationBinder.Bind((MailItem)item);
			if (conversation == null)
			{
				return;
			}

			using (new UnitOfWork(_context))
			{
				_commands.Dispatch(new MergeConversation(conversation));
			}
			_eventAggregator.GetEvent<ConversationMergedEvent>().Publish(conversation);
		}

		private void OnMailItemChanged(object item)
		{
			var mailItem = item as MailItem;
			if (mailItem == null)
			{
				return;
			}

			var conversation = _conversationBinder.Bind(mailItem);
			if (conversation == null)
			{
				return;
			}

			using (new UnitOfWork(_context))
			{
				_commands.Dispatch(new UpdateMailItem(conversation));
			}
			_eventAggregator.GetEvent<ConversationRemovedEvent>().Publish(new ConversationRemovedArgs(conversation));
		}

		private void MailItemRemoved(object item, MAPIFolder to, ref bool cancel)
		{
			var mailItem = item as MailItem;
			if (mailItem == null)
			{
				return;
			}

			var conversation = _conversationBinder.Bind(mailItem);
			if (conversation == null)
			{
				return;
			}

			using (new UnitOfWork(_context))
			{
				_commands.Dispatch(new RemoveConversation(conversation));
			}
			_eventAggregator.GetEvent<EmailItemChangedEvent>().Publish(new EmailItemChangedArgs(conversation.NewestEmail));
		}

		private void OnFolderSwitch()
		{
			var folder = (Folder) _explorer.CurrentFolder;
			_eventAggregator.GetEvent<MailFolderSwitchedEvent>().Publish(new MailFolderSwitchedArgs(folder.Store.DisplayName, _folderBinder.Bind(folder)));
		}

		private void OnSelectionChange()
		{
			HandlePreserveAttachment();
		}

		private void HandlePreserveAttachment()
		{
			if (_selectedItem != null)
			{
				Marshal.ReleaseComObject(_selectedItem);
				_selectedItem = null;
			}

			if (_explorer.Selection.Count > 0)
			{
				_selectedItem = (MailItem)_explorer.Selection[1];
				if (_conversationMetadataTracker.TracksConversation(_selectedItem))
				{
					((ItemEvents_10_Event) _selectedItem).Reply += OnMailItemReply;
					((ItemEvents_10_Event)_selectedItem).ReplyAll += OnMailItemReply;
				}
			}
		}

		private void OnMailItemReply(object response, ref bool cancel)
		{
			var responseItem = (MailItem)response;
			_conversationMetadataTracker.PreserveMetadata(_selectedItem, responseItem);
			Marshal.ReleaseComObject(responseItem);
		}

		public override void StopWatch()
		{
			if (_selectedItem != null)
			{
				Marshal.ReleaseComObject(_selectedItem);
			}

			foreach (var item in _folderItems)
			{
				Marshal.ReleaseComObject(item.Key);
			}
			_folderItems.Clear();
		}
	}
}