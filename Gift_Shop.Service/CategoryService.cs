using System;
using System.Collections.Generic;
using System.Linq;
using Gift_Shop.Data.Infrastructure;
using Gift_Shop.Data.Repositories;
using Gift_Shop.Entities;

namespace Gift_Shop.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IUnitOfWork unitOfWork;

        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            this.categoryRepository = categoryRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Category> GetCategories()
        {
            var category = categoryRepository.GetAll();
            return category;
        }

        public Category GetCategory(int id)
        {
            var category = categoryRepository.GetById(id);
            return category;
        }

        public Category GetCategory(string name)
        {
            var category = categoryRepository.GetCategoryByName(name);
            return category;
        }

        public void CreateCategory(Category category)
        {
            categoryRepository.Add(category);
        }

        public void SaveCategory()
        {
            unitOfWork.Commit();
        }
    }
}
