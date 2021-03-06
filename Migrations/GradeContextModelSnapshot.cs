﻿// <auto-generated />
using c_my_grade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace cmygrade.Migrations
{
    [DbContext(typeof(GradeContext))]
    partial class GradeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("c_my_grade.Models.Assignment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CourseId");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int>("PossiblePoints");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("CourseAssignments");
                });

            modelBuilder.Entity("c_my_grade.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int?>("StudentId");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("c_my_grade.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PointsReceived");

                    b.Property<string>("Response");

                    b.Property<int>("SubmissionId");

                    b.HasKey("Id");

                    b.HasIndex("SubmissionId")
                        .IsUnique();

                    b.ToTable("SubmissionReviews");
                });

            modelBuilder.Entity("c_my_grade.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<float>("GPA");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("c_my_grade.Models.Submission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AssignmentId");

                    b.Property<int>("CourseId");

                    b.Property<string>("Data");

                    b.Property<int>("StudentId");

                    b.Property<DateTime>("Timestamp");

                    b.HasKey("Id");

                    b.HasIndex("AssignmentId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentSubmissions");
                });

            modelBuilder.Entity("c_my_grade.Models.Assignment", b =>
                {
                    b.HasOne("c_my_grade.Models.Course")
                        .WithMany("Assignments")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("c_my_grade.Models.Course", b =>
                {
                    b.HasOne("c_my_grade.Models.Student")
                        .WithMany("Courses")
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("c_my_grade.Models.Review", b =>
                {
                    b.HasOne("c_my_grade.Models.Submission", "StudentSubmission")
                        .WithOne("ReviewedResponse")
                        .HasForeignKey("c_my_grade.Models.Review", "SubmissionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("c_my_grade.Models.Submission", b =>
                {
                    b.HasOne("c_my_grade.Models.Assignment")
                        .WithMany("Submissions")
                        .HasForeignKey("AssignmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("c_my_grade.Models.Student")
                        .WithMany("Submissions")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
