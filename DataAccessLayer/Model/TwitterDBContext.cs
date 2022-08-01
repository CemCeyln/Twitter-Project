using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DataAccessLayer.Model
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

        public virtual DbSet<Follower> Follower { get; set; }
        public virtual DbSet<Language> Language { get; set; }
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
