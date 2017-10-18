using Microsoft.AspNetCore.Mvc;
using MyToDoList.Enums;
using MyToDoList.Services;
using MyToDoList.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDoList.ViewComponents
{
    public class DayViewComponent:ViewComponent
    {
        private IDutyRepository _dutyReposiotory;

        public DayViewComponent(IDutyRepository dutyRepository)
        {
            _dutyReposiotory = dutyRepository;
        }
        public IViewComponentResult Invoke()
        {
            var model = new DayViewModel()
            {
                Duties = _dutyReposiotory.Duties
            };            
            return View(model);
        }
    }
}
