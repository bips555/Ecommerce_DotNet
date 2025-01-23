using Ecommerce_Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_DataAccess.Data
{
    public class ApplicationDbContext:IdentityDbContext<IdentityUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
       public DbSet<Product> Products { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<ProductImage> ProductImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
            base.OnModelCreating(modelBuilder);
             modelBuilder.Entity<Category>().HasData(
                 new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                   new Category { Id = 2, Name = "Sci-Fi", DisplayOrder = 2 },
                     new Category { Id = 3, Name = "Romance", DisplayOrder = 3 }
                 );

            modelBuilder.Entity<Company>().HasData(
              new Company { Id = 1, Name = "Book1 Tech",StreetAddress ="Tokha 06",City="KTM",State="Bagmati",PhoneNumber="9840112175",PostalCode="1324" },
                new Company { Id = 2, Name = "Book2 Tech", StreetAddress = "Zinpe 04", City = "PKH", State = "Gandaki", PhoneNumber = "98234237560", PostalCode = "4320" },
                  new Company { Id = 3, Name = "Book3 Tech", StreetAddress = "Lokha 03", City = "JNK", State = "Karnali", PhoneNumber = "354i0112175", PostalCode = "5675" }
              );
            modelBuilder.Entity<Product>().HasData(
        new Product
        {
            Id = 1,
            Title = "Fortune of Time",
            Author = "Billy Spark",
            Description = "Praesent vitae sodales libero. Praesent molestie.",
            ISBN = "SWD9999001",
            ListPrice = 99,
            Price = 90,
            Price50 = 85,
            Price100 = 80,
            CategoryId=1
        },
        new Product
        {
            Id = 2,
            Title = "Future of Earth",
            Author = "Jane Doe",
            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
            ISBN = "SWD9999002",
            ListPrice = 120,
            Price = 110,
            Price50 = 105,
            Price100 = 100,
            CategoryId = 2
        },
        new Product
        {
            Id = 3,
            Title = "Secrets of the Universe",
            Author = "John Smith",
            Description = "Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
            ISBN = "SWD9999003",
            ListPrice = 89,
            Price = 85,
            Price50 = 80,
            Price100 = 75,
            CategoryId = 3
        },
        new Product
        {
            Id = 4,
            Title = "The Hidden Truth",
            Author = "Alice Johnson",
            Description = "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris.",
            ISBN = "SWD9999004",
            ListPrice = 95,
            Price = 90,
            Price50 = 85,
            Price100 = 80,
            CategoryId = 1
        },
        new Product
        {
            Id = 5,
            Title = "Adventures in Coding",
            Author = "Michael Brown",
            Description = "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore.",
            ISBN = "SWD9999005",
            ListPrice = 150,
            Price = 140,
            Price50 = 135,
            Price100 = 130,
            CategoryId = 2
        },
        new Product
        {
            Id = 6,
            Title = "Mastering .NET",
            Author = "Chris Green",
            Description = "Excepteur sint occaecat cupidatat non proident, sunt in culpa.",
            ISBN = "SWD9999006",
            ListPrice = 200,
            Price = 190,
            Price50 = 185,
            Price100 = 180,
            CategoryId = 3
        },
        new Product
        {
            Id = 7,
            Title = "Journey to the Stars",
            Author = "Emily White",
            Description = "Proin eget tortor risus. Donec sollicitudin molestie malesuada.",
            ISBN = "SWD9999007",
            ListPrice = 110,
            Price = 100,
            Price50 = 95,
            Price100 = 90,
            CategoryId=1
        },
        new Product
        {
            Id = 8,
            Title = "Data Structures Unleashed",
            Author = "Robert Black",
            Description = "Vestibulum ac diam sit amet quam vehicula elementum.",
            ISBN = "SWD9999008",
            ListPrice = 130,
            Price = 120,
            Price50 = 115,
            Price100 = 110,
            CategoryId = 2
        },
        new Product
        {
            Id = 9,
            Title = "Artificial Intelligence Basics",
            Author = "Sophia Blue",
            Description = "Pellentesque in ipsum id orci porta dapibus.",
            ISBN = "SWD9999009",
            ListPrice = 175,
            Price = 165,
            Price50 = 160,
            Price100 = 155,
            CategoryId = 3
        },
        new Product
        {
            Id = 10,
            Title = "The Art of Problem Solving",
            Author = "Ethan Gray",
            Description = "Curabitur aliquet quam id dui posuere blandit.",
            ISBN = "SWD9999010",
            ListPrice = 140,
            Price = 130,
            Price50 = 125,
            Price100 = 120,
            CategoryId = 1
        }
    );
            
        }

    }
}
