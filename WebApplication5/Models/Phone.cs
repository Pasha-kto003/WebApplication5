using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Models
{
    public class Phone
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public decimal Price { get; set; }
        public string OS { get; set; }
        public int Memory { get; set; }
        public string Screen_resolution { get; set; }
        public string Camera_resolution { get; set; }
        public string Description { get; set; }
        public int YearOfRelease { get; set; }
        public string Country { get; set; }
        public string Garanty { get; set; }
        public int Diagonal { get; set; }
        public string Processor { get; set; }
        public int Count_kernels { get; set; }
        public int Bluetooth { get; set; }
        public string NFC { get; set; }
        public int Battery_Capacity { get; set; }
        public string PhotoPath { get; set; }
        public string Complect { get; set; }
    }
}
