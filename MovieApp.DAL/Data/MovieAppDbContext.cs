using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MovieApp.DAL.Models;

namespace MovieApp.DAL.Data
{
    public class MovieAppDbContext:DbContext
    {
        public DbSet<Director> Directors { get; set; }
        //public MovieAppDbContext(DbContextOptions<MovieAppDbContext> options) : base(options)
        //{
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=MovieAppDb;Trusted_Connection=True;TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MovieAppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
        
    }
}
