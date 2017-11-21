using Microsoft.AspNetCore.Mvc;
using MyToDoList.Entities;
using MyToDoList.Enums;
using MyToDoList.Models;
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
        [HttpGet]
        [ImportModelState]
        public IActionResult Index(int id)
        {
            var category = _categoryRepository.GetCategory(id);

            if(category==null)
            {
                throw new Exception("No such category");
            }

            var model = new IndexViewModel()
            {
                Category = category
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult RemoveDuty(string CategoryId,int DutyId)
        {
            var duty = _dutyRepository.GetDuty(DutyId);

            if(duty==null)
            {
                throw new Exception("No such duty");
            }

            _dutyRepository.RemoveDuty(duty);

            _dbContextService.Commit();

            return RedirectToAction("Index", "Category",new {id=CategoryId });
        }
        [HttpPost]
        public IActionResult RemoveAllDuties(int id)
        {
            var category = _categoryRepository.GetCategory(id);

            if(category==null)
            {
                throw new Exception("No such category");
            }

            category.Duties.Clear();

            _dbContextService.Commit();

            return RedirectToAction("Index", "Category", new { id = id });
        }
        [HttpPost]
        public IActionResult RemoveCategory(int id)
        {
            var category = _categoryRepository.GetCategory(id);

            if (category == null)
            {
                throw new Exception("No such category");
            }

            category.Duties.Clear();

            _dbContextService.RemoveCategory(category);
            _dbContextService.Commit();

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ExportModelState]
        public IActionResult AddDuty(string StringDay, IndexViewModel model)
        {
            if(String.IsNullOrEmpty(model.NewDutyContent))
            {
                ModelState.AddModelError("","Twoje zadanie nie zawiera żadnej treści!");
                return RedirectToAction("Index", "Category", new { id = model.CategoryId });
            }
            if(model.NewDutyContent.Length>20)
            {
                ModelState.AddModelError("", "Maksymalna długość treści twojego zadania wynosi 20 znaków!");
                return RedirectToAction("Index", "Category", new { id = model.CategoryId });
            }

            Day DayForCreate = Day.Monday;
            bool StringDayMatchedFlag = false;

            foreach(Day day in Enum.GetValues(typeof(Day)))
            {
                if(day.ToString()==StringDay)
                {
                    DayForCreate = day;
                    StringDayMatchedFlag = true;
                    break;
                }
            }
            
            if(!StringDayMatchedFlag)
            {
                throw new Exception("StringDay hasn't matched");
            }

            var category = _categoryRepository.GetCategory(Int32.Parse(model.CategoryId));

            if (category == null)
            {
                throw new Exception("No such category");
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
        [HttpPost]
        [ExportModelState]
        public IActionResult ChangeCategoryName(int id,IndexViewModel model)
        {
           if(String.IsNullOrEmpty(model.CategoryNewName))
           {
                ModelState.AddModelError("", "Kategoria musi mieć nazwe!");
                return RedirectToAction("Index", "Category", new { id = id });
           }

           if(model.CategoryNewName.Length>20)
           {
                ModelState.AddModelError("", "Długośc nazwy twojej kategorii to maksymalnie 20 znaków!");
                return RedirectToAction("Index", "Category", new { id = id });
           }

            var category = _categoryRepository.GetCategory(id);

            if (category == null)
            {
                throw new Exception("No such category");
            }

            category.Name = model.CategoryNewName;

            _dbContextService.Commit();

            return RedirectToAction("Index", "Category",new { id = id });
        }
    }
}
