using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class LagerService : ILagerService
    {
        private readonly LagerContext _context;
        public LagerService(LagerContext context)
        {
            _context = context;
        }

        public IQueryable<Item> GetAllItemsInStorege()
        {
            return _context.Items
                .Where(u => u.UserId == null)
                .AsNoTracking();
        }

        public IQueryable<Item> GetItemsNotInStorege()
        {
            return _context.Items
                .Where(u => u.UserId != null)
                .Include(u => u.User)
                .AsNoTracking();
        }

        public Item GetItemById(int itemId)
        {
            return _context.Items
                .Find(itemId);
        }

        public IQueryable<Item> GetUsersItems(int userId)
        {
            return _context.Items
                .Where(i => i.UserId == userId)
                .Include(u => u.User)
                .AsNoTracking();
        }

        public async Task<int> CreateNewItem(Item newItem)
        {
            _context.Items.Add(newItem);

            await _context.SaveChangesAsync();

            return 0;
        }

        public async Task<Item> UpdateItem(Item updateItem)
        {
            _context.Items.Update(updateItem);

            await _context.SaveChangesAsync();

            return updateItem;
        }

        public async Task BorrowItems(List<int> itemIdList, int userId)
        {
            List<Item> items = new List<Item>();
            foreach (int itemId in itemIdList)
            {
                items.Add(await _context.Items
                    .FindAsync(itemId));
            }

            if (items.Any())
            {
                foreach (Item item in items)
                {
                    item.UserId = userId;
                }
            }
            
            _context.Items.UpdateRange(items);
            await _context.SaveChangesAsync();
        }

        public async Task ReturnItem(int itemId)
        {
            Item item = await _context.Items
                .FindAsync(itemId);

            if (item != null)
            {
                item.UserId = null;
            }

            _context.Items.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task ReturnAllItems(List<int> itemIdList)
        {
            List<Item> items = new List<Item>();
            foreach (int itemId in itemIdList)
            {
                Item item = await _context.Items
                    .FindAsync(itemId);

                if (item != null)
                {
                    item.UserId = null;
                    items.Add(item);
                }
            }

            _context.Items.UpdateRange(items);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItem(int itemId)
        {
            Item deletedItem = _context.Items.Find(itemId);

            _context.Items.Remove(deletedItem);

            await _context.SaveChangesAsync();
        }

        public IQueryable<User> GetAllUsers()
        {
            return _context.Users
                .AsNoTracking();
        }

        public User GetUserById(int userId)
        {
            return _context.Users
                .Include(i => i.Items)
                .SingleOrDefault(u => u.UserId == userId);
        }

        public async Task<int> CreateNewUser(User newUser)
        {
            _context.Users.Add(newUser);

            await _context.SaveChangesAsync();

            return 0;
        }

        public async Task<User> UpdateUser(User updatedUser)
        {
            _context.Users.Update(updatedUser);

            await _context.SaveChangesAsync();

            return updatedUser;
        }

        public async Task DeleteUser(int userId)
        {
            User user = await _context.Users
                .Include(i => i.Items)
                .FirstOrDefaultAsync(u => u.UserId == userId);

            if (user != null)
            {
                _context.Users.Remove(user);
            }
            
            await _context.SaveChangesAsync();
        }
    }
}
