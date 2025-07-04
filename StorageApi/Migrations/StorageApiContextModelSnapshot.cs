﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StorageApi.Data;

#nullable disable

namespace StorageApi.Migrations
{
    [DbContext(typeof(StorageApiContext))]
    partial class StorageApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StorageApi.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Shelf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = "Furniture",
                            Count = 1,
                            Description = "Nice chair.",
                            Name = "Chair",
                            Price = 100,
                            Shelf = "A2"
                        },
                        new
                        {
                            Id = 2,
                            Category = "Vehicle",
                            Count = 5,
                            Description = "Goodyear Tire.",
                            Name = "Tire",
                            Price = 500,
                            Shelf = "F1"
                        },
                        new
                        {
                            Id = 3,
                            Category = "Clothes",
                            Count = 5,
                            Description = "Blue shirt.",
                            Name = "Shirt",
                            Price = 25,
                            Shelf = "Q8"
                        },
                        new
                        {
                            Id = 4,
                            Category = "Clothes",
                            Count = 10,
                            Description = "Black jacket.",
                            Name = "Jacket",
                            Price = 350,
                            Shelf = "Q9"
                        },
                        new
                        {
                            Id = 5,
                            Category = "Animals",
                            Count = 100,
                            Description = "A whistle for your dog.",
                            Name = "Dog whistle",
                            Price = 10,
                            Shelf = "B12"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
