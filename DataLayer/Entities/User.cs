using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities
{
    public class User
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Du skal angive et navn")]
        public string Name { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}
