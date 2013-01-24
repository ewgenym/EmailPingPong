﻿using Microsoft.Office.Interop.Word;

namespace EmailPingPong.Outlook.Common.Word.Utils
{
	public static class ContentControlExtensions
	{
		public static bool IsPingPong(this ContentControl control)
		{
			return control.IsPing() || control.IsPong();
		}

		public static bool IsPing(this ContentControl control)
		{
			return control.IsOfTag("ping");
		}

		public static bool IsPong(this ContentControl control)
		{
			return control.IsOfTag("pong");
		}

		public static bool IsAuthor(this ContentControl control)
		{
			return control.IsOfTag("author");
		}

		private static bool IsOfTag(this ContentControl control, string tag)
		{
			return control != null && control.Tag.StartsWith(tag);
		}

		public static string ConversationId(this ContentControl control)
		{
			var parts = control.Tag.Split(';');
			if (parts.Length >= 2)
			{
				return parts[2];
			}

			return null;
		}
	}
}