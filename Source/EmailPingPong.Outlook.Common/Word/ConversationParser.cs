﻿using System;
using EmailPingPong.Outlook.Common.Word.Utils;
using Microsoft.Office.Interop.Word;
using Comment = EmailPingPong.Core.Model.Comment;

namespace EmailPingPong.Outlook.Common.Word
{
	//TODO: how the fuck unit test this code?
	public class ConversationParser : IConversationParser
	{
		public void Parse(Document document, Core.Model.Conversation conversation)
		{
			//var questions = new List<Comment>();
			Comment lastQuestion = null;

			int i = 0;
			foreach (ContentControl control in document.ContentControls)
			{
				if (control.IsPingPong())
				{
					Comment comment = null;

					var creationDate = DateTime.Now;
					var metadata = control.Tag.Split(';');
					if (metadata.Length > 1)
					{
						creationDate = DateTime.Parse(metadata[1]).ToLocalTime();
					}

					if (control.IsPing())
					{
						var question = new Comment
						               	{
											Id = long.Parse(control.ID),
						               		Body = control.Range.Text,
											CreatedOn = creationDate,
						               	};

						conversation.AddComment(question);
						lastQuestion = question;
						comment = question;
					}


					if (control.IsPong())
					{
						comment = new Comment
						          	{
						          		Id = long.Parse(control.ID),
						          		Body = control.Range.Text,
										CreatedOn = creationDate,
						          	};

						if (lastQuestion != null)
						{
							lastQuestion.AddAnswer(comment);
						}
					}

					if (comment != null)
					{
						foreach (ContentControl nestedControl in control.Range.ContentControls)
						{
							if (nestedControl.IsAuthor())
							{
								comment.Author = nestedControl.Range.Text.Trim('[', ']', ' ', ':');
								var authorLessRange = document.Range(nestedControl.Range.End, control.Range.End);
								comment.Body = authorLessRange.Text;
							}
						}

						comment.Index = i;
					}
				}
				i++;
			}
		}
	}

	public interface IConversationParser
	{
		void Parse(Document document, EmailPingPong.Core.Model.Conversation conversation);
	}
}