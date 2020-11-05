using DataLayer.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public interface ILagerService
    {
        Task<int> CreateNewItem(Item newItem);
        Task<int> CreateNewUser(User newUser);
        Task DeleteItem(int itemId);
        Task DeleteUser(int userId);
        IQueryable<Item> GetAllItemsInStorege();
        IQueryable<Item> GetItemsNotInStorege();
        IQueryable<User> GetAllUsers();
        Item GetItemById(int itemId);
        User GetUserById(int userId);
        IQueryable<Item> GetUsersItems(int userId);
        Task BorrowItems(List<int> itemIdList, int userId);
        Task ReturnItem(int itemId);
        Task ReturnAllItems(List<int> itemIdList);
        Task<Item> UpdateItem(Item updateItem);
        Task<User> UpdateUser(User updatedUser);
    }
}