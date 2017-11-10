using MyToDoList.Entities;
using System;
using System.Collections.Generic;
using MyToDoList.Enums;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyToDoList.ViewModels.HomeViewModels
{
    public class CategoryViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        [Required(ErrorMessage ="Kategoria musi mieć nazwe!"),MaxLength(20,ErrorMessage ="Długośc nazwy twojej kategorii to maksymalnie 20 znaków!")]
        public string NewCategoryName { get; set; }
        public IEnumerable<Duty> Duties { get; set; }
        public AmmountOfDoneDutiesArchive Archive { get; set; }


    }
}
