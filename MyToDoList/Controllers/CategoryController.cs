using Microsoft.AspNetCore.Mvc;
using MyToDoList.Entities;
using MyToDoList.Enums;
using MyToDoList.Services;
using MyToDoList.ViewModels.CategoryViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MyToDoList.Controllers
{
    public class CategoryController:Controller
    {
        private IDbContextService _dbContextService;
        private IDutyRepository _dutyRepository;
        private ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository,IDutyRepository dutyRepository,IDbContextService dbContextService)
        {
            _dbContextService = dbContextService;
            _dutyRepository = dutyRepository;
            _categoryRepository = categoryRepository;
        }
        public IActionResult Index(int id)
        {
            var category = _categoryRepository.GetCategory(id);

            var model = new IndexViewModel()
            {
                Category = category
            };

            return View(model);
        }
        public IActionResult RemoveDuty(string CategoryId,int DutyId)
        {
            _dutyRepository.RemoveDuty(DutyId);

            _dbContextService.Commit();

            return RedirectToAction("Index", "Category",new {id=CategoryId });
        }
        public IActionResult RemoveAllDuties(int id)
        {
            var category = _categoryRepository.GetCategory(id);

            category.Duties.Clear();

            _dbContextService.Commit();

            return RedirectToAction("Index", "Category", new { id = id });
        }
        public IActionResult RemoveCategory(int id)
        {
            var category = _categoryRepository.GetCategory(id);

            category.Duties.Clear();

            _dbContextService.RemoveCategory(category);
            _dbContextService.Commit();

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult AddDuty(string StringDay, IndexViewModel model)
        {
            Day DayForCreate = Day.Monday;

            foreach(Day day in Enum.GetValues(typeof(Day)))
            {
                if(day.ToString()==StringDay)
                {
                    DayForCreate = day;
                    break;
                }
            }

            var category = _categoryRepository.GetCategory(Int32.Parse(model.CategoryId));

            if (category == null)
            {
                throw new Exception("Nie ma takiej kategorii");
            }

            var duty = new Duty()
            {
                Content = model.NewDutyContent,
                Category = category,
                Day = DayForCreate
            };

            _dutyRepository.AddDuty(duty);

            _dbContextService.Commit();

            return RedirectToAction("Index", "Category", new { id = model.CategoryId });
        }

    }
}
