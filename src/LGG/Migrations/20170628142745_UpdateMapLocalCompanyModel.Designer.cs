using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using LGG.Persistence;

namespace LGG.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170628142745_UpdateMapLocalCompanyModel")]
    partial class UpdateMapLocalCompanyModel
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
                        .HasMaxLength(20000);

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

                    b.Property<string>("Avatar")
                        .HasMaxLength(250);

                    b.Property<string>("ContactEmail")
                        .HasMaxLength(254);

                    b.Property<string>("Description")
                        .HasMaxLength(500);

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

                    b.Property<double>("Latitude");

                    b.Property<string>("LinkedIn")
                        .HasMaxLength(50);

                    b.Property<string>("Logo")
                        .HasMaxLength(250);

                    b.Property<double>("Longitude");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("OurClients")
                        .HasMaxLength(250);

                    b.Property<string>("OurDifference1")
                        .HasMaxLength(50);

                    b.Property<string>("OurDifference2")
                        .HasMaxLength(50);

                    b.Property<string>("OurDifference3")
                        .HasMaxLength(50);

                    b.Property<string>("OurDifference4")
                        .HasMaxLength(50);

                    b.Property<string>("OurDifference5")
                        .HasMaxLength(50);

                    b.Property<string>("OurMission")
                        .HasMaxLength(250);

                    b.Property<string>("Phone")
                        .HasMaxLength(15);

                    b.Property<string>("Pinterest")
                        .HasMaxLength(50);

                    b.Property<int?>("PrivacyId");

                    b.Property<string>("Sologan")
                        .HasMaxLength(250);

                    b.Property<string>("SupportEmail")
                        .HasMaxLength(254);

                    b.Property<int?>("TermsOfUseId");

                    b.Property<string>("TimeWork")
                        .HasMaxLength(250);

                    b.Property<string>("Twitter")
                        .HasMaxLength(50);

                    b.Property<string>("VideoPresentation")
                        .HasMaxLength(250);

                    b.Property<string>("Website")
                        .HasMaxLength(50);

                    b.Property<string>("WhyChooseUs")
                        .HasMaxLength(1000);

                    b.HasKey("Id");

                    b.HasIndex("AboutId");

                    b.HasIndex("PrivacyId");

                    b.HasIndex("TermsOfUseId");

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

            modelBuilder.Entity("LGG.Core.Models.Gallery", b =>
                {
                    b.Property<int>("GalleryId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CategoryId");

                    b.Property<string>("Description")
                        .HasMaxLength(250);

                    b.Property<string>("Image")
                        .HasMaxLength(250);

                    b.Property<string>("Name")
                        .HasMaxLength(250);

                    b.HasKey("GalleryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Gallery");
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
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(36);

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(128);

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
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(36);

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
                        .IsRequired()
                        .HasMaxLength(36);

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
                        .IsRequired()
                        .HasMaxLength(36);

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(36);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(36);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(36);

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(36);

                    b.Property<string>("RoleId")
                        .HasMaxLength(36);

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(36);

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(36);

                    b.Property<string>("Name")
                        .HasMaxLength(36);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("LGG.Core.Models.Company", b =>
                {
                    b.HasOne("LGG.Core.Models.Article", "About")
                        .WithMany()
                        .HasForeignKey("AboutId");

                    b.HasOne("LGG.Core.Models.Article", "Privacy")
                        .WithMany()
                        .HasForeignKey("PrivacyId");

                    b.HasOne("LGG.Core.Models.Article", "TermsOfUse")
                        .WithMany()
                        .HasForeignKey("TermsOfUseId");
                });

            modelBuilder.Entity("LGG.Core.Models.Gallery", b =>
                {
                    b.HasOne("LGG.Core.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");
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
