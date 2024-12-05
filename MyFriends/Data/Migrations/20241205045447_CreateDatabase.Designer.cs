﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyFriends.Data;

#nullable disable

namespace MyFriends.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241205045447_CreateDatabase")]
    partial class CreateDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("MyFriends.Models.Friend", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Friends");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 25,
                            Name = "John Doe"
                        },
                        new
                        {
                            Id = 2,
                            Age = 30,
                            Name = "Jane Smith"
                        },
                        new
                        {
                            Id = 3,
                            Age = 45,
                            Name = "Michael Johnson"
                        },
                        new
                        {
                            Id = 4,
                            Age = 22,
                            Name = "Emily Davis"
                        },
                        new
                        {
                            Id = 5,
                            Age = 34,
                            Name = "David Wilson"
                        },
                        new
                        {
                            Id = 6,
                            Age = 28,
                            Name = "Sarah Brown"
                        },
                        new
                        {
                            Id = 7,
                            Age = 33,
                            Name = "Chris Evans"
                        },
                        new
                        {
                            Id = 8,
                            Age = 27,
                            Name = "Olivia Martinez"
                        },
                        new
                        {
                            Id = 9,
                            Age = 24,
                            Name = "Liam Lee"
                        },
                        new
                        {
                            Id = 10,
                            Age = 29,
                            Name = "Sophia Harris"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
