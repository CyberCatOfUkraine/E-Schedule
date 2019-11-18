using System.Collections.Generic;
using E_Schedule_BLL.Enums;

namespace E_Schedule_BLL.Entities
{
    public class Student
    {
        public int UserID { get; set; }

        public int GroupID { get; set; }

        public SubgroupEnum Subgroup { get; set; }

        public virtual User User { get; set; }

        public virtual Group Group { get; set; }
    }
}