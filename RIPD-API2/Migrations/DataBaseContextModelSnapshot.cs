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
    [DbContext(typeof(SQLDataBaseContext))]
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

            modelBuilder.Entity("RIPD_API2.Models.BodyMetric", b =>
                {
                    b.Property<Guid>("DiaryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("EntryNr")
                        .HasColumnType("int");

                    b.Property<DateTime>("Added")
                        .HasColumnType("datetime2");

                    b.Property<double?>("Height")
                        .HasColumnType("float");

                    b.Property<DateTime>("Recorded")
                        .HasColumnType("datetime2");

                    b.Property<double?>("Weight")
                        .HasColumnType("float");

                    b.HasKey("DiaryId", "EntryNr");

                    b.ToTable("BodyMetrics");
                });

            modelBuilder.Entity("RIPD_API2.Models.Diary", b =>
                {
                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("OwnerId");

                    b.ToTable("Diaries");
                });

            modelBuilder.Entity("RIPD_API2.Models.FitnessTarget", b =>
                {
                    b.Property<Guid>("DiaryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("EntryNr")
                        .HasColumnType("int");

                    b.Property<DateTime>("Added")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("BodyMetricUser")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("GoalBodyMetricEntryNr")
                        .HasColumnType("int");

                    b.Property<int>("StartBodyMetricEntryNr")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("DiaryId", "EntryNr");

                    b.HasIndex("BodyMetricUser", "GoalBodyMetricEntryNr");

                    b.HasIndex("BodyMetricUser", "StartBodyMetricEntryNr");

                    b.ToTable("FitnessTargets");
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

            modelBuilder.Entity("RIPD_API2.Models.Food_DiaryEntry", b =>
                {
                    b.Property<Guid>("DiaryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("EntryNr")
                        .HasColumnType("int");

                    b.Property<DateTime>("Added")
                        .HasColumnType("datetime2");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("Consumed")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FoodId")
                        .HasColumnType("int");

                    b.HasKey("DiaryId", "EntryNr");

                    b.HasIndex("FoodId");

                    b.ToTable("DiaryFoods");
                });

            modelBuilder.Entity("RIPD_API2.Models.RunEntry", b =>
                {
                    b.Property<Guid>("DiaryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("EntryNr")
                        .HasColumnType("int");

                    b.Property<DateTime>("Added")
                        .HasColumnType("datetime2");

                    b.Property<string>("MongoDBId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DiaryId", "EntryNr");

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
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

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

            modelBuilder.Entity("RIPD_API2.Models.Workout_DiaryEntry", b =>
                {
                    b.Property<Guid>("DiaryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("EntryNr")
                        .HasColumnType("int");

                    b.Property<DateTime>("Added")
                        .HasColumnType("datetime2");

                    b.Property<double?>("Amount")
                        .HasColumnType("float");

                    b.Property<int?>("WorkoutId")
                        .HasColumnType("int");

                    b.HasKey("DiaryId", "EntryNr");

                    b.HasIndex("WorkoutId");

                    b.ToTable("DiaryWorkouts");
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

            modelBuilder.Entity("RIPD_API2.Models.BodyMetric", b =>
                {
                    b.HasOne("RIPD_API2.Models.Diary", "Diary")
                        .WithMany("BodyMetrics")
                        .HasForeignKey("DiaryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Diary");
                });

            modelBuilder.Entity("RIPD_API2.Models.Diary", b =>
                {
                    b.HasOne("RIPD_API2.Models.User", "Owner")
                        .WithOne("Diary")
                        .HasForeignKey("RIPD_API2.Models.Diary", "OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("RIPD_API2.Models.FitnessTarget", b =>
                {
                    b.HasOne("RIPD_API2.Models.Diary", "Diary")
                        .WithMany("FitnessTargets")
                        .HasForeignKey("DiaryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RIPD_API2.Models.BodyMetric", "GoalBodyMetric")
                        .WithMany()
                        .HasForeignKey("BodyMetricUser", "GoalBodyMetricEntryNr")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("RIPD_API2.Models.BodyMetric", "StartBodyMetric")
                        .WithMany()
                        .HasForeignKey("BodyMetricUser", "StartBodyMetricEntryNr")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Diary");

                    b.Navigation("GoalBodyMetric");

                    b.Navigation("StartBodyMetric");
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

            modelBuilder.Entity("RIPD_API2.Models.Food_DiaryEntry", b =>
                {
                    b.HasOne("RIPD_API2.Models.Diary", "Diary")
                        .WithMany("FoodEntries")
                        .HasForeignKey("DiaryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RIPD_API2.Models.Food", "Food")
                        .WithMany()
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Diary");

                    b.Navigation("Food");
                });

            modelBuilder.Entity("RIPD_API2.Models.RunEntry", b =>
                {
                    b.HasOne("RIPD_API2.Models.Diary", "Diary")
                        .WithMany("Runs")
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

            modelBuilder.Entity("RIPD_API2.Models.Workout_DiaryEntry", b =>
                {
                    b.HasOne("RIPD_API2.Models.Diary", "Diary")
                        .WithMany("WorkoutEntries")
                        .HasForeignKey("DiaryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RIPD_API2.Models.Workout", "Workout")
                        .WithMany()
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Diary");

                    b.Navigation("Workout");
                });

            modelBuilder.Entity("RIPD_API2.Models.Diary", b =>
                {
                    b.Navigation("BodyMetrics");

                    b.Navigation("FitnessTargets");

                    b.Navigation("FoodEntries");

                    b.Navigation("Runs");

                    b.Navigation("WorkoutEntries");
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
