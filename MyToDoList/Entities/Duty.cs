using MyToDoList.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDoList.Entities
{
    public class Duty
    {
        public string Content { get; set; }
        public Day Day { get; set; }

    }
}
