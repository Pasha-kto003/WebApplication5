using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Models
{
    public class Buy
    {
        public int ID { get; set; }
        public int PhoneID { get; set; }
        public Phone Phone { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public DateTime DateBuy { get; set; } = DateTime.Now;
    }
}
