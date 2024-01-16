﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SignatureTech.DataAccess;

#nullable disable

namespace SignatureTech.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230706114951_addEmployeeDetail")]
    partial class addEmployeeDetail
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SignatureTech.Models.EmergencyContact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeDetailId")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Relationship")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeDetailId");

                    b.ToTable("EmergencyContacts");
                });

            modelBuilder.Entity("SignatureTech.Models.EmployeeDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DOBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdCard")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaritalStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("EmployeeDetails");
                });

            modelBuilder.Entity("SignatureTech.Models.JobInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeDetailId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeDetailId");

                    b.ToTable("jobInformations");
                });

            modelBuilder.Entity("SignatureTech.Models.EmergencyContact", b =>
                {
                    b.HasOne("SignatureTech.Models.EmployeeDetail", "EmployeeDetail")
                        .WithMany()
                        .HasForeignKey("EmployeeDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmployeeDetail");
                });

            modelBuilder.Entity("SignatureTech.Models.JobInformation", b =>
                {
                    b.HasOne("SignatureTech.Models.EmployeeDetail", "EmployeeDetail")
                        .WithMany()
                        .HasForeignKey("EmployeeDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmployeeDetail");
                });
#pragma warning restore 612, 618
        }
    }
}
