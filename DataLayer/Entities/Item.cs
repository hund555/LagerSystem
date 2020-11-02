using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class Item
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string Discription { get; set; }

        public User User { get; set; }
    }
}
