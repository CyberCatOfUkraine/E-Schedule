using System.Collections.Generic;
using E_Schedule_BLL.Enums;

namespace E_Schedule_BLL.Entities
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