using Microsoft.AspNetCore.Mvc;
using MyToDoList.Services;
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

            return View(category);
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

    }
}
