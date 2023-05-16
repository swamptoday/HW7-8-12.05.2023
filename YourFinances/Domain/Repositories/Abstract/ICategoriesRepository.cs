using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourFinances.Domain.Entities;

namespace YourFinances.Domain.Repositories.Abstract
{
    public interface ICategoriesRepository
    {
        IQueryable<Category> GetCategories();
        Category GetCategoryById(int id);
        Category GetCategoryByName(string name);
        void SaveCategory(Category entity);
        void DeleteCategory(int id);
    }
}
