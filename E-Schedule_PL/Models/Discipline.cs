using System.Collections.Generic;
using Newtonsoft.Json;
using E_Schedule_PL.Models.Enums;

namespace E_Schedule_PL.Models
{
    public class Discipline
    {
        public Discipline()
        {
            Schedule = new List<Schedule>();
        }

        public int DisciplineID { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Schedule> Schedule { get; set; }
    }
}