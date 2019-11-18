using System.Collections.Generic;
using Newtonsoft.Json;
using E_Schedule_PL.Models.Enums;

namespace E_Schedule_PL.Models
{
    public class User
    {
        public int UserID { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public RoleEnum Role { get; set; }

        [JsonIgnore]
        public virtual UserCredentials UserCredentials { get; set; }

        public virtual Student Student { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}