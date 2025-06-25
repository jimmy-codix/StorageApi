using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using StorageApi.Models;

namespace StorageApi.Data
{
    public class StorageApiContext : DbContext
    {
        public StorageApiContext (DbContextOptions<StorageApiContext> options)
            : base(options)
        {
        }

        public DbSet<StorageApi.Models.Product> Product { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product { Id=1, Name="Chair", Category="Furniture", Count=1, Description="Nice chair.", Price=100, Shelf="A2"},
                new Product { Id=2, Name="Tire", Category="Vehicle", Count=5, Description="Goodyear Tire.", Price=500, Shelf="F1"},
                new Product { Id=3, Name="Shirt", Category="Clothes", Count=5, Description="Blue shirt.", Price=25, Shelf="Q8"},
                new Product { Id=4, Name="Jacket", Category="Clothes", Count=10, Description="Black jacket.", Price=350, Shelf="Q9"},
                new Product { Id=5, Name="Dog whistle", Category="Animals", Count=100, Description="A whistle for your dog.", Price=10, Shelf="B12"}
            );
        }
    }
}
