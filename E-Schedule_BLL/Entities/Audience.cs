using System.Collections.Generic;
using E_Schedule_BLL.Enums;

namespace E_Schedule_BLL.Entities
{
    public class Audience
    {
        public Audience()
        {
            Schedule = new List<Schedule>();
        }

        public int AudienceID { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Schedule> Schedule { get; set; }
    }
}