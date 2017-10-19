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
        IEnumerable<Category> Categories { get; }
    }
    public class CategoryRepository : ICategoryRepository
    {
        private MyToDoListDbContext _context;

        public CategoryRepository(MyToDoListDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Category> Categories => _context.Categories.Include(c => c.Duties);
    }
}
