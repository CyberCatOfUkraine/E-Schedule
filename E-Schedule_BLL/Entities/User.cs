using System.Collections.Generic;
using E_Schedule_BLL.Enums;

namespace E_Schedule_BLL.Entities
{
    public class User
    {
        public int UserID { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public RoleEnum Role { get; set; }

        public virtual UserCredentials UserCredentials { get; set; }

        public virtual Student Student { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}