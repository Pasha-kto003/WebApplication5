using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Models
{
    public class PayCard
    {
        public int ID { get; set; }
        public long Number { get; set; }
        public string Name_On_Card { get; set; }
        public int CVV { get; set; }
        public DateTime ExpDate { get; set; }
    }
}
