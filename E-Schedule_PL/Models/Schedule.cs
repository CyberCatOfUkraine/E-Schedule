using System.Collections.Generic;
using Newtonsoft.Json;
using E_Schedule_PL.Models.Enums;

namespace E_Schedule_PL.Models
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

        [JsonIgnore]
        public virtual Teacher Teacher { get; set; }

        [JsonIgnore]
        public virtual Group Group { get; set; }

        [JsonIgnore]
        public virtual Discipline Discipline { get; set; }

        [JsonIgnore]
        public virtual Audience Audience { get; set; }
    }
}