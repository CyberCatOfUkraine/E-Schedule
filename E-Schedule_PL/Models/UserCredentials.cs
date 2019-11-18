using System.Collections.Generic;
using Newtonsoft.Json;
using E_Schedule_PL.Models.Enums;

namespace E_Schedule_PL.Models
{
    public class UserCredentials
    {
        public int UserID { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string ApiToken { get; set; }

        public virtual User User { get; set; }
    }
}