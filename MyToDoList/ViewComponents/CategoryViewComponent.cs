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
        private IAmmountOfDoneDutiesArchiveRepository _ammountOfDoneDutiesArchiveRepository;

        public CategoryViewComponent(
            ICategoryRepository categoryRepository,
            IDutyRepository dutyRepository,
            IAmmountOfDoneDutiesArchiveRepository ammountOfDoneDutiesArchiveRepository)
        {
            _categoryRepository = categoryRepository;
            _dutyRepository = dutyRepository;
            _ammountOfDoneDutiesArchiveRepository = ammountOfDoneDutiesArchiveRepository;
        }
        public IViewComponentResult Invoke()
        {
            var model = new CategoryViewModel()
            {
                Duties = _dutyRepository.Duties,
                Categories = _categoryRepository.Categories,
                Archive = _ammountOfDoneDutiesArchiveRepository.GetArchive()
            };

            return View(model);
        }
    }
}
