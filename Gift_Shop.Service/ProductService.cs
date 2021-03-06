﻿using System;
using System.Collections.Generic;
using System.Linq;
using Gift_Shop.Data.Infrastructure;
using Gift_Shop.Data.Repositories;
using Gift_Shop.Entities;

namespace Gift_Shop.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productsRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IUnitOfWork unitOfWork;

        public ProductService(IProductRepository productsRepository, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            this.productsRepository = productsRepository;
            this.categoryRepository = categoryRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Product> GetProducts()
        {
            var products = productsRepository.GetAll();
            return products;
        }                

        public Product GetProduct(int id)
        {
            var product = productsRepository.GetById(id);
            return product;
        }

        public void CreateProduct(Product product)
        {
            productsRepository.Add(product);
        }

        public void SaveProduct()
        {
            unitOfWork.Commit();
        }

        public void DeleteProduct(int id)
        {
            productsRepository.Delete(a=>a.ProductID == id);
        }   
        
        public void UpdateProduct(Product product)
        {
            productsRepository.Update(product);
        }     
    }
}
