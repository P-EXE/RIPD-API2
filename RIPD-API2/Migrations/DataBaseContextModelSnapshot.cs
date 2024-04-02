﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RIPD_API2.Data;

#nullable disable

namespace RIPD_API2.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    partial class DataBaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("RIPD_API2.Models.Diary", b =>
                {
                    b.Property<Guid>("OwnerID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("OwnerID");

                    b.ToTable("Diaries");
                });

            modelBuilder.Entity("RIPD_API2.Models.Food", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float?>("Alcohol")
                        .HasColumnType("real");

                    b.Property<float?>("AlphaCarotin")
                        .HasColumnType("real");

                    b.Property<string>("Barcode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("BetaCarotin")
                        .HasColumnType("real");

                    b.Property<float?>("BetaCryptoxanthin")
                        .HasColumnType("real");

                    b.Property<float?>("Calcium")
                        .HasColumnType("real");

                    b.Property<float?>("Carbohydrates")
                        .HasColumnType("real");

                    b.Property<float?>("Cholesterol")
                        .HasColumnType("real");

                    b.Property<float?>("Choline")
                        .HasColumnType("real");

                    b.Property<Guid>("ContributerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float?>("Copper")
                        .HasColumnType("real");

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("Energy")
                        .HasColumnType("real");

                    b.Property<float?>("Fat")
                        .HasColumnType("real");

                    b.Property<float?>("FattyAcidsMono")
                        .HasColumnType("real");

                    b.Property<float?>("FattyAcidsPoly")
                        .HasColumnType("real");

                    b.Property<float?>("FattyAcidsSaturated")
                        .HasColumnType("real");

                    b.Property<float?>("Fiber")
                        .HasColumnType("real");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("Iron")
                        .HasColumnType("real");

                    b.Property<float?>("LutZea")
                        .HasColumnType("real");

                    b.Property<float?>("Lycopene")
                        .HasColumnType("real");

                    b.Property<float?>("Magnesium")
                        .HasColumnType("real");

                    b.Property<float?>("Manganese")
                        .HasColumnType("real");

                    b.Property<Guid>("ManufacturerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("Phosphorus")
                        .HasColumnType("real");

                    b.Property<float?>("Potassium")
                        .HasColumnType("real");

                    b.Property<float?>("Protein")
                        .HasColumnType("real");

                    b.Property<float?>("Retinol")
                        .HasColumnType("real");

                    b.Property<float?>("Selenium")
                        .HasColumnType("real");

                    b.Property<float?>("Sodium")
                        .HasColumnType("real");

                    b.Property<float?>("Sugar")
                        .HasColumnType("real");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<float?>("VitaminA1")
                        .HasColumnType("real");

                    b.Property<float?>("VitaminB1")
                        .HasColumnType("real");

                    b.Property<float?>("VitaminB12")
                        .HasColumnType("real");

                    b.Property<float?>("VitaminB2")
                        .HasColumnType("real");

                    b.Property<float?>("VitaminB3")
                        .HasColumnType("real");

                    b.Property<float?>("VitaminB5")
                        .HasColumnType("real");

                    b.Property<float?>("VitaminB6")
                        .HasColumnType("real");

                    b.Property<float?>("VitaminB9")
                        .HasColumnType("real");

                    b.Property<float?>("VitaminC")
                        .HasColumnType("real");

                    b.Property<float?>("VitaminD")
                        .HasColumnType("real");

                    b.Property<float?>("VitaminE")
                        .HasColumnType("real");

                    b.Property<float?>("VitaminK")
                        .HasColumnType("real");

                    b.Property<float?>("Water")
                        .HasColumnType("real");

                    b.Property<float?>("Zinc")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("ContributerId");

                    b.HasIndex("ManufacturerId");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("RIPD_API2.Models.Run", b =>
                {
                    b.Property<Guid>("DiaryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("MongoDBId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DiaryId", "Id");

                    b.ToTable("Runs");
                });

            modelBuilder.Entity("RIPD_API2.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("RIPD_API2.Models.Workout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("ContributerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Energy")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ContributerId");

                    b.ToTable("Workouts");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("RIPD_API2.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("RIPD_API2.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RIPD_API2.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("RIPD_API2.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RIPD_API2.Models.Diary", b =>
                {
                    b.HasOne("RIPD_API2.Models.User", "Owner")
                        .WithOne("Diary")
                        .HasForeignKey("RIPD_API2.Models.Diary", "OwnerID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.OwnsMany("RIPD_API2.Models.Food_DiaryEntry", "FoodEntries", b1 =>
                        {
                            b1.Property<Guid>("DiaryId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<DateTime>("Added")
                                .HasColumnType("datetime2");

                            b1.Property<double>("Amount")
                                .HasColumnType("float");

                            b1.Property<int?>("FoodId")
                                .HasColumnType("int");

                            b1.HasKey("DiaryId", "Id");

                            b1.HasIndex("FoodId");

                            b1.ToTable("DiaryFoods");

                            b1.WithOwner("Diary")
                                .HasForeignKey("DiaryId");

                            b1.HasOne("RIPD_API2.Models.Food", "Food")
                                .WithMany()
                                .HasForeignKey("FoodId")
                                .OnDelete(DeleteBehavior.NoAction);

                            b1.Navigation("Diary");

                            b1.Navigation("Food");
                        });

                    b.OwnsMany("RIPD_API2.Models.Workout_DiaryEntry", "WorkoutEntries", b1 =>
                        {
                            b1.Property<Guid>("DiaryId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<DateTime>("Added")
                                .HasColumnType("datetime2");

                            b1.Property<double>("Amount")
                                .HasColumnType("float");

                            b1.Property<int>("WorkoutId")
                                .HasColumnType("int");

                            b1.HasKey("DiaryId", "Id");

                            b1.HasIndex("WorkoutId");

                            b1.ToTable("DiaryWorkouts");

                            b1.WithOwner("Diary")
                                .HasForeignKey("DiaryId");

                            b1.HasOne("RIPD_API2.Models.Workout", "Workout")
                                .WithMany()
                                .HasForeignKey("WorkoutId")
                                .OnDelete(DeleteBehavior.NoAction)
                                .IsRequired();

                            b1.Navigation("Diary");

                            b1.Navigation("Workout");
                        });

                    b.Navigation("FoodEntries");

                    b.Navigation("Owner");

                    b.Navigation("WorkoutEntries");
                });

            modelBuilder.Entity("RIPD_API2.Models.Food", b =>
                {
                    b.HasOne("RIPD_API2.Models.User", "Contributer")
                        .WithMany("ContributedFoods")
                        .HasForeignKey("ContributerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("RIPD_API2.Models.User", "Manufacturer")
                        .WithMany("ManufacturedFoods")
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Contributer");

                    b.Navigation("Manufacturer");
                });

            modelBuilder.Entity("RIPD_API2.Models.Run", b =>
                {
                    b.HasOne("RIPD_API2.Models.Diary", "Diary")
                        .WithMany()
                        .HasForeignKey("DiaryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Diary");
                });

            modelBuilder.Entity("RIPD_API2.Models.Workout", b =>
                {
                    b.HasOne("RIPD_API2.Models.User", "Contributer")
                        .WithMany("ContributedWorkouts")
                        .HasForeignKey("ContributerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Contributer");
                });

            modelBuilder.Entity("RIPD_API2.Models.User", b =>
                {
                    b.Navigation("ContributedFoods");

                    b.Navigation("ContributedWorkouts");

                    b.Navigation("Diary");

                    b.Navigation("ManufacturedFoods");
                });
#pragma warning restore 612, 618
        }
    }
}
