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
    public class MockDutyRepository:IDutyRepository
    {
        private List<Duty> DutiesData = new List<Duty>
        {
            new Duty {Content="XDDDD",Day=Day.Monday},
            new Duty {Content="XDDDD",Day=Day.Tuesday},
            new Duty {Content="XDDDD",Day=Day.Wednesday},
            new Duty {Content="XDDDD",Day=Day.Thursday},
            new Duty {Content="XDDDD",Day=Day.Friday},
            new Duty {Content="XDDDD",Day=Day.Thursday},
            new Duty {Content="XDDDD",Day=Day.Saturday}

        };

        public IEnumerable<Duty> Duties => DutiesData;

        public void AddDuty(Duty newDuty)
        {
            
        }
    }
}
