using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DataAccessLayer.Models
{
    public partial class TwitterDBContext : DbContext
    {
        public TwitterDBContext()
        {
        }

        public TwitterDBContext(DbContextOptions<TwitterDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chat> Chat { get; set; }
        public virtual DbSet<ChatMessages> ChatMessages { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<CommentLike> CommentLike { get; set; }
        public virtual DbSet<Follower> Follower { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<Like> Like { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<Resource> Resource { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-CE13F80;Initial Catalog=TwitterDB;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chat>(entity =>
            {
                entity.Property(e => e.ChatId).HasColumnName("chatId");

                entity.Property(e => e.LastMessage).HasColumnName("lastMessage");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("lastUpdate")
                    .HasColumnType("date");

                entity.Property(e => e.User1).HasColumnName("user1");

                entity.Property(e => e.User2).HasColumnName("user2");

                entity.HasOne(d => d.LastMessageNavigation)
                    .WithMany(p => p.Chat)
                    .HasForeignKey(d => d.LastMessage)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Chat_ChatMessages");

                entity.HasOne(d => d.User1Navigation)
                    .WithMany(p => p.ChatUser1Navigation)
                    .HasForeignKey(d => d.User1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Chat_User");

                entity.HasOne(d => d.User2Navigation)
                    .WithMany(p => p.ChatUser2Navigation)
                    .HasForeignKey(d => d.User2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Chat_User1");
            });

            modelBuilder.Entity<ChatMessages>(entity =>
            {
                entity.HasKey(e => e.MessageId);

                entity.Property(e => e.MessageId).HasColumnName("messageId");

                entity.Property(e => e.DateTime)
                    .HasColumnName("dateTime")
                    .HasColumnType("date");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasColumnName("message")
                    .HasColumnType("text");

                entity.Property(e => e.Receiver).HasColumnName("receiver");

                entity.Property(e => e.Sender).HasColumnName("sender");

                entity.HasOne(d => d.ReceiverNavigation)
                    .WithMany(p => p.ChatMessagesReceiverNavigation)
                    .HasForeignKey(d => d.Receiver)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChatMessages_User1");

                entity.HasOne(d => d.SenderNavigation)
                    .WithMany(p => p.ChatMessagesSenderNavigation)
                    .HasForeignKey(d => d.Sender)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChatMessages_User");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.CommentId).HasColumnName("commentId");

                entity.Property(e => e.Comment1)
                    .IsRequired()
                    .HasColumnName("comment")
                    .HasColumnType("text");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.LikeCount).HasColumnName("likeCount");

                entity.Property(e => e.PostId).HasColumnName("postId");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comment_Post");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comment_User");
            });

            modelBuilder.Entity<CommentLike>(entity =>
            {
                entity.Property(e => e.CommentLikeId).HasColumnName("commentLikeId");

                entity.Property(e => e.CommentId).HasColumnName("commentId");

                entity.Property(e => e.LikedBy).HasColumnName("likedBy");

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.CommentLike)
                    .HasForeignKey(d => d.CommentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CommentLike_Comment");

                entity.HasOne(d => d.LikedByNavigation)
                    .WithMany(p => p.CommentLike)
                    .HasForeignKey(d => d.LikedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CommentLike_User");
            });

            modelBuilder.Entity<Follower>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FollowedBy).HasColumnName("followedBy");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.FollowedByNavigation)
                    .WithMany(p => p.FollowerFollowedByNavigation)
                    .HasForeignKey(d => d.FollowedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Follower_User1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FollowerUser)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Follower_User");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.Property(e => e.LanguageId).ValueGeneratedNever();

                entity.Property(e => e.Language1)
                    .IsRequired()
                    .HasColumnName("Language")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Like>(entity =>
            {
                entity.Property(e => e.LikeId).HasColumnName("likeId");

                entity.Property(e => e.LikedBy).HasColumnName("likedBy");

                entity.Property(e => e.PostId).HasColumnName("postId");

                entity.HasOne(d => d.LikedByNavigation)
                    .WithMany(p => p.Like)
                    .HasForeignKey(d => d.LikedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Likes_User");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Like)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Likes_Post");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.Property(e => e.PostId).HasColumnName("postId");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text");

                entity.Property(e => e.FilePath)
                    .HasColumnName("filePath")
                    .HasColumnType("text");

                entity.Property(e => e.Likes).HasColumnName("likes");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Post)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Post_User");
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.Property(e => e.Message).HasColumnType("text");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.Resource)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Resources_Language");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.Image)
                    .HasColumnName("image")
                    .HasColumnType("text");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
