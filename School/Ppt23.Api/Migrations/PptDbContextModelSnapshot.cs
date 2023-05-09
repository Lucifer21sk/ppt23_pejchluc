﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Ppt23.Api.Data;

#nullable disable

namespace Ppt23.Api.Migrations
{
    [DbContext(typeof(PptDbContext))]
    partial class PptDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                            Name = "Injection",
                            Price = 78323
                        },
                        new
                        {
                            Id = new Guid("9ab77602-8aac-40ed-b042-d2d4b4e04b31"),
                            BoughtDate = new DateTime(2016, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Microscope",
                            Price = 679104
                        },
                        new
                        {
                            Id = new Guid("0a7959e7-d736-414f-8834-c73c00e12afb"),
                            BoughtDate = new DateTime(2019, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "X-Ray",
                            Price = 452610
                        });
                });

            modelBuilder.Entity("Ppt23.Api.Data.Revision", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("EquipmentId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EquipmentId");

                    b.ToTable("Revisions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b106ddc7-c8c6-4370-a663-e28827862a78"),
                            DateTime = new DateTime(2019, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EquipmentId = new Guid("cd93f294-e926-4f04-bf3e-d06091f82ccc"),
                            Name = "First"
                        },
                        new
                        {
                            Id = new Guid("adb6a0a6-80b6-4637-8008-2e7ce2fc7e8e"),
                            DateTime = new DateTime(2020, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EquipmentId = new Guid("cd93f294-e926-4f04-bf3e-d06091f82ccc"),
                            Name = "Second"
                        },
                        new
                        {
                            Id = new Guid("1465be46-5dbf-4c9f-b397-df4c91176eb9"),
                            DateTime = new DateTime(2019, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EquipmentId = new Guid("9ab77602-8aac-40ed-b042-d2d4b4e04b31"),
                            Name = "First"
                        });
                });

            modelBuilder.Entity("Ppt23.Api.Data.Revision", b =>
                {
                    b.HasOne("Ppt23.Api.Data.Equipment", "Equipment")
                        .WithMany("Revisions")
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipment");
                });

            modelBuilder.Entity("Ppt23.Api.Data.Equipment", b =>
                {
                    b.Navigation("Revisions");
                });
#pragma warning restore 612, 618
        }
    }
}
