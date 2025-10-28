using System;
using System.Collections.Generic;
using System.Linq;

namespace AutomathetionService.Services
{
    public class ProductService
    {
        public List<Product> Products { get; set; } = new();
        private int nextId = 1;

        public ProductService()
        {
            // Тестовые данные
            GenerateSampleProducts();
        }

        public void AddProduct(Product product)
        {
            product.Id = nextId++;
            product.CreatedAt = DateTime.Now;
            product.UpdatedAt = DateTime.Now;
            Products.Add(product);
        }

        public void UpdateProduct(Product updatedProduct)
        {
            var existingProduct = Products.FirstOrDefault(p => p.Id == updatedProduct.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = updatedProduct.Name;
                existingProduct.Description = updatedProduct.Description;
                existingProduct.Category = updatedProduct.Category;
                existingProduct.Subcategory = updatedProduct.Subcategory;
                existingProduct.Price = updatedProduct.Price;
                existingProduct.Stock = updatedProduct.Stock;
                existingProduct.ImageUrl = updatedProduct.ImageUrl;
                existingProduct.UpdatedAt = DateTime.Now;
            }
        }

        public void DeleteProduct(int productId)
        {
            var product = Products.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                Products.Remove(product);
            }
        }

        private void GenerateSampleProducts()
        {
            AddProduct(new Product
            {
                Name = "Смартфон Samsung Galaxy",
                Description = "Новый смартфон с отличной камерой",
                Category = "electronics",
                Subcategory = "smartphones",
                Price = 29999,
                Stock = 15
            });

            AddProduct(new Product
            {
                Name = "Футболка мужская",
                Description = "Хлопковая футболка премиум качества",
                Category = "clothing",
                Subcategory = "mens",
                Price = 1999,
                Stock = 50
            });
        }
    }

    // Класс Product должен быть определен в том же пространстве имен
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Subcategory { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string ImageUrl { get; set; } = "images/tovar.jpg";
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}