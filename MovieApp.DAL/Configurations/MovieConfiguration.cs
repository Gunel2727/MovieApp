using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieApp.DAL.Models;

namespace MovieApp.DAL.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable("Movies");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Title)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(m => m.Description)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(m => m.ReleaseYear)
                .IsRequired();
            builder.Property(m => m.Duration)
                .IsRequired();
            builder.Property(m => m.Imdb)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.HasOne(m => m.Director)
                .WithMany(d => d.Movies)
                .HasForeignKey(m => m.DirectorId)
                .OnDelete(DeleteBehavior.Cascade);

            
        }
    }
}
