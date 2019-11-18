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
    public class UserCredentials
    {
        [Key, ForeignKey("User"), Required]
        public int UserID { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string ApiToken { get; set; }

        public virtual User User { get; set; }
    }
}