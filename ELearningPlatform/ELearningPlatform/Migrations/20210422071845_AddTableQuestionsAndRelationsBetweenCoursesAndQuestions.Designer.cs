﻿// <auto-generated />
using System;
using ELearningPlatform.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ELearningPlatform.Migrations
{
    [DbContext(typeof(ELearningPlatformContext))]
    [Migration("20210422071845_AddTableQuestionsAndRelationsBetweenCoursesAndQuestions")]
    partial class AddTableQuestionsAndRelationsBetweenCoursesAndQuestions
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ELearningPlatform.Model.Courses", b =>
                {
                    b.Property<int>("CoursesID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("CoursesID1")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Views")
                        .HasColumnType("int");

                    b.HasKey("CoursesID");

                    b.HasIndex("CoursesID1");

                    b.ToTable("Coursess");
                });

            modelBuilder.Entity("ELearningPlatform.Model.Questions", b =>
                {
                    b.Property<int>("QuestionsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CoursesID")
                        .HasColumnType("int");

                    b.Property<string>("QTitle")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Qa")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Qb")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Qc")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Qcorect")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Qd")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("QuestionsID");

                    b.HasIndex("CoursesID");

                    b.ToTable("Questionss");
                });

            modelBuilder.Entity("ELearningPlatform.Model.Role", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("RoleID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("ELearningPlatform.Model.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserID");

                    b.HasIndex("RoleID")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ELearningPlatform.Model.UserCourses", b =>
                {
                    b.Property<int>("UserCoursesID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CoursesID")
                        .HasColumnType("int");

                    b.Property<int>("RescultOfCours")
                        .HasColumnType("int");

                    b.Property<bool>("State")
                        .HasColumnType("bit");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("UserCoursesID");

                    b.HasIndex("CoursesID");

                    b.HasIndex("UserID");

                    b.ToTable("UserCoursess");
                });

            modelBuilder.Entity("ELearningPlatform.Model.Courses", b =>
                {
                    b.HasOne("ELearningPlatform.Model.Courses", null)
                        .WithMany("Coursess")
                        .HasForeignKey("CoursesID1");
                });

            modelBuilder.Entity("ELearningPlatform.Model.Questions", b =>
                {
                    b.HasOne("ELearningPlatform.Model.Courses", "Courses")
                        .WithMany()
                        .HasForeignKey("CoursesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Courses");
                });

            modelBuilder.Entity("ELearningPlatform.Model.User", b =>
                {
                    b.HasOne("ELearningPlatform.Model.Role", "Role")
                        .WithOne("User")
                        .HasForeignKey("ELearningPlatform.Model.User", "RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("ELearningPlatform.Model.UserCourses", b =>
                {
                    b.HasOne("ELearningPlatform.Model.Courses", "Courses")
                        .WithMany("UserCourses")
                        .HasForeignKey("CoursesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ELearningPlatform.Model.User", "User")
                        .WithMany("UserCourses")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Courses");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ELearningPlatform.Model.Courses", b =>
                {
                    b.Navigation("Coursess");

                    b.Navigation("UserCourses");
                });

            modelBuilder.Entity("ELearningPlatform.Model.Role", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("ELearningPlatform.Model.User", b =>
                {
                    b.Navigation("UserCourses");
                });
#pragma warning restore 612, 618
        }
    }
}
