using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogisticInventorySystem.Models
{
    public class Item
    {
        public int ID { get; set; }
        public int ItemID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int Quantity { get; set; }
        public string ImageURL { get; set; }
    }
}
