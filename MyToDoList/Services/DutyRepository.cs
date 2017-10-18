using Microsoft.EntityFrameworkCore;
using MyToDoList.DbContexts;
using MyToDoList.Entities;
using MyToDoList.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDoList.Services
{
    public interface IDutyRepository
    {
        IEnumerable<Duty> Duties { get; }
        void AddDuty(Duty newDuty);
    }
    public class DutyRepository:IDutyRepository
    {
        private MyToDoListDbContext _context;

        public DutyRepository(MyToDoListDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Duty> Duties => _context.Duties.Include(d=>d.Category);

        public void AddDuty(Duty newDuty)
        {
            _context.Duties.Add(newDuty);
        }
    }
}
