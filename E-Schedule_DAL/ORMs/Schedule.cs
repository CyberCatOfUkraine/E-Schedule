using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive;
using E_Schedule_DAL.Enums;

namespace E_Schedule_DAL.ORMs
{
    public class Schedule
    {
        [Key]
        public int ScheduleID { get; set; }

        public WeekEnum Week { get; set; }

        public LessonEnum Lesson { get; set; }

        public SubgroupEnum Subgroup { get; set; }

        [ForeignKey("Teacher"), Required]
        public int UserID { get; set; }

        [ForeignKey("Group"), Required]
        public int GroupID { get; set; }

        [ForeignKey("Discipline"), Required]
        public int DisciplineID { get; set; }

        [ForeignKey("Audience"), Required]
        public int AudienceID { get; set; }

        public virtual Teacher Teacher { get; set; }

        public virtual Group Group { get; set; }

        public virtual Discipline Discipline { get; set; }

        public virtual Audience Audience { get; set; }
    }
}