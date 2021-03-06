﻿using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using EmailPingPong.Core.Model;

namespace EmailPingPong.Infrastructure.Repositories
{
	public class ConversationContext : DbContext
	{
		public ConversationContext(IConnectionStringProvider connectionStringProvider)
			: base(connectionStringProvider.ConnectionString)
		{
			Configuration.LazyLoadingEnabled = false;
		}

		public DbSet<Comment> Comments { get; set; }

		public DbSet<EmailItem> EmailItems { get; set; }

		public DbSet<Conversation> Conversations { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			MapConversation(modelBuilder);
			MapComment(modelBuilder);
			MapEmailItem(modelBuilder);
		}

		private static void MapEmailItem(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<EmailItem>()
			            .HasKey(m => m.Id);
			modelBuilder.Entity<EmailItem>()
			            .Property(c => c.Id)
			            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			modelBuilder.Entity<Comment>()
			.HasOptional(c => c.OriginalEmail);
		}

		private static void MapComment(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Comment>()
			            .HasKey(c => c.Id);
			modelBuilder.Entity<Comment>()
			            .Property(c => c.Id)
			            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			modelBuilder.Entity<Comment>()
			            .HasMany(c => c.Answers)
			            .WithOptional(c => c.Parent)
			            .Map(c => c.MapKey("ParentId"));
		}

		private static void MapConversation(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Conversation>()
			            .HasKey(c => c.Id);
			modelBuilder.Entity<Conversation>()
			            .Property(c => c.Id)
			            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			modelBuilder.Entity<Conversation>()
			            .HasMany(c => c.Emails)
			            .WithRequired()
			            .WillCascadeOnDelete(true);

			modelBuilder.Entity<Conversation>()
			            .HasMany(c => c.Comments)
			            .WithOptional(c => c.Conversation)
						.Map(c => c.MapKey("ConversationId"))
			            .WillCascadeOnDelete(true);
		}
	}
}