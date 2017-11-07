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
            return _context.CurrentWeeks.Include(cw => cw.DoneDuties).First();
        }
    }
}
