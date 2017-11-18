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
        void AddDoneOverdueDuty();
        void RemoveArchive();
        void AddNewArchive(AmmountOfDoneDutiesArchive newArchive);
        void ResetArchive();
        AmmountOfDoneDutiesArchive GetArchive();
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
            var ammountOfDoneDutiesArchive = GetArchive();

            if (ammountOfDoneDutiesArchive == null)
            {
                throw new Exception("Nie ma zadnego archiwum");
            }

            switch ((int)duty.Day)
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

        public void AddDoneOverdueDuty()
        {
            var ammountOfDoneDutiesArchive = GetArchive();

            if(ammountOfDoneDutiesArchive == null)
            {
                throw new Exception("Nie ma zadnego archiwum");
            }

            switch((int)DateTime.Now.DayOfWeek)
            {
                case 0:
                    ammountOfDoneDutiesArchive.SundayDoneDuties += 1;
                    break;
                case 1:
                    ammountOfDoneDutiesArchive.MondayDoneDuties += 1;
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
            }
        }

        public void AddNewArchive(AmmountOfDoneDutiesArchive newArchive)
        {
            _context.Add(newArchive);
        }

        public AmmountOfDoneDutiesArchive GetArchive()
        {
           return  _context.AmmountOfDoneDutiesArchives.FirstOrDefault();
        }

        public void RemoveArchive()
        {
            _context.AmmountOfDoneDutiesArchives.Remove(_context.AmmountOfDoneDutiesArchives.First());
        }

        public void ResetArchive()
        {
            var archive = _context.AmmountOfDoneDutiesArchives.FirstOrDefault();

            if(archive==null)
            {
                throw new Exception("No archive");
            }

            archive.MondayDoneDuties = 0;
            archive.TuesdayDoneDuties = 0;
            archive.WednesdayDoneDuties = 0;
            archive.ThursdayDoneDuties = 0;
            archive.FridayDoneDuties = 0;
            archive.SaturdayDoneDuties = 0;
            archive.SundayDoneDuties = 0;


        }
    }
}
