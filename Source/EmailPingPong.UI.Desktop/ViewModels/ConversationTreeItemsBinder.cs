﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmailPingPong.Core.Model;
using EmailPingPong.Core.Repositories;

namespace EmailPingPong.UI.Desktop.ViewModels
{
	public interface IConversationTreeItemsBinder
	{
		Task<IList<TreeViewItemViewModel>> BindTreeViewItems(ConversationViewCriteria criteria);
	}

	public class ConversationTreeItemsBinder : IConversationTreeItemsBinder
	{
		private readonly IConversationRepository _conversationRepository;

		public ConversationTreeItemsBinder(IConversationRepository conversationRepository)
		{
			_conversationRepository = conversationRepository;
		}

		public async Task<IList<TreeViewItemViewModel>> BindTreeViewItems(ConversationViewCriteria criteria)
		{
			var conversations = await GetConversationsInScope(criteria);
			IList<TreeViewItemViewModel> treeViewItems;
			switch (criteria.GroupBy)
			{
				case GroupBy.Email:
					treeViewItems = BindByEmail(conversations);
					break;
				case GroupBy.Folder:
					treeViewItems = BindByFolder(conversations);
					break;
				default:
					treeViewItems = BindByDefault(conversations);
					break;
			}
			return treeViewItems;
		}

		private IList<TreeViewItemViewModel> BindByFolder(IEnumerable<Conversation> conversations)
		{
			return conversations
				.Select(c => new FolderViewModel(null, c))
				.Cast<TreeViewItemViewModel>()
				.ToList();
		}

		private IList<TreeViewItemViewModel> BindByEmail(IEnumerable<Conversation> conversations)
		{
			return conversations
				.Select(c => new ConversationViewModel(null, c))
				.Cast<TreeViewItemViewModel>()
				.ToList();
		}

		private IList<TreeViewItemViewModel> BindByDefault(IEnumerable<Conversation> conversations)
		{
			var comments = conversations.SelectMany(c => c.Comments);
			return comments.Select(c => new CommentViewModel(null, c))
						   .Cast<TreeViewItemViewModel>()
						   .ToList();
		}

		private Task<List<Conversation>> GetConversationsInScope(ConversationViewCriteria criteria)
		{
			switch (criteria.SearchIn)
			{
				case SearchIn.AllFolders:
					return Task.Factory.StartNew(() => _conversationRepository.GetByAccountId(criteria.AccountId).ToList());
				case SearchIn.CurrentFolder:
					return Task.Factory.StartNew(() => _conversationRepository.GetByAccountIdAndFolders(criteria.AccountId, criteria.Folders).ToList());
				case SearchIn.CurrentEmail:
					return Task.Factory.StartNew(() => _conversationRepository.GetByAccountIdAndEmails(criteria.AccountId, criteria.Emails).ToList());
				default:
					throw new NotSupportedException(string.Format("Search filter '{0}' is not supported.", criteria.SearchIn.ToString()));
			}
		}
	}
}