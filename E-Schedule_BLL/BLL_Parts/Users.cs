using System.Collections.Generic;
using AutoMapper;
using E_Schedule_DAL;
using E_Schedule_DAL.ORMs;
using E_Schedule_BLL.Enums;

namespace E_Schedule_BLL
{
    public partial class BLL : IBLL
    {
        public bool AddUser(int requestingUserID, Entities.User user)
        {
            var reqUser = Mapper.Map<Entities.User>(UoW.UserRepository.GetByID(requestingUserID));

            if (reqUser.Role == RoleEnum.Admin)
            {
                if (user.Role == RoleEnum.Student && user.Student == null)
                    return false;

                if (user.Role == RoleEnum.Teacher && user.Teacher == null)
                    return false;

                user.UserCredentials = new Entities.UserCredentials()
                {
                    User = user,
                    UserID = user.UserID,
                    Login = ServiceProvider.CreateLogin(user.Name, user.Surname),
                    Password = ServiceProvider.EncryptString(ServiceProvider.CreateLogin(user.Name, user.Surname)),
                    ApiToken = ServiceProvider.RandomStringGenerator()
                };

                UoW.UserRepository.Insert(Mapper.Map<User>(user));

                return true;
            }

            return false;
        }

        public bool UpdateUser(int requestingUserID, int userID, Entities.User user)
        {
            var reqUser = Mapper.Map<Entities.User>(UoW.UserRepository.GetByID(requestingUserID));

            if (reqUser.Role == RoleEnum.Admin)
            {
                UoW.UserRepository.Update(userID, Mapper.Map<User>(user));

                return true;
            }

            return false;
        }

        public bool DeleteUser(int requestingUserID, int userID)
        {
            var reqUser = Mapper.Map<Entities.User>(UoW.UserRepository.GetByID(requestingUserID));

            if (reqUser.Role == RoleEnum.Admin)
            {
                UoW.UserRepository.Delete(userID);

                return true;
            }

            return false;
        }

        public Entities.User GetUser(int requestingUserID, int userID)
        {
            if (requestingUserID == userID || Mapper.Map<Entities.User>(UoW.UserRepository.GetByID(requestingUserID)).Role <= RoleEnum.Administration)
                return Mapper.Map<Entities.User>(UoW.UserRepository.GetByID(userID));

            return null;
        }

        public ICollection<Entities.User> GetAllUsers(int requestingUserID)
        {
            var reqUser = Mapper.Map<Entities.User>(UoW.UserRepository.GetByID(requestingUserID));

            if (reqUser.Role <= RoleEnum.Administration)
            {
                var usrs = Mapper.Map<List<Entities.User>>(UoW.UserRepository.GetAll());
                usrs.Sort((a, b) => a.Role.CompareTo(b.Role));
                return usrs;
            }

            return null;
        }
    }
}