using Microsoft.EntityFrameworkCore;
using MyToDoList.DbContexts;
using MyToDoList.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDoList.Services
{
    public interface ICurrentWeekService
    {
        CurrentWeek GetCurrentWeek();
        void AddCurrentWeek(CurrentWeek currentWeek);

        void RemoveCurrentWeek();
    }
    public class CurrentWeekService:ICurrentWeekService
    {
        private MyToDoListDbContext _context;

        public CurrentWeekService(MyToDoListDbContext context)
        {
            _context = context;
        }

        public void AddCurrentWeek(CurrentWeek currentWeek)
        {

            _context.Add(currentWeek);
        }

        public CurrentWeek GetCurrentWeek()
        {
            if(!_context.CurrentWeeks.Any())
            {
                return null;
            }
            return _context.CurrentWeeks.Include(cw => cw.AmmountOfDoneDutiesArchive).First();
        }

        public void RemoveCurrentWeek()
        {
            _context.CurrentWeeks.Remove(_context.CurrentWeeks.First());
        }
    }
}
