using Microsoft.AspNetCore.Mvc;
using MyToDoList.Enums;
using MyToDoList.Services;
using MyToDoList.ViewModels.SharedViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDoList.ViewComponents
{
    public class ChangeDayViewComponent:ViewComponent
    {
        private IDutyRepository _dutyRepository;

        public ChangeDayViewComponent(IDutyRepository dutyRepository)
        {
            _dutyRepository = dutyRepository;
        }
        public IViewComponentResult Invoke(Day day,int dutyId,string dayNameToDisplay)
        {

            var model = new ChangeDayViewModel()
            {
                DutyId = dutyId,
                Day = day,
                DayNameToDisplay = dayNameToDisplay

            };


            return View(model);
        }
    }
}
