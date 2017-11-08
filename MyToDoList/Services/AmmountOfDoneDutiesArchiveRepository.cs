using MyToDoList.DbContexts;
using MyToDoList.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDoList.Services
{
    public interface IAmmountOfDoneDutiesArchiveRepository
    {
        void AddDoneDuty(Duty duty);
        void RemoveArchive();
    }
    public class AmmountOfDoneDutiesArchiveRepository : IAmmountOfDoneDutiesArchiveRepository
    {
        private MyToDoListDbContext _context;

        public AmmountOfDoneDutiesArchiveRepository(MyToDoListDbContext context)
        {
            _context = context;
        }
        public void AddDoneDuty(Duty duty)
        {
            var ammountOfDoneDutiesArchive = _context.AmmountOfDoneDutiesArchives.First();

            switch((int)duty.Day)
            {
                case 1:  ammountOfDoneDutiesArchive.MondayDoneDuties += 1;
                    break;
                case 2:
                    ammountOfDoneDutiesArchive.TuesdayDoneDuties += 1;
                    break;
                case 3:
                    ammountOfDoneDutiesArchive.WednesdayDoneDuties += 1;
                    break;
                case 4:
                    ammountOfDoneDutiesArchive.ThursdayDoneDuties += 1;
                    break;
                case 5:
                    ammountOfDoneDutiesArchive.FridayDoneDuties += 1;
                    break;
                case 6:
                    ammountOfDoneDutiesArchive.SaturdayDoneDuties += 1;
                    break;
                case 7:
                    ammountOfDoneDutiesArchive.SundayDoneDuties += 1;
                    break;
            }
        }

        public void RemoveArchive()
        {
            _context.AmmountOfDoneDutiesArchives.Remove(_context.AmmountOfDoneDutiesArchives.First());
        }
    }
}
