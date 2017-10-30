using Microsoft.EntityFrameworkCore;
using MyToDoList.DbContexts;
using MyToDoList.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDoList.Services
{
    public interface ICategoryRepository
    {
        void AddCategory(Category newCategory);
        IEnumerable<Category> Categories { get; }
        Category GetCategory(int id);
    }
    public class CategoryRepository : ICategoryRepository
    {
        private MyToDoListDbContext _context;

        public CategoryRepository(MyToDoListDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Category> Categories => _context.Categories.Include(c => c.Duties);

        public void AddCategory(Category newCategory)
        {
            _context.Add(newCategory);
        }

        public Category GetCategory(int id)
        {
            return Categories.FirstOrDefault(x => x.Id==id);
        }
    }
}
