using Microsoft.EntityFrameworkCore;
using MyToDoList.DbContexts;
using MyToDoList.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDoList.Services
{
    public interface IOverdueDutyRepository
    {
        void AddOverdueDuty(OverdueDuty overdueDuty);
        IEnumerable<OverdueDuty> OverdueDuties { get; }
        OverdueDuty GetOverdueDuty(int id);
        void RemoveOverdueDuty(int id);
    }
    public class OverdueDutyRepository : IOverdueDutyRepository
    {
        private MyToDoListDbContext _context;

        public OverdueDutyRepository(MyToDoListDbContext context)
        {
            _context = context;
        }

        public IEnumerable<OverdueDuty> OverdueDuties => _context.OverdueDuties.Include(od=>od.Category);

        public void AddOverdueDuty(OverdueDuty overdueDuty)
        {
            _context.Add(overdueDuty);
        }

        public OverdueDuty GetOverdueDuty(int id)
        {
            return _context.OverdueDuties.FirstOrDefault(od => od.Id == id);
        }

        public void RemoveOverdueDuty(int id)
        {
            var DutyToRemove = GetOverdueDuty(id);

            if(DutyToRemove==null)
            {
                throw new Exception("Nie ma takiego zaleglego zadania");
            }
            _context.OverdueDuties.Remove(DutyToRemove);
        }
    }
}
