using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MovieApp.BLL.Dtos.Director_Dtos;
using MovieApp.DAL.Models;

namespace MovieApp.BLL.Profiles
{
    public class DirectorMapper
    {
        public static DirectorReturnDto ToDirectorReturnDto(Director director) =>
            new DirectorReturnDto
            {
                Name = director.Name,
                Description = director.Description,
                City = director.City,
                Address = director.Address,
                Age = director.Age,
                Region = director.Region,
            };
        public static Director ToDirector(DirectorCreateDto directorCreateDto) =>
            new Director
            {
                Name = directorCreateDto.Name,
                Description = directorCreateDto.Description,
                City = directorCreateDto.City,
                Address = directorCreateDto.Address,
                Age = directorCreateDto.Age,
                Region = directorCreateDto.Region,
            };
    }
}
