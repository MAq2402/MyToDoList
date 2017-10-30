using MyToDoList.DbContexts;
using MyToDoList.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDoList.Services
{
    public interface IDbContextService
    {
        void Commit();

        void RemoveCategory(Category category);
    }
    public class DbContextService : IDbContextService
    {
        private MyToDoListDbContext _context;

        public DbContextService(MyToDoListDbContext context)
        {
            _context = context;
        }
        public void Commit()
        {

            _context.SaveChanges();
        }

        public void RemoveCategory(Category category)
        {
            _context.Categories.Remove(category);
        }
    }
}
