using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YourFinances.Domain.Entities;
using YourFinances.Domain.Repositories.Abstract;

namespace YourFinances.Domain.Repositories.EntityFramework
{
    public class EFCategoriesRepository : ICategoriesRepository
    {
        private readonly AppDbContext context;

        public EFCategoriesRepository(AppDbContext context)
        {
            this.context = context;
        }
        public IQueryable<Category> GetCategories()
        {
            return context.Categories;
        }
        public Category GetCategoryById(int id)
        {
            return context.Categories.FirstOrDefault(x => x.category_id == id);
        }

        public Category GetCategoryByName(string name)
        {
            return context.Categories.FirstOrDefault(x => x.name == name);
        }

        public void SaveCategory(Category entity)
        {
            if (entity.category_id == default)
            {
                context.Entry(entity).State = EntityState.Added;
            }
            else
            {
                context.Entry(entity).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            context.Categories.Remove(new Category() { category_id = id });
            context.SaveChanges();
        }
    }
}
