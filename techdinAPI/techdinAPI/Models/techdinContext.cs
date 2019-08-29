using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TechdinAPI.Models
{
    public partial class techdinContext : IdentityDbContext<User>
    {
        //public techdinContext() {}
        public techdinContext(DbContextOptions<techdinContext> options) : base(options) { }


        public virtual DbSet<BlogPost> BlogPosts { get; set; }
        public virtual DbSet<Cohort> Cohort { get; set; }
        public virtual DbSet<Education> Education { get; set; }
        public virtual DbSet<UserInterests> UserInterests { get; set; }
        public virtual DbSet<NewsFeed> NewsFeed { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<OrganizationUser> OrganizationUser { get; set; }
        public virtual DbSet<ProfileAttachment> ProfileAttachments { get; set; }
        public virtual DbSet<ProjectAttachment> ProjectAttachments { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectUser> ProjectUser { get; set; }
        //public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<WorkExperience> WorkExperience { get; set; }
        public virtual DbSet<Invitation> Invitations { get; set; }

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=techdin;Integrated Security=True;");
        //            }
        //        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BlogPost>(entity =>
            {
                entity.HasKey(e => e.PostId);

                entity.Property(e => e.PostId)
                    .HasColumnName("PostID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Content)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Subject)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserName).HasColumnName("UserName");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BlogPosts)
                    .HasForeignKey(d => d.UserName);
            });

            modelBuilder.Entity<Cohort>(entity =>
            {
                entity.HasKey(e => e.CohortId);

                entity.Property(e => e.CohortId)
                    .HasColumnName("CohortID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Language)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Semester)
                    .HasMaxLength(20)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .HasDefaultValue(true);

            });

            modelBuilder.Entity<Education>(entity =>
            {
                entity.HasKey(e => e.EduId);

                entity.Property(e => e.EduId)
                    .HasColumnName("EduID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ActivitiesSocieties)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Degree)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.FieldOfStudy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Grade)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OrganizationId).HasColumnName("OrganizationID");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.UserName).HasColumnName("UserName");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.Education)
                    .HasForeignKey(d => d.OrganizationId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Education)
                    .HasForeignKey(d => d.UserName);
            });

            modelBuilder.Entity<UserInterests>(entity =>
            {
                entity.HasKey(e => new { e.UserName, e.InterestName });

                entity.Property(e => e.UserName).HasColumnName("UserName");

                entity.Property(e => e.InterestName).HasColumnName("InterestName");

                entity.HasOne<User>(d => d.User)
                    .WithMany(p => p.UserInterests)
                    .HasForeignKey(d => d.UserName)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne<User>(d => d.Interest)
                    .WithMany()
                    .HasForeignKey(d => d.InterestName)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });


            modelBuilder.Entity<NewsFeed>(entity =>
            {
                entity.HasKey(e => e.ChangeId);

                entity.Property(e => e.ChangeId)
                    .HasColumnName("ChangeID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ChangeDate).HasColumnType("datetime");

                entity.Property(e => e.ChangeType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName).HasColumnName("UserName");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.NewsFeed)
                    .HasForeignKey(d => d.UserName);
            });

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.HasKey(e => e.OrganizationId);

                entity.Property(e => e.OrganizationId)
                    .HasColumnName("OrganizationID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.OrganizationName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserName).HasColumnName("UserName");

                entity.Property(e => e.IsActive)
                     .HasDefaultValue(true);



                entity.HasOne(d => d.User)
                    .WithMany(p => p.Organizations)
                    .HasForeignKey(d => d.UserName);
            });

            modelBuilder.Entity<OrganizationUser>(entity =>
            {
                entity.HasKey(e => new { e.OrganizationId, e.UserName });

                entity.Property(e => e.OrganizationId).HasColumnName("OrganizationID");

                entity.Property(e => e.UserName).HasColumnName("UserName");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.OrganizationUser)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.OrganizationUser)
                    .HasForeignKey(d => d.UserName)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ProfileAttachment>(entity =>
            {
                entity.HasKey(e => e.ProfAttId);

                entity.Property(e => e.ProfAttId)
                    .HasColumnName("ProfAttID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.FileName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserName).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ProfileAttachments)
                    .HasForeignKey(d => d.UserName);
            });

            modelBuilder.Entity<ProjectAttachment>(entity =>
            {
                entity.HasKey(e => e.ProjAttId);

                entity.Property(e => e.ProjAttId)
                    .HasColumnName("ProjAttID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.FileName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectAttachments)
                    .HasForeignKey(d => d.ProjectId);
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(e => e.ProjectId);

                entity.Property(e => e.ProjectId)
                    .HasColumnName("ProjectID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .HasDefaultValue(true);


            });

            modelBuilder.Entity<ProjectUser>(entity =>
            {
                entity.HasKey(e => new { e.ProjectId, e.UserName });

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.UserName).HasColumnName("UserName");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectUser)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ProjectUser)
                    .HasForeignKey(d => d.UserName)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasAlternateKey(e => e.UserName);

                entity.Property(e => e.Id)
                    .HasColumnName("Id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CellPhone)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Header)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.HomePhone)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(144)
                    .IsUnicode(false);

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ResumePath)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LinkedIn)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Repository)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                //entity.Property(e => e.Salt)
                //    .IsRequired()
                //    .HasMaxLength(8)
                //    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .HasDefaultValue(true);
            });

            modelBuilder.Entity<WorkExperience>(entity =>
            {
                entity.HasKey(e => e.WorkId);

                entity.Property(e => e.WorkId)
                    .HasColumnName("WorkID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.OrganizationId).HasColumnName("OrganizationID");

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.UserName).HasColumnName("UserName");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.WorkExperience)
                    .HasForeignKey(d => d.OrganizationId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.WorkExperience)
                    .HasForeignKey(d => d.UserName);
            });

            modelBuilder.Entity<Invitation>(entity =>
            {
                entity.HasKey(e => e.InvID);
                entity.HasAlternateKey(e => e.Email);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.InvKey)
                    .IsRequired();

            });
        }
    }
}
