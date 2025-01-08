﻿// <auto-generated />
using Ecommerce_DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ecommerce_DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250108132501_ForeignKeyRelationBetweenProductAndCategoryEstablished")]
    partial class ForeignKeyRelationBetweenProductAndCategoryEstablished
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Ecommerce_Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayOrder = 1,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 2,
                            DisplayOrder = 2,
                            Name = "Sci-Fi"
                        },
                        new
                        {
                            Id = 3,
                            DisplayOrder = 3,
                            Name = "Romance"
                        });
                });

            modelBuilder.Entity("Ecommerce_Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ListPrice")
                        .HasColumnType("float");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<double>("Price100")
                        .HasColumnType("float");

                    b.Property<double>("Price50")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Billy Spark",
                            CategoryId = 1,
                            Description = "Praesent vitae sodales libero. Praesent molestie.",
                            ISBN = "SWD9999001",
                            ListPrice = 99.0,
                            Price = 90.0,
                            Price100 = 80.0,
                            Price50 = 85.0,
                            Title = "Fortune of Time"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Jane Doe",
                            CategoryId = 2,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                            ISBN = "SWD9999002",
                            ListPrice = 120.0,
                            Price = 110.0,
                            Price100 = 100.0,
                            Price50 = 105.0,
                            Title = "Future of Earth"
                        },
                        new
                        {
                            Id = 3,
                            Author = "John Smith",
                            CategoryId = 3,
                            Description = "Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            ISBN = "SWD9999003",
                            ListPrice = 89.0,
                            Price = 85.0,
                            Price100 = 75.0,
                            Price50 = 80.0,
                            Title = "Secrets of the Universe"
                        },
                        new
                        {
                            Id = 4,
                            Author = "Alice Johnson",
                            CategoryId = 4,
                            Description = "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris.",
                            ISBN = "SWD9999004",
                            ListPrice = 95.0,
                            Price = 90.0,
                            Price100 = 80.0,
                            Price50 = 85.0,
                            Title = "The Hidden Truth"
                        },
                        new
                        {
                            Id = 5,
                            Author = "Michael Brown",
                            CategoryId = 1,
                            Description = "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore.",
                            ISBN = "SWD9999005",
                            ListPrice = 150.0,
                            Price = 140.0,
                            Price100 = 130.0,
                            Price50 = 135.0,
                            Title = "Adventures in Coding"
                        },
                        new
                        {
                            Id = 6,
                            Author = "Chris Green",
                            CategoryId = 2,
                            Description = "Excepteur sint occaecat cupidatat non proident, sunt in culpa.",
                            ISBN = "SWD9999006",
                            ListPrice = 200.0,
                            Price = 190.0,
                            Price100 = 180.0,
                            Price50 = 185.0,
                            Title = "Mastering .NET"
                        },
                        new
                        {
                            Id = 7,
                            Author = "Emily White",
                            CategoryId = 3,
                            Description = "Proin eget tortor risus. Donec sollicitudin molestie malesuada.",
                            ISBN = "SWD9999007",
                            ListPrice = 110.0,
                            Price = 100.0,
                            Price100 = 90.0,
                            Price50 = 95.0,
                            Title = "Journey to the Stars"
                        },
                        new
                        {
                            Id = 8,
                            Author = "Robert Black",
                            CategoryId = 4,
                            Description = "Vestibulum ac diam sit amet quam vehicula elementum.",
                            ISBN = "SWD9999008",
                            ListPrice = 130.0,
                            Price = 120.0,
                            Price100 = 110.0,
                            Price50 = 115.0,
                            Title = "Data Structures Unleashed"
                        },
                        new
                        {
                            Id = 9,
                            Author = "Sophia Blue",
                            CategoryId = 1,
                            Description = "Pellentesque in ipsum id orci porta dapibus.",
                            ISBN = "SWD9999009",
                            ListPrice = 175.0,
                            Price = 165.0,
                            Price100 = 155.0,
                            Price50 = 160.0,
                            Title = "Artificial Intelligence Basics"
                        },
                        new
                        {
                            Id = 10,
                            Author = "Ethan Gray",
                            CategoryId = 2,
                            Description = "Curabitur aliquet quam id dui posuere blandit.",
                            ISBN = "SWD9999010",
                            ListPrice = 140.0,
                            Price = 130.0,
                            Price100 = 120.0,
                            Price50 = 125.0,
                            Title = "The Art of Problem Solving"
                        });
                });

            modelBuilder.Entity("Ecommerce_Models.Product", b =>
                {
                    b.HasOne("Ecommerce_Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
