using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BakerTask.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public IFormFile Photo { get; set; }
        public double Price { get; set; }
        public double Raiting { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
