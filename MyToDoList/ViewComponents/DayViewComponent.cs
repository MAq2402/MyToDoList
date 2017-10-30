using Microsoft.AspNetCore.Mvc;
using MyToDoList.Enums;
using MyToDoList.Services;
using MyToDoList.ViewModels.HomeViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDoList.ViewComponents
{
    public class DayViewComponent:ViewComponent
    {
        private ICategoryRepository _categoryRepository;
        private IDutyRepository _dutyReposiotory;


        public DayViewComponent(IDutyRepository dutyRepository,ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _dutyReposiotory = dutyRepository;
        }
        public IViewComponentResult Invoke()
        {
            var model = new DayViewModel()
            {
                Duties = _dutyReposiotory.Duties,
                Categories = _categoryRepository.Categories
            };            
            return View(model);
        }
    }
}
