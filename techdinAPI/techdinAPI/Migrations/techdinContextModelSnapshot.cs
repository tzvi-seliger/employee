﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TechdinAPI.Models;

namespace TechdinAPI.Migrations
{
    [DbContext(typeof(techdinContext))]
    partial class techdinContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("TechdinAPI.Models.BlogPost", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("PostID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.Property<string>("Subject")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("UserName")
                        .HasColumnName("UserName");

                    b.HasKey("PostId");

                    b.HasIndex("UserName");

                    b.ToTable("BlogPosts");
                });

            modelBuilder.Entity("TechdinAPI.Models.Cohort", b =>
                {
                    b.Property<int>("CohortId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CohortID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("Semester")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.HasKey("CohortId");

                    b.ToTable("Cohort");
                });

            modelBuilder.Entity("TechdinAPI.Models.Education", b =>
                {
                    b.Property<int>("EduId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("EduID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActivitiesSocieties")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.Property<string>("Degree")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime");

                    b.Property<string>("FieldOfStudy")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Grade")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<int?>("OrganizationId")
                        .HasColumnName("OrganizationID");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime");

                    b.Property<string>("UserName")
                        .HasColumnName("UserName");

                    b.HasKey("EduId");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("UserName");

                    b.ToTable("Education");
                });

            modelBuilder.Entity("TechdinAPI.Models.Invitation", b =>
                {
                    b.Property<int>("InvID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("InvKey")
                        .IsRequired();

                    b.Property<int>("Type")
                        .HasMaxLength(10);

                    b.HasKey("InvID");

                    b.HasAlternateKey("Email");

                    b.ToTable("Invitations");
                });

            modelBuilder.Entity("TechdinAPI.Models.NewsFeed", b =>
                {
                    b.Property<int>("ChangeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ChangeID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ChangeDate")
                        .HasColumnType("datetime");

                    b.Property<string>("ChangeType")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("UserName")
                        .HasColumnName("UserName");

                    b.HasKey("ChangeId");

                    b.HasIndex("UserName");

                    b.ToTable("NewsFeed");
                });

            modelBuilder.Entity("TechdinAPI.Models.Organization", b =>
                {
                    b.Property<int>("OrganizationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("OrganizationID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<string>("OrganizationName")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("UserName")
                        .HasColumnName("UserName");

                    b.HasKey("OrganizationId");

                    b.HasIndex("UserName");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("TechdinAPI.Models.OrganizationUser", b =>
                {
                    b.Property<int>("OrganizationId")
                        .HasColumnName("OrganizationID");

                    b.Property<string>("UserName")
                        .HasColumnName("UserName");

                    b.HasKey("OrganizationId", "UserName");

                    b.HasIndex("UserName");

                    b.ToTable("OrganizationUser");
                });

            modelBuilder.Entity("TechdinAPI.Models.ProfileAttachment", b =>
                {
                    b.Property<int>("ProfAttId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ProfAttID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FileName")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("UserName")
                        .HasColumnName("UserID");

                    b.HasKey("ProfAttId");

                    b.HasIndex("UserName");

                    b.ToTable("ProfileAttachments");
                });

            modelBuilder.Entity("TechdinAPI.Models.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ProjectID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("ProjectId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("TechdinAPI.Models.ProjectAttachment", b =>
                {
                    b.Property<int>("ProjAttId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ProjAttID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FileName")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<int?>("ProjectId")
                        .HasColumnName("ProjectID");

                    b.HasKey("ProjAttId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectAttachments");
                });

            modelBuilder.Entity("TechdinAPI.Models.ProjectUser", b =>
                {
                    b.Property<int>("ProjectId")
                        .HasColumnName("ProjectID");

                    b.Property<string>("UserName")
                        .HasColumnName("UserName");

                    b.HasKey("ProjectId", "UserName");

                    b.HasIndex("UserName");

                    b.ToTable("ProjectUser");
                });

            modelBuilder.Entity("TechdinAPI.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("CellPhone")
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.Property<int?>("CohortId");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .HasMaxLength(32)
                        .IsUnicode(false);

                    b.Property<string>("Header")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("HomePhone")
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.Property<string>("ImagePath")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<string>("LastName")
                        .HasMaxLength(32)
                        .IsUnicode(false);

                    b.Property<string>("LinkedIn")
                        .HasMaxLength(64)
                        .IsUnicode(false);

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(144)
                        .IsUnicode(false);

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("Repository")
                        .HasMaxLength(64)
                        .IsUnicode(false);

                    b.Property<string>("ResumePath")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .IsUnicode(false);

                    b.Property<int?>("Views");

                    b.HasKey("Id");

                    b.HasAlternateKey("UserName");

                    b.HasIndex("CohortId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("TechdinAPI.Models.UserInterests", b =>
                {
                    b.Property<string>("UserName")
                        .HasColumnName("UserName");

                    b.Property<string>("InterestName")
                        .HasColumnName("InterestName");

                    b.HasKey("UserName", "InterestName");

                    b.HasIndex("InterestName");

                    b.ToTable("UserInterests");
                });

            modelBuilder.Entity("TechdinAPI.Models.WorkExperience", b =>
                {
                    b.Property<int>("WorkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("WorkID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("OrganizationId")
                        .HasColumnName("OrganizationID");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime");

                    b.Property<string>("UserName")
                        .HasColumnName("UserName");

                    b.HasKey("WorkId");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("UserName");

                    b.ToTable("WorkExperience");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("TechdinAPI.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("TechdinAPI.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TechdinAPI.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("TechdinAPI.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TechdinAPI.Models.BlogPost", b =>
                {
                    b.HasOne("TechdinAPI.Models.User", "User")
                        .WithMany("BlogPosts")
                        .HasForeignKey("UserName");
                });

            modelBuilder.Entity("TechdinAPI.Models.Education", b =>
                {
                    b.HasOne("TechdinAPI.Models.Organization", "Organization")
                        .WithMany("Education")
                        .HasForeignKey("OrganizationId");

                    b.HasOne("TechdinAPI.Models.User", "User")
                        .WithMany("Education")
                        .HasForeignKey("UserName");
                });

            modelBuilder.Entity("TechdinAPI.Models.NewsFeed", b =>
                {
                    b.HasOne("TechdinAPI.Models.User", "User")
                        .WithMany("NewsFeed")
                        .HasForeignKey("UserName");
                });

            modelBuilder.Entity("TechdinAPI.Models.Organization", b =>
                {
                    b.HasOne("TechdinAPI.Models.User", "User")
                        .WithMany("Organizations")
                        .HasForeignKey("UserName");
                });

            modelBuilder.Entity("TechdinAPI.Models.OrganizationUser", b =>
                {
                    b.HasOne("TechdinAPI.Models.Organization", "Organization")
                        .WithMany("OrganizationUser")
                        .HasForeignKey("OrganizationId");

                    b.HasOne("TechdinAPI.Models.User", "User")
                        .WithMany("OrganizationUser")
                        .HasForeignKey("UserName");
                });

            modelBuilder.Entity("TechdinAPI.Models.ProfileAttachment", b =>
                {
                    b.HasOne("TechdinAPI.Models.User", "User")
                        .WithMany("ProfileAttachments")
                        .HasForeignKey("UserName");
                });

            modelBuilder.Entity("TechdinAPI.Models.ProjectAttachment", b =>
                {
                    b.HasOne("TechdinAPI.Models.Project", "Project")
                        .WithMany("ProjectAttachments")
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("TechdinAPI.Models.ProjectUser", b =>
                {
                    b.HasOne("TechdinAPI.Models.Project", "Project")
                        .WithMany("ProjectUser")
                        .HasForeignKey("ProjectId");

                    b.HasOne("TechdinAPI.Models.User", "User")
                        .WithMany("ProjectUser")
                        .HasForeignKey("UserName");
                });

            modelBuilder.Entity("TechdinAPI.Models.User", b =>
                {
                    b.HasOne("TechdinAPI.Models.Cohort", "Cohort")
                        .WithMany()
                        .HasForeignKey("CohortId");
                });

            modelBuilder.Entity("TechdinAPI.Models.UserInterests", b =>
                {
                    b.HasOne("TechdinAPI.Models.User", "Interest")
                        .WithMany()
                        .HasForeignKey("InterestName");

                    b.HasOne("TechdinAPI.Models.User", "User")
                        .WithMany("UserInterests")
                        .HasForeignKey("UserName");
                });

            modelBuilder.Entity("TechdinAPI.Models.WorkExperience", b =>
                {
                    b.HasOne("TechdinAPI.Models.Organization", "Organization")
                        .WithMany("WorkExperience")
                        .HasForeignKey("OrganizationId");

                    b.HasOne("TechdinAPI.Models.User", "User")
                        .WithMany("WorkExperience")
                        .HasForeignKey("UserName");
                });
#pragma warning restore 612, 618
        }
    }
}
