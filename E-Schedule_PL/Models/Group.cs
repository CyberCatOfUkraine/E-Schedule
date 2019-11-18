using System.Collections.Generic;
using Newtonsoft.Json;
using E_Schedule_PL.Models.Enums;

namespace E_Schedule_PL.Models
{
    public class Group
    {
        public Group()
        {
            Students = new List<Student>();
            Schedule = new List<Schedule>();
        }

        public int GroupID { get; set; }

        public string Name { get; set; }

        public int Year { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<Schedule> Schedule { get; set; }
    }
}