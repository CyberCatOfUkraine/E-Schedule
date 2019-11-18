using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive;
using E_Schedule_DAL.ORMs;

namespace E_Schedule_DAL.Contexts
{
    public class ScheduleContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<UserCredentials> UserCredentials { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Audience> Audiences { get; set; }

        public DbSet<Discipline> Disciplines { get; set; }

        public DbSet<Schedule> Schedules { get; set; }

        public ScheduleContext() : base("SQLSERVER_CONNECTION_STRING") { }
    }
}