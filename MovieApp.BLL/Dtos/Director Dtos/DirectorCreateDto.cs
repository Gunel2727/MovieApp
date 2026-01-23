using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.BLL.Dtos.Director_Dtos
{
    public class DirectorCreateDto
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string? City { get; set; }
        public int Age { get; set; }
        public string? Region { get; set; }
    }
}
