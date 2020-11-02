using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer
{
    public class LagerService
    {
        private readonly LagerContext _context;
        public LagerService(LagerContext context)
        {
            _context = context;
        }

        public IQueryable<Item> GetAllItems()
        {
            return _context.Items
                .AsNoTracking();
        }
    }
}
