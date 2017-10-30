using MyToDoList.Entities;
using System;
using System.Collections.Generic;
using MyToDoList.Enums;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyToDoList.ViewModels.HomeViewModels
{
    public class CategoryViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        [Required(ErrorMessage ="Kategoria musi mieć nazwe")]
        public string NewCategoryName { get; set; }

    }
}
