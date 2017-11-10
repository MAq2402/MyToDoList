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
    }
    public class OverdueDutyRepository : IOverdueDutyRepository
    {
        private MyToDoListDbContext _context;

        public OverdueDutyRepository(MyToDoListDbContext context)
        {
            _context = context;
        }
        public void AddOverdueDuty(OverdueDuty overdueDuty)
        {
            _context.Add(overdueDuty);
        }
    }
}
