using System.Collections.Generic;
using Gift_Shop.Entities;

namespace Gift_Shop.Service
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetCategoryProducts(string categoryName, string productName);
        Product GetProduct(int id);
        void CreateProduct(Product product);
        void SaveProduct();
    }
}