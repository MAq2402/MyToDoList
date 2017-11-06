using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDoList.Entities
{
    public class CurrentWeek
    {
        public int Id { get; set; }
        public DateTime MondayDate { get; set; }

        public virtual IEnumerable<Duty> DoneDuties { get; set; }
    }
}
