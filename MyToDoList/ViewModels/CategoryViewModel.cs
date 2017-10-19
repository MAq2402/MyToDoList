using MyToDoList.Entities;
using System;
using System.Collections.Generic;
using MyToDoList.Enums;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDoList.ViewModels
{
    public class CategoryViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public string CategoryName { get; set; }
        public Color Color { get; set; }
    }
}
