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

        Duty GetDuty(int id);

        void RemoveDuty(int id);
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
            _context.Add(newDuty);
        }

        public void RemoveDuty(int id)
        {
            var duty = Duties.FirstOrDefault(x => x.Id == id);

            _context.Remove(duty);
        }

        public Duty GetDuty(int id)
        {
            return Duties.FirstOrDefault(x => x.Id == id);
        }
    }
}
