﻿using EmailPingPong.Core.Model;
using Microsoft.Practices.Prism.Events;

namespace EmailPingPong.Infrastructure.Events
{
	public class EmailItemChangedEvent : CompositePresentationEvent<EmailItemChangedArgs>
	{
	}

	public class EmailItemChangedArgs
	{
		public EmailItemChangedArgs(EmailItem emailItem)
		{
			EmailItem = emailItem;
		}

		public EmailItem EmailItem { get; private set; }
	}
}