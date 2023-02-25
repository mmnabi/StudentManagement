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
    [Migration("20230225122458_UpdateSeedClassNames")]
    partial class UpdateSeedClassNames
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

                    b.HasKey("Id");

                    b.ToTable("classes", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClassName = "First Class"
                        },
                        new
                        {
                            Id = 2,
                            ClassName = "Second Class"
                        },
                        new
                        {
                            Id = 3,
                            ClassName = "Third Class"
                        });
                });

            modelBuilder.Entity("StudentManagement.Shared.Domain.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

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
                            Name = "Bangladesh"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Germany"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Netherlands"
                        },
                        new
                        {
                            Id = 4,
                            Name = "USA"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Japan"
                        },
                        new
                        {
                            Id = 6,
                            Name = "China"
                        },
                        new
                        {
                            Id = 7,
                            Name = "UK"
                        },
                        new
                        {
                            Id = 8,
                            Name = "France"
                        },
                        new
                        {
                            Id = 9,
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

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

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
                            DateOfBirth = new DateTime(1994, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Emtious"
                        },
                        new
                        {
                            Id = 2,
                            ClassId = 2,
                            CountryId = 1,
                            DateOfBirth = new DateTime(1992, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Riad"
                        },
                        new
                        {
                            Id = 3,
                            ClassId = 1,
                            CountryId = 1,
                            DateOfBirth = new DateTime(1992, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Nabi"
                        },
                        new
                        {
                            Id = 4,
                            ClassId = 1,
                            CountryId = 1,
                            DateOfBirth = new DateTime(1992, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Nira"
                        },
                        new
                        {
                            Id = 5,
                            ClassId = 1,
                            CountryId = 1,
                            DateOfBirth = new DateTime(1992, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Nawaz"
                        },
                        new
                        {
                            Id = 6,
                            ClassId = 2,
                            CountryId = 1,
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
