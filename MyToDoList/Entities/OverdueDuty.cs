using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDoList.Entities
{
    public class OverdueDuty
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
