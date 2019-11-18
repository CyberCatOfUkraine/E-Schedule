using System.Collections.Generic;
using E_Schedule_BLL.Enums;

namespace E_Schedule_BLL.Entities
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