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

            builder.HasData(
                new Movie
                {
                    Id=1,
                    Title = "Inception",
                    ReleaseYear = new DateTime(2010, 1, 1),
                    Description = "A thief who steals secrets through dreams is given a final mission.",
                    Duration = 148,
                    Imdb = 8.8m,
                    DirectorId = 1
                },
                new Movie
                {
                    Id=2,
                    Title = "The Dark Knight",
                    ReleaseYear = new DateTime(2008, 1, 1),
                    Description = "Batman faces the Joker, a criminal mastermind who spreads chaos.",
                    Duration = 152,
                    Imdb = 9.0m,
                    DirectorId = 1
                },
                new Movie
                {
                    Id=3,
                    Title = "Interstellar",
                    ReleaseYear = new DateTime(2014, 1, 1),
                    Description = "A group of astronauts travel through a wormhole to save humanity.",
                    Duration = 169,
                    Imdb = 8.6m,
                    DirectorId = 2
                },
                new Movie
                {
                    Id=4,
                    Title = "The Shawshank Redemption",
                    ReleaseYear = new DateTime(1994, 1, 1),
                    Description = "Two prisoners form a deep friendship over many years.",
                    Duration = 142,
                    Imdb = 9.3m,
                    DirectorId = 2
                },
                new Movie
                {
                    Id=5,
                    Title = "Forrest Gump",
                    ReleaseYear = new DateTime(1994, 1, 1),
                    Description = "The life story of a simple man with a big heart.",
                    Duration = 142,
                    Imdb = 8.8m,
                    DirectorId = 3
                },
                 new Movie
                 {
                     Id = 6,
                     Title = "The Matrix",
                     ReleaseYear = new DateTime(1999, 1, 1),
                     Description = "A hacker discovers the true nature of his reality and fights against its controllers.",
                     Duration = 136,
                     Imdb = 8.7m,
                     DirectorId = 4
                 }
                );

            
        }
    }
}
