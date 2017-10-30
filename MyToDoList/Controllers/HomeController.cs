using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MyToDoList.Entities;
using MyToDoList.Enums;
using MyToDoList.Services;
using MyToDoList.ViewModels.HomeViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDoList.Controllers
{
    public class HomeController:Controller
    {
        private IDbContextService _dbContextService;
        private ICategoryRepository _categoryRepository;
        private IDutyRepository _dutyRepository;

        public HomeController(IDutyRepository dutyRepository,ICategoryRepository categoryRepository,IDbContextService dbContextService)
        {
            _dutyRepository = dutyRepository;
            _dbContextService = dbContextService;
            _categoryRepository = categoryRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDuty(string StringDay,DayViewModel model)
        {

            Day DayForCreate=Day.Monday;

            foreach(Day day in Enum.GetValues(typeof(Day)))
            {
                if(StringDay==day.ToString())
                {
                    DayForCreate = day;
                    break;
                }
            }

            var category = _categoryRepository.GetCategory(model.DutyCategoryId);

            if(category==null)
            {
                throw new Exception("Nie ma takiej kategorii");
            }

            var newDuty = new Duty()
            {
                Content = model.Content,
                Day = DayForCreate,
                Category = category
                
            };
            

            _dutyRepository.AddDuty(newDuty);

            _dbContextService.Commit();

            return RedirectToAction("Index","Home");
        }
        [HttpPost]
        public IActionResult AddCategory(CategoryViewModel model)
        {
            var newCategory = new Category()
            {
                Name = model.NewCategoryName
            };

            _categoryRepository.AddCategory(newCategory);

            _dbContextService.Commit();

            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public IActionResult RemoveDuty(int id)
        {
            _dutyRepository.RemoveDuty(id);

            _dbContextService.Commit();

            return RedirectToAction("Index", "Home");
        }


    }
}
