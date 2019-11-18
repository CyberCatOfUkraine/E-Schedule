using System;
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
    public class User
    {
        [Key]
        public int UserID { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public RoleEnum Role { get; set; }

        public virtual UserCredentials UserCredentials { get; set; }

        public virtual Student Student { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}