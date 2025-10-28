// Интерфейс сервиса
using System.Collections.Generic;
using System.Net.Http.Json;

public interface IProductService
{
    Task<List<Product>> GetProductsAsync();
    Task<Product> GetProductByIdAsync(int id);
    Task AddProductAsync(Product product);
}

// Реализация сервиса
public class ProductService : IProductService
{
    private readonly HttpClient _httpClient;

    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task AddProductAsync(Product product)
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetProductByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Product>> GetProductsAsync()
    {
        try
        {
            // Создаем тестовые товары
            List<Product> products = new List<Product>
        {
            new Product { Id = 1, ImageUrl = "images/tea.jpg", Name = "Чай зелёный, 300 г", Price = "434P" },
            new Product { Id = 2, ImageUrl = "images/coffee.jpg", Name = "Кофе молотый, 250 г", Price = "567P" },
            new Product { Id = 3, ImageUrl = "images/honey.jpg", Name = "Мёд цветочный, 500 г", Price = "789P" },
             new Product { Id = 4, ImageUrl = "images/honey.jpg", Name = "Мёд цветочный, 5650 г", Price = "71289P" },
             new Product { Id = 4, ImageUrl = "images/honey.jpg", Name = "Мёд цветочный, 5650 г", Price = "71289P" },
             new Product { Id = 4, ImageUrl = "images/honey.jpg", Name = "Мёд цветочный, 5650 г", Price = "71289P" },
             new Product { Id = 4, ImageUrl = "images/honey.jpg", Name = "Мёд цветочный, 5650 г", Price = "71289P" },
             new Product { Id = 4, ImageUrl = "images/honey.jpg", Name = "Мёд цветочный, 5650 г", Price = "71289P" },
             new Product { Id = 4, ImageUrl = "images/honey.jpg", Name = "Мёд цветочный, 5650 г", Price = "71289P" },
             new Product { Id = 4, ImageUrl = "images/honey.jpg", Name = "Мёд цветочный, 5650 г", Price = "71289P" },
             new Product { Id = 4, ImageUrl = "images/honey.jpg", Name = "Мёд цветочный, 5650 г", Price = "71289P" },
             new Product { Id = 4, ImageUrl = "images/honey.jpg", Name = "Мёд цветочный, 5650 г", Price = "71289P" },
             new Product { Id = 4, ImageUrl = "images/honey.jpg", Name = "Мёд цветочный, 5650 г", Price = "71289P" },
             new Product { Id = 4, ImageUrl = "images/honey.jpg", Name = "Мёд цветочный, 5650 г", Price = "71289P" },
             new Product { Id = 4, ImageUrl = "images/honey.jpg", Name = "Мёд цветочный, 5650 г", Price = "71289P" },
             new Product { Id = 4, ImageUrl = "images/honey.jpg", Name = "Мёд цветочный, 5650 г", Price = "71289P" },
             new Product { Id = 4, ImageUrl = "images/honey.jpg", Name = "Мёд цветочный, 5650 г", Price = "71289P" },
             new Product { Id = 4, ImageUrl = "images/honey.jpg", Name = "Мёд цветочный, 5650 г", Price = "71289P" },
             new Product { Id = 4, ImageUrl = "images/honey.jpg", Name = "Мёд цветочный, 5650 г", Price = "71289P" },
             new Product { Id = 4, ImageUrl = "images/honey.jpg", Name = "Мёд цветочный, 5650 г", Price = "71289P" }

        };

            return await Task.FromResult(products); // Возвращаем тестовые данные
        }
        catch (Exception ex)
        {
            // Логируем ошибку
            Console.WriteLine($"Ошибка: {ex.Message}");
            return new List<Product>();
        }
    }
}