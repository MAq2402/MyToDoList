using MyToDoList.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDoList.ViewModels.HomeViewModels
{
    public class IndexViewModel
    {
        public CurrentWeek CurrentWeek { get; set; }
        public IEnumerable<OverdueDuty> OverdueDuties { get; set; }
    }
}
