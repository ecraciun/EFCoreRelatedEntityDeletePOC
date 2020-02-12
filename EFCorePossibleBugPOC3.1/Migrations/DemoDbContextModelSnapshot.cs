﻿// <auto-generated />
using System;
using EFCorePossibleBugPOC;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFCorePossibleBugPOC3._1.Migrations
{
    [DbContext(typeof(DemoDbContext))]
    partial class DemoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFCorePossibleBugPOC.First", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MiddleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MiddleId");

                    b.ToTable("Firsts");
                });

            modelBuilder.Entity("EFCorePossibleBugPOC.First2", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MiddleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MiddleId");

                    b.ToTable("ZFirst2s");
                });

            modelBuilder.Entity("EFCorePossibleBugPOC.First3", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MiddleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MiddleId");

                    b.ToTable("ZFirst3s");
                });

            modelBuilder.Entity("EFCorePossibleBugPOC.Middle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Foo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Middles");
                });

            modelBuilder.Entity("EFCorePossibleBugPOC.ZLast", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MiddleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MiddleId");

                    b.ToTable("ZLasts");
                });

            modelBuilder.Entity("EFCorePossibleBugPOC.ZLast2", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MiddleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MiddleId");

                    b.ToTable("AZLast2s");
                });

            modelBuilder.Entity("EFCorePossibleBugPOC.ZLast3", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MiddleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MiddleId");

                    b.ToTable("AZLast3s");
                });

            modelBuilder.Entity("EFCorePossibleBugPOC.First", b =>
                {
                    b.HasOne("EFCorePossibleBugPOC.Middle", "Middle")
                        .WithMany()
                        .HasForeignKey("MiddleId");
                });

            modelBuilder.Entity("EFCorePossibleBugPOC.First2", b =>
                {
                    b.HasOne("EFCorePossibleBugPOC.Middle", "Middle")
                        .WithMany()
                        .HasForeignKey("MiddleId");
                });

            modelBuilder.Entity("EFCorePossibleBugPOC.First3", b =>
                {
                    b.HasOne("EFCorePossibleBugPOC.Middle", "Middle")
                        .WithMany()
                        .HasForeignKey("MiddleId");
                });

            modelBuilder.Entity("EFCorePossibleBugPOC.ZLast", b =>
                {
                    b.HasOne("EFCorePossibleBugPOC.Middle", "Middle")
                        .WithMany()
                        .HasForeignKey("MiddleId");
                });

            modelBuilder.Entity("EFCorePossibleBugPOC.ZLast2", b =>
                {
                    b.HasOne("EFCorePossibleBugPOC.Middle", "Middle")
                        .WithMany()
                        .HasForeignKey("MiddleId");
                });

            modelBuilder.Entity("EFCorePossibleBugPOC.ZLast3", b =>
                {
                    b.HasOne("EFCorePossibleBugPOC.Middle", "Middle")
                        .WithMany()
                        .HasForeignKey("MiddleId");
                });
#pragma warning restore 612, 618
        }
    }
}
