using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Data.Edm.Library;
using MyToDoList.Entities;
using MyToDoList.Enums;
using MyToDoList.Models;
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
        [ImportModelState]
        public IActionResult Index()
        {
            var model = new IndexViewModel()
            {
                Duties = _dutyRepository.Duties,
                Categories = _categoryRepository.Categories
            };
            return View(model);

        }

        [HttpPost]
        [ExportModelState]
      
        public IActionResult AddDuty(string StringDay,DayViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }

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

                ModelState.AddModelError("", "Każde zadanie musi przynależeć do kategorii. Stwórz nową kategorię, a następnie dodaj do niej zadanie.");
                return RedirectToAction("Index", "Home");
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
        [ExportModelState]
        public IActionResult AddCategory(CategoryViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }
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
