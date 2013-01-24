﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using EmailPingPong.Core.Model;
using EmailPingPong.Core.Utils;

namespace EmailPingPong.UI.Desktop.ViewModels
{
	public class CommentViewModel : TreeViewItemViewModel
	{
		private readonly Comment _comment;
		private readonly ReadOnlyCollection<CommentViewModel> _answers;

		public CommentViewModel(TreeViewItemViewModel parent,
								Comment comment)
			: base(parent)
		{
			_comment = comment;
			_answers = new ReadOnlyCollection<CommentViewModel>(comment
																	.Answers
																	.Select(a => new CommentViewModel(this, a))
																	.ToList());
			IsUnread = comment.With(c => c.OriginalEmail).Return(e => e.IsUnread);
		}

		public override IEnumerable<TreeViewItemViewModel> Childs
		{
			get
			{
				return _answers;
			}
		}

		public string Author
		{
			get { return _comment.Author; }
		}

		public string Body
		{
			get { return _comment.Body; }
		}

		public DateTime CreatedOn
		{
			get { return _comment.CreatedOn; }
		}

		public ReadOnlyCollection<CommentViewModel> Answers
		{
			get { return _answers; }
		}

		public Comment Comment
		{
			get { return _comment; }
		}

		public override int GetHashCode()
		{
			return _comment.GetHashCode();
		}

		public override bool Equals(object other)
		{
			if (ReferenceEquals(this, other))
			{
				return true;
			}

			if ((other == null) || !(other is CommentViewModel))
			{
				return false;
			}

			var thisType = GetType();
			var otherType = other.GetType();

			if (thisType != otherType)
			{
				return false;
			}

			return Comment == (other as CommentViewModel).Comment;
		}
	}
}