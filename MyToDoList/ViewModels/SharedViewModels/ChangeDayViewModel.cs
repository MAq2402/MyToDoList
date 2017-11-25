using MyToDoList.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDoList.ViewModels.SharedViewModels
{
    public class ChangeDayViewModel
    {
        public Day Day { get; set; }
        public int DutyId { get; set; }
        public string DayNameToDisplay { get; set; }
    }
}
