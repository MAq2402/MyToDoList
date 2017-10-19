using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MyToDoList.Entities;
using MyToDoList.Enums;
using MyToDoList.Services;
using MyToDoList.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDoList.Controllers
{
    public class HomeController:Controller
    {
        private IDbContextService _dbContextService;
        private IDutyRepository _dutyRepository;

        public HomeController(IDutyRepository dutyRepository,IDbContextService dbContextService)
        {
            _dutyRepository = dutyRepository;
            _dbContextService = dbContextService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string StringDay,DayViewModel model)
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

            var newDuty = new Duty()
            {
                Content = model.Content,
                Day = DayForCreate,
                Category = null
                
            };

            _dutyRepository.AddDuty(newDuty);

            _dbContextService.Commit();

            return RedirectToAction("Index","Home");
        }
    }
}
