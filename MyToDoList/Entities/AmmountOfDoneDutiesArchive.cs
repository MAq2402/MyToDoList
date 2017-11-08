using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDoList.Entities
{
    public class AmmountOfDoneDutiesArchive
    {
        public int Id { get; set; }
        public int MondayDoneDuties { get; set; }
        public int TuesdayDoneDuties { get; set; }
        public int WednesdayDoneDuties { get; set; }
        public int ThursdayDoneDuties { get; set; }
        public int FridayDoneDuties { get; set; }
        public int SaturdayDoneDuties { get; set; }
        public int SundayDoneDuties { get; set; }

    }
}
