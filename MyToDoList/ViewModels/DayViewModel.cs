using MyToDoList.Entities;
using MyToDoList.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDoList.ViewModels
{
    public class DayViewModel
    {
        public IEnumerable<Duty> Duties { get; set; }
    }
}
