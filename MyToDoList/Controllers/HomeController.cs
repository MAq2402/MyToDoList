using Microsoft.AspNetCore.Mvc;
using MyToDoList.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDoList.Controllers
{
    public class HomeController:Controller
    {
        private IDutyRepository _dutyRepository;

        public HomeController(IDutyRepository dutyRepository)
        {
            _dutyRepository = dutyRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddDuty()
        {
            
        }
    }
}
