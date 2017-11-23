using MyToDoList.Entities;
using MyToDoList.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDoList.ViewModels.HomeViewModels
{
    public class DayViewModel
    {
        public IEnumerable<Duty> Duties { get; set; }
        public IEnumerable<Category> Categories { get; set; }

        [Required(ErrorMessage ="Twoje zadanie nie zawiera żadnej treści!"),MaxLength(20,ErrorMessage ="Maksymalna długość treści twojego zadania wynosi 20 znaków!")]
        public string Content { get; set; }
        public int DutyCategoryId { get; set; }
  
    }
}
