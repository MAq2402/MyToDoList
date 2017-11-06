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
    }
    public class CurrentWeekService:ICurrentWeekService
    {
        private MyToDoListDbContext _context;

        public CurrentWeekService(MyToDoListDbContext context)
        {
            _context = context;
        }

        public CurrentWeek GetCurrentWeek()
        {
            return _context.CurruntWeeks.Include(cw => cw.DoneDuties).First();
        }
    }
}
