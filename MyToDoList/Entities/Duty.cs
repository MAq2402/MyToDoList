using MyToDoList.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDoList.Entities
{
    public class Duty
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public Day Day { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
