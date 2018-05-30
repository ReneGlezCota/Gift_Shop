using System.Collections.Generic;
using Gift_Shop.Entities;

namespace Gift_Shop.Service
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories();
        IEnumerable<Category> GetCategories(string name = null);
        Category GetCategory(int id);
        Category GetCategory(string name);
        void CreateCategory(Category category);
        void SaveCategory();
    }
}