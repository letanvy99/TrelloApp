using Microsoft.EntityFrameworkCore;
using Trello.Domain.Entities;

#nullable disable

namespace Trello.Infrastructure
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<CardLabel> CardLabels { get; set; }
        public virtual DbSet<CardUser> CardUsers { get; set; }
        public virtual DbSet<CheckList> CheckLists { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Label> Labels { get; set; }
        public virtual DbSet<List> Lists { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<Workspace> Workspaces { get; set; }
        public virtual DbSet<WorkspaceUser> WorkspaceUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=Trello;Trusted_Connection=true;MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Card>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.ImageUrl).HasMaxLength(200);

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.Priority).HasMaxLength(100);

                entity.HasOne(d => d.List)
                    .WithMany(p => p.Cards)
                    .HasForeignKey(d => d.ListId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cards_Lists");
            });

            modelBuilder.Entity<CardLabel>(entity =>
            {
                entity.HasKey(e => new { e.CardId, e.LabelId });

                entity.HasOne(d => d.Card)
                    .WithMany(p => p.CardLabels)
                    .HasForeignKey(d => d.CardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CardLabels_Cards");

                entity.HasOne(d => d.Label)
                    .WithMany(p => p.CardLabels)
                    .HasForeignKey(d => d.LabelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CardLabels_Labels");
            });

            modelBuilder.Entity<CardUser>(entity =>
            {
                entity.HasKey(e => new { e.CardId, e.UserId });

                entity.HasOne(d => d.Card)
                    .WithMany(p => p.CardUsers)
                    .HasForeignKey(d => d.CardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CardUsers_Cards");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CardUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CardUsers_Users");
            });

            modelBuilder.Entity<CheckList>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.HasOne(d => d.Card)
                    .WithMany(p => p.CheckLists)
                    .HasForeignKey(d => d.CardId)
                    .HasConstraintName("FK_CheckLists_Cards");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.CheckList)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.CheckListId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Items_Cards");
            });

            modelBuilder.Entity<Label>(entity =>
            {
                entity.Property(e => e.Color).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.Workspace)
                    .WithMany(p => p.Labels)
                    .HasForeignKey(d => d.WorkspaceId)
                    .HasConstraintName("FK_Labels_Workspaces");
            });

            modelBuilder.Entity<List>(entity =>
            {
                entity.Property(e => e.Color).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.Workspace)
                    .WithMany(p => p.Lists)
                    .HasForeignKey(d => d.WorkspaceId)
                    .HasConstraintName("FK_Lists_Workspaces");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Birthday).HasPrecision(0);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.Gender).HasMaxLength(10);

                entity.Property(e => e.ImageUrl).HasMaxLength(200);

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.PasswordHash).HasMaxLength(255);

                entity.Property(e => e.UserName).HasMaxLength(100);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRoles_Roles");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRoles_Users");
            });

            modelBuilder.Entity<Workspace>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.ImageUrl).HasMaxLength(200);

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<WorkspaceUser>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.WorkspaceId });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.WorkspaceUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkspaceUsers_Users");

                entity.HasOne(d => d.Workspace)
                    .WithMany(p => p.WorkspaceUsers)
                    .HasForeignKey(d => d.WorkspaceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkspaceUsers_Workspaces");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
