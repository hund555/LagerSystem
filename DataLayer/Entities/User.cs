﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}
