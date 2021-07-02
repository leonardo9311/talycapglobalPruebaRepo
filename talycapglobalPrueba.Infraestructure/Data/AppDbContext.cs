using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using talycapglobalPrueba.Core.Entities;
using talycapglobalPrueba.Infraestructure.Model;

namespace talycapglobalPrueba.Infraestructure.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>(b => {
                b.HasKey(u => u.Id);

                b.ToTable("Books");
            });
            modelBuilder.Entity<Author>(b => {
                b.HasKey(u => u.Id);

                b.ToTable("Author");
            });

        }
        public DbSet<Author> Author { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
