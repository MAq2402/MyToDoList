using MyToDoList.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDoList.Entities
{
    public class Category
    {
        public Category()
        {
            Duties = new List<Duty>();
            OverdueDuties = new List<OverdueDuty>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Duty> Duties { get; set; }
        public virtual List<OverdueDuty> OverdueDuties { get; set; }
    }
}
