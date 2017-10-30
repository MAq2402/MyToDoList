using Microsoft.AspNetCore.Mvc;
using MyToDoList.Services;
using MyToDoList.ViewModels.HomeViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDoList.ViewComponents
{
    public class CategoryViewComponent:ViewComponent
    {
        private ICategoryRepository _categoryRepository;

        public CategoryViewComponent(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IViewComponentResult Invoke()
        {
            var model = new CategoryViewModel()
            {
                Categories = _categoryRepository.Categories
            };

            return View(model);
        }
    }
}
