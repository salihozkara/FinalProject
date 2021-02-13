using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal:IProductDal
    {
        private List<Product> _products;

        public InMemoryProductDal()
        {
            _products=new List<Product>
            {
                new Product{ProductId = 1,CategoryId = 1,ProductName = "Bardak",UnitPrice = 15,UnitsInStock = 15},
                new Product{ProductId = 2,CategoryId = 1,ProductName = "Kamera",UnitPrice = 500,UnitsInStock = 3},
                new Product{ProductId = 3,CategoryId = 2,ProductName = "Telefon",UnitPrice = 1500,UnitsInStock = 2},
                new Product{ProductId = 4,CategoryId = 2,ProductName = "Klavye",UnitPrice = 150,UnitsInStock = 65},
                new Product{ProductId = 5,CategoryId = 2,ProductName = "Fare",UnitPrice = 85,UnitsInStock = 1}
            };
        }
        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Add(Product category)
        {
            _products.Add(category);
        }

        public void Update(Product category)
        {
            Product categoryToUpdate = _products.SingleOrDefault(p => p.ProductId == category.ProductId);
            categoryToUpdate.CategoryId = category.CategoryId;
            categoryToUpdate.UnitsInStock = category.UnitsInStock;
            categoryToUpdate.ProductName = category.ProductName;
            categoryToUpdate.UnitPrice = category.UnitPrice;
        }

        public void Delete(Product category)
        {
            Product categoryToDelete = _products.SingleOrDefault(p=>p.ProductId==category.ProductId);
            _products.Remove(categoryToDelete);
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
           return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<ProductDetailDto> GetProductsDetails()
        {
            throw new NotImplementedException();
        }
    }
}
