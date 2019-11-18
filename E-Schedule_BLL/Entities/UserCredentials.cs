using System.Collections.Generic;
using E_Schedule_BLL.Enums;

namespace E_Schedule_BLL.Entities
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