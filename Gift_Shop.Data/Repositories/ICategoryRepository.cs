﻿using Gift_Shop.Data.Infrastructure;
using Gift_Shop.Entities;

namespace Gift_Shop.Data.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Category GetCategoryByName(string categoryName);
    }
}