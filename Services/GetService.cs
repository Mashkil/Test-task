using Microsoft.EntityFrameworkCore;
using Test_task.Data;

namespace Test_task.Services
{

    public class GetService
    {
        private readonly ContextDB _dbcontext;

        public GetService(ContextDB contextDB)
        {
            _dbcontext = contextDB;
        }

        public async Task<List<OutputObject>> GetJoinedProductsAndCategories(string nameOfCategory)
        {
            if (!await _dbcontext.Categories.AnyAsync(e => e.Name == nameOfCategory))
                return new List<OutputObject>()
                {
                    new OutputObject()
                    {
                        NameOfCategory = $"Категории {nameOfCategory} не существует"
                    }
                };


            var productsAndCategories = await _dbcontext.Categories
                .Where(e => e.Name == nameOfCategory)
                .Join(_dbcontext.Products, p => p.Id, c => c.CategoryId, (p, c) => new OutputObject
                {
                    NameOfProduct = c.Name,
                    Description = c.Description,
                    NameOfCategory = p.Name,
                    Price = c.Price
                })
                .ToListAsync();

            if (productsAndCategories.Count == 0)
                return new List<OutputObject>()
                {
                    new OutputObject()
                    {
                        NameOfCategory = $"Товары в категории {nameOfCategory} не найдены"
                    }
                };

            return productsAndCategories;
        }
    }
}
