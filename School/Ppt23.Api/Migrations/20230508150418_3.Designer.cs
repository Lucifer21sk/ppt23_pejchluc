﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Ppt23.Api.Data;

#nullable disable

namespace Ppt23.Api.Migrations
{
    [DbContext(typeof(PptDbContext))]
    [Migration("20230508150418_3")]
    partial class _3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("Ppt23.Api.Data.Equipment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("BoughtDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastRevisionDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Price")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Equipment");

                    b.HasData(
                        new
                        {
                            Id = new Guid("cd93f294-e926-4f04-bf3e-d06091f82ccc"),
                            BoughtDate = new DateTime(2010, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastRevisionDate = new DateTime(2012, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Injection",
                            Price = 78323
                        },
                        new
                        {
                            Id = new Guid("9ab77602-8aac-40ed-b042-d2d4b4e04b31"),
                            BoughtDate = new DateTime(2016, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastRevisionDate = new DateTime(2015, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Microscope",
                            Price = 679104
                        });
                });

            modelBuilder.Entity("Ppt23.Api.Data.Revision", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Revisions");
                });
#pragma warning restore 612, 618
        }
    }
}
