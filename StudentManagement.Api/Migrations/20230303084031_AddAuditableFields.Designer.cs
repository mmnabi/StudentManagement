﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentManagement.Api.Data;

#nullable disable

namespace StudentManagement.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230303084031_AddAuditableFields")]
    partial class AddAuditableFields
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.3");

            modelBuilder.Entity("StudentManagement.Shared.Domain.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("ClassName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT")
                        .HasColumnName("class_name");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("TEXT")
                        .HasColumnName("create_date");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("TEXT")
                        .HasColumnName("modified_date");

                    b.HasKey("Id");

                    b.ToTable("classes", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClassName = "First Class",
                            CreatedDate = new DateTime(2023, 3, 3, 14, 40, 31, 597, DateTimeKind.Local).AddTicks(427)
                        },
                        new
                        {
                            Id = 2,
                            ClassName = "Second Class",
                            CreatedDate = new DateTime(2023, 3, 3, 14, 40, 31, 597, DateTimeKind.Local).AddTicks(464)
                        },
                        new
                        {
                            Id = 3,
                            ClassName = "Third Class",
                            CreatedDate = new DateTime(2023, 3, 3, 14, 40, 31, 597, DateTimeKind.Local).AddTicks(474)
                        });
                });

            modelBuilder.Entity("StudentManagement.Shared.Domain.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("TEXT")
                        .HasColumnName("create_date");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("TEXT")
                        .HasColumnName("modified_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("countries", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2023, 3, 3, 14, 40, 31, 597, DateTimeKind.Local).AddTicks(485),
                            Name = "Bangladesh"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2023, 3, 3, 14, 40, 31, 597, DateTimeKind.Local).AddTicks(547),
                            Name = "Germany"
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2023, 3, 3, 14, 40, 31, 597, DateTimeKind.Local).AddTicks(557),
                            Name = "Netherlands"
                        },
                        new
                        {
                            Id = 4,
                            CreatedDate = new DateTime(2023, 3, 3, 14, 40, 31, 597, DateTimeKind.Local).AddTicks(565),
                            Name = "USA"
                        },
                        new
                        {
                            Id = 5,
                            CreatedDate = new DateTime(2023, 3, 3, 14, 40, 31, 597, DateTimeKind.Local).AddTicks(573),
                            Name = "Japan"
                        },
                        new
                        {
                            Id = 6,
                            CreatedDate = new DateTime(2023, 3, 3, 14, 40, 31, 597, DateTimeKind.Local).AddTicks(583),
                            Name = "China"
                        },
                        new
                        {
                            Id = 7,
                            CreatedDate = new DateTime(2023, 3, 3, 14, 40, 31, 597, DateTimeKind.Local).AddTicks(592),
                            Name = "UK"
                        },
                        new
                        {
                            Id = 8,
                            CreatedDate = new DateTime(2023, 3, 3, 14, 40, 31, 597, DateTimeKind.Local).AddTicks(600),
                            Name = "France"
                        },
                        new
                        {
                            Id = 9,
                            CreatedDate = new DateTime(2023, 3, 3, 14, 40, 31, 597, DateTimeKind.Local).AddTicks(607),
                            Name = "Brazil"
                        });
                });

            modelBuilder.Entity("StudentManagement.Shared.Domain.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<int>("ClassId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("class_id");

                    b.Property<int>("CountryId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("country_id");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("TEXT")
                        .HasColumnName("create_date");

                    b.Property<DateTime?>("DateOfBirth")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("TEXT")
                        .HasColumnName("modified_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("CountryId");

                    b.ToTable("students", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClassId = 1,
                            CountryId = 1,
                            CreatedDate = new DateTime(2023, 3, 3, 14, 40, 31, 597, DateTimeKind.Local).AddTicks(624),
                            DateOfBirth = new DateTime(1994, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Emtious"
                        },
                        new
                        {
                            Id = 2,
                            ClassId = 2,
                            CountryId = 1,
                            CreatedDate = new DateTime(2023, 3, 3, 14, 40, 31, 597, DateTimeKind.Local).AddTicks(636),
                            DateOfBirth = new DateTime(1992, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Riad"
                        },
                        new
                        {
                            Id = 3,
                            ClassId = 1,
                            CountryId = 1,
                            CreatedDate = new DateTime(2023, 3, 3, 14, 40, 31, 597, DateTimeKind.Local).AddTicks(644),
                            DateOfBirth = new DateTime(1992, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Nabi"
                        },
                        new
                        {
                            Id = 4,
                            ClassId = 1,
                            CountryId = 1,
                            CreatedDate = new DateTime(2023, 3, 3, 14, 40, 31, 597, DateTimeKind.Local).AddTicks(653),
                            DateOfBirth = new DateTime(1992, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Nira"
                        },
                        new
                        {
                            Id = 5,
                            ClassId = 1,
                            CountryId = 1,
                            CreatedDate = new DateTime(2023, 3, 3, 14, 40, 31, 597, DateTimeKind.Local).AddTicks(662),
                            DateOfBirth = new DateTime(1992, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Nawaz"
                        },
                        new
                        {
                            Id = 6,
                            ClassId = 2,
                            CountryId = 1,
                            CreatedDate = new DateTime(2023, 3, 3, 14, 40, 31, 597, DateTimeKind.Local).AddTicks(672),
                            DateOfBirth = new DateTime(1992, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Tanzir"
                        });
                });

            modelBuilder.Entity("StudentManagement.Shared.Domain.Student", b =>
                {
                    b.HasOne("StudentManagement.Shared.Domain.Class", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("StudentManagement.Shared.Domain.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Country");
                });
#pragma warning restore 612, 618
        }
    }
}