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
        
        public string NewDutyContent { get; set; }

        public string CategoryId { get; set; }

        public string CategoryNewName { get; set; }
    }
}
