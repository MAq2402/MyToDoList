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
        private IDutyRepository _dutyRepository;

        public CategoryViewComponent(ICategoryRepository categoryRepository,IDutyRepository dutyRepository)
        {
            _categoryRepository = categoryRepository;
            _dutyRepository = dutyRepository;
        }
        public IViewComponentResult Invoke()
        {
            var model = new CategoryViewModel()
            {
                Duties = _dutyRepository.Duties,
                Categories = _categoryRepository.Categories
            };

            return View(model);
        }
    }
}
