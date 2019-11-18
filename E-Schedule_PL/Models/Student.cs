using System.Collections.Generic;
using Newtonsoft.Json;
using E_Schedule_PL.Models.Enums;

namespace E_Schedule_PL.Models
{
    public class Student
    {
        public int UserID { get; set; }

        public int GroupID { get; set; }

        public SubgroupEnum Subgroup { get; set; }

        public virtual User User { get; set; }

        [JsonIgnore]
        public virtual Group Group { get; set; }
    }
}