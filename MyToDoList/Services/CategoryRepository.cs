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
        public IEnumerable<Category> Categories => throw new NotImplementedException();
    }
}
