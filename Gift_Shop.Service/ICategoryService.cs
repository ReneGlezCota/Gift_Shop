using System.Collections.Generic;
using Gift_Shop.Entities;

namespace Gift_Shop.Service
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories();
        Category GetCategory(int id);
        void CreateCategory(Category category);
        void SaveCategory();
    }
}