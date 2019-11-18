using System.Collections.Generic;
using E_Schedule_BLL.Enums;

namespace E_Schedule_BLL.Entities
{
    public class Schedule
    {
        public int ScheduleID { get; set; }

        public WeekEnum Week { get; set; }

        public LessonEnum Lesson { get; set; }

        public SubgroupEnum Subgroup { get; set; }

        public int UserID { get; set; }

        public int GroupID { get; set; }

        public int DisciplineID { get; set; }

        public int AudienceID { get; set; }

        public virtual Teacher Teacher { get; set; }

        public virtual Group Group { get; set; }

        public virtual Discipline Discipline { get; set; }

        public virtual Audience Audience { get; set; }
    }
}