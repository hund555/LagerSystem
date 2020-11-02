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

        public Item GetItemById(int itemId)
        {
            return _context.Items
                .Find(itemId);
        }

        public IQueryable<Item> GetUsersItems(User user)
        {
            return _context.Items
                .Where(i => i.User == user)
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
            User user = _context.Users.Find(userId);

            _context.Users.Remove(user);

            await _context.SaveChangesAsync();
        }
    }
}
