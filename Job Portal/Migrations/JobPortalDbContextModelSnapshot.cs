﻿// <auto-generated />
using System;
using Job_Portal.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Job_Portal.Migrations
{
    [DbContext(typeof(JobPortalDbContext))]
    partial class JobPortalDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Job_Portal.DAL.ApplyForm", b =>
                {
                    b.Property<int>("ApplyFormId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ApplyFormId"));

                    b.Property<string>("ApplicantEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApplicantName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("AppliedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.Property<byte[]>("ResumePath")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("ApplyFormId");

                    b.HasIndex("JobId");

                    b.ToTable("ApplyForms");
                });

            modelBuilder.Entity("Job_Portal.DAL.Job", b =>
                {
                    b.Property<int>("JobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JobId"));

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("JobId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("Job_Portal.DAL.JobDetails", b =>
                {
                    b.Property<int>("JobDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JobDetailsId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PostedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Requirements")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("JobDetailsId");

                    b.HasIndex("JobId")
                        .IsUnique();

                    b.ToTable("JobDetails");
                });

            modelBuilder.Entity("Job_Portal.DAL.ApplyForm", b =>
                {
                    b.HasOne("Job_Portal.DAL.Job", "Job")
                        .WithMany("Applications")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Job");
                });

            modelBuilder.Entity("Job_Portal.DAL.JobDetails", b =>
                {
                    b.HasOne("Job_Portal.DAL.Job", "Job")
                        .WithOne("JobDetails")
                        .HasForeignKey("Job_Portal.DAL.JobDetails", "JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Job");
                });

            modelBuilder.Entity("Job_Portal.DAL.Job", b =>
                {
                    b.Navigation("Applications");

                    b.Navigation("JobDetails")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
