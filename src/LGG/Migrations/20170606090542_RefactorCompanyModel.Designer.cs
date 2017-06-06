using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using LGG.Persistence;

namespace LGG.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170606090542_RefactorCompanyModel")]
    partial class RefactorCompanyModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("LGG.Core.Models.Article", b =>
                {
                    b.Property<int>("ArticleId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content")
                        .HasMaxLength(21844);

                    b.HasKey("ArticleId");

                    b.ToTable("Article");
                });

            modelBuilder.Entity("LGG.Core.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<string>("Url")
                        .HasMaxLength(100);

                    b.HasKey("CategoryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("LGG.Core.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AboutId");

                    b.Property<string>("Address")
                        .HasMaxLength(255);

                    b.Property<int?>("ArticleAboutArticleId");

                    b.Property<int?>("ArticlePrivacyArticleId");

                    b.Property<int?>("ArticleTermsOfUseArticleId");

                    b.Property<string>("Avatar")
                        .HasMaxLength(250);

                    b.Property<string>("Email")
                        .HasMaxLength(254);

                    b.Property<string>("Facebook")
                        .HasMaxLength(50);

                    b.Property<string>("Google")
                        .HasMaxLength(50);

                    b.Property<string>("Hotline")
                        .HasMaxLength(15);

                    b.Property<string>("Instagram")
                        .HasMaxLength(50);

                    b.Property<string>("LinkedIn")
                        .HasMaxLength(50);

                    b.Property<string>("Logo")
                        .HasMaxLength(250);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("Pinterest")
                        .HasMaxLength(50);

                    b.Property<int?>("PrivacyId");

                    b.Property<string>("Sologan")
                        .HasMaxLength(250);

                    b.Property<int?>("TermsOfUseId");

                    b.Property<string>("TimeWork")
                        .HasMaxLength(250);

                    b.Property<string>("Twitter")
                        .HasMaxLength(50);

                    b.Property<string>("Website")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("ArticleAboutArticleId");

                    b.HasIndex("ArticlePrivacyArticleId");

                    b.HasIndex("ArticleTermsOfUseArticleId");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("LGG.Core.Models.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .HasMaxLength(254);

                    b.HasKey("ContactId");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("LGG.Core.Models.Excerpt", b =>
                {
                    b.Property<int>("ExcerptId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content")
                        .HasMaxLength(500);

                    b.HasKey("ExcerptId");

                    b.ToTable("Excerpt");
                });

            modelBuilder.Entity("LGG.Core.Models.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ArticleId");

                    b.Property<int?>("CategoryId");

                    b.Property<DateTime?>("CreatedOn");

                    b.Property<string>("Description")
                        .HasMaxLength(300);

                    b.Property<int?>("ExcerptId");

                    b.Property<string>("IconImage")
                        .HasMaxLength(250);

                    b.Property<string>("Image")
                        .HasMaxLength(250);

                    b.Property<string>("Link")
                        .HasMaxLength(220);

                    b.Property<string>("Meta")
                        .HasMaxLength(250);

                    b.Property<DateTime?>("ModifiedOn");

                    b.Property<DateTime?>("PostedOn");

                    b.Property<bool>("Published");

                    b.Property<string>("SmallImage")
                        .HasMaxLength(250);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("Url")
                        .HasMaxLength(220);

                    b.HasKey("PostId");

                    b.HasIndex("ArticleId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ExcerptId");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("LGG.Core.Models.PostTag", b =>
                {
                    b.Property<int>("PostTagId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PostId");

                    b.Property<int>("TagId");

                    b.HasKey("PostTagId");

                    b.HasIndex("PostId");

                    b.HasIndex("TagId");

                    b.ToTable("PostTag");
                });

            modelBuilder.Entity("LGG.Core.Models.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<string>("Url")
                        .HasMaxLength(100);

                    b.HasKey("TagId");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("LGG.Core.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
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
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("LGG.Core.Models.Company", b =>
                {
                    b.HasOne("LGG.Core.Models.Article", "ArticleAbout")
                        .WithMany()
                        .HasForeignKey("ArticleAboutArticleId");

                    b.HasOne("LGG.Core.Models.Article", "ArticlePrivacy")
                        .WithMany()
                        .HasForeignKey("ArticlePrivacyArticleId");

                    b.HasOne("LGG.Core.Models.Article", "ArticleTermsOfUse")
                        .WithMany()
                        .HasForeignKey("ArticleTermsOfUseArticleId");
                });

            modelBuilder.Entity("LGG.Core.Models.Post", b =>
                {
                    b.HasOne("LGG.Core.Models.Article", "Article")
                        .WithMany()
                        .HasForeignKey("ArticleId");

                    b.HasOne("LGG.Core.Models.Category", "Category")
                        .WithMany("Posts")
                        .HasForeignKey("CategoryId");

                    b.HasOne("LGG.Core.Models.Excerpt", "Excerpt")
                        .WithMany()
                        .HasForeignKey("ExcerptId");
                });

            modelBuilder.Entity("LGG.Core.Models.PostTag", b =>
                {
                    b.HasOne("LGG.Core.Models.Post", "Post")
                        .WithMany("PostTags")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LGG.Core.Models.Tag", "Tag")
                        .WithMany("Posts")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("LGG.Core.Models.User")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("LGG.Core.Models.User")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LGG.Core.Models.User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
