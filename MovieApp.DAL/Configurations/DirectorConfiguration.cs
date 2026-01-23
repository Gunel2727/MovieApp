using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieApp.DAL.Models;

namespace MovieApp.DAL.Configurations
{
    public class DirectorConfiguration : IEntityTypeConfiguration<Director>
    {
        public void Configure(EntityTypeBuilder<Director> builder)
        {
            builder.ToTable("Directors");
            builder.HasKey(d=>d.Id);
            builder.Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(d => d.Description)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(d=>d.Address)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(d => d.City)
                .IsRequired(false);

            builder.Property(d=>d.Age)
                .IsRequired();

            builder.Property(d=>d.Region)
                .IsRequired(false);

            builder.HasIndex(d=>d.Name)
                .IsUnique();

            builder.HasData
                (
                new Director
                {
                    Id=1,
                    Name="Steven Spielberg",
                    Description="An American filmmaker known for his work in blockbuster films",
                    Address="100 Hollywood Blvd,Los Angeles,CA",
                    City="Los Angeles",
                    Age=74
                },
                new Director 
                {
                    Id = 2,
                    Name = "Christopher Nolan",
                    Description = "A British-American film director known for complex storytelling",
                    Address = "200 Sunset Blvd, Los Angeles, CA",
                    City = "Los Angeles",
                    Age = 53
                },
                new Director
                {
                    Id = 3,
                    Name = "Quentin Tarantino",
                    Description = "An American filmmaker famous for non-linear narratives",
                    Address = "300 Vine St, Hollywood, CA",
                    City = "Hollywood",
                    Age = 60

                },
                new Director
                {
                    Id = 4,
                    Name = "Martin Scorsese",
                    Description = "An American director known for crime and drama films",
                    Address = "400 Broadway, New York, NY",
                    City = "New York",
                    Age = 81

                }

                );
             
        }
    }
}
