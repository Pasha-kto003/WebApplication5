using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Models
{
    public class Phone
    {
        public int ID { get; set; }
        public string Model { get; set; }
        public string Company { get; set; }
        public decimal Price { get; set; }
        public string OS { get; set; }
        public string Description { get; set; }
        public int YearOfRelease { get; set; }
        //public string Country { get; set; }
        //public int Garanty { get; set; }

    }
}
