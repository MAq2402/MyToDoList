using MyToDoList.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDoList.ViewModels.CategoryViewModels

{
    public class IndexViewModel
    {
        public Category Category { get; set; }
        [Required(ErrorMessage = "Twoje zadanie nie zawiera żadnej treści!"), MaxLength(20, ErrorMessage = "Maksymalna długość treści twojego zadania wynosi 20 znaków!")]
        public string NewDutyContent { get; set; }

        public string CategoryId { get; set; }
        [Required(ErrorMessage = "Kategoria musi mieć nazwe!"), MaxLength(20, ErrorMessage = "Długośc nazwy twojej kategorii to maksymalnie 20 znaków!")]
        public string CategoryNewName { get; set; }
    }
}
