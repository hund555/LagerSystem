using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entities
{
    public class Item
    {
        public int ItemId { get; set; }

        [Required(ErrorMessage = "Du skal angive et navn")]
        public string ItemName { get; set; }
        public string Discription { get; set; }
        public int? UserId { get; set; }

        public User User { get; set; }
    }
}
