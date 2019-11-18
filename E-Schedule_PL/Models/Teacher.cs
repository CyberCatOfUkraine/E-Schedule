using System.Collections.Generic;
using Newtonsoft.Json;
using E_Schedule_PL.Models.Enums;

namespace E_Schedule_PL.Models
{
    public class Teacher
    {
        public Teacher()
        {
            Schedule = new List<Schedule>();
        }

        public int UserID { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Schedule> Schedule { get; set; }
    }
}