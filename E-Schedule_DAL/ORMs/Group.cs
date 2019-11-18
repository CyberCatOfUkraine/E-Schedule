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
    public class Group
    {
        public Group()
        {
            Students = new List<Student>();
            Schedule = new List<Schedule>();
        }

        [Key]
        public int GroupID { get; set; }

        public string Name { get; set; }

        public int Year { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<Schedule> Schedule { get; set; }
    }
}