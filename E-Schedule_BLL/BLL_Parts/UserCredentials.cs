using System.Collections.Generic;
using AutoMapper;
using E_Schedule_DAL;
using E_Schedule_DAL.ORMs;
using E_Schedule_BLL.Enums;

namespace E_Schedule_BLL
{
    public partial class BLL
    {
        public int SignIn(string login, string password)
        {
            var cred = Mapper.Map<List<Entities.UserCredentials>>(UoW.UserCredentialsRepository.GetAll());

            var usr = cred.Find(x => x.Login == login && x.Password == ServiceProvider.EncryptString(password));

            if (usr != null)
                return usr.UserID;

            return -1;
        }

        public int ApiTokenToID(string token)
        {
            var cred = Mapper.Map<List<Entities.UserCredentials>>(UoW.UserCredentialsRepository.GetAll());

            var usr = cred.Find(x => x.ApiToken == token);

            if (usr != null)
                return usr.UserID;

            return -1;
        }

        public string GetApiToken(int userID)
        {
            var usr = Mapper.Map<Entities.UserCredentials>(UoW.UserCredentialsRepository.GetByID(userID));

            if (usr != null)
                return usr.ApiToken;

            return null;
        }

        public Entities.UserCredentials GetUserCredetial(int userID)
        {
            var cr = Mapper.Map<Entities.UserCredentials>(UoW.UserCredentialsRepository.GetByID(userID));
            cr.User = null;
            return cr;
        }

        public ICollection<Entities.UserCredentials> GetAllUserCredentials(int requestingUserID)
        {
            var reqUser = Mapper.Map<Entities.User>(UoW.UserRepository.GetByID(requestingUserID));

            if (reqUser.Role == RoleEnum.Admin)
            {
                var crs = Mapper.Map<List<Entities.UserCredentials>>(UoW.UserCredentialsRepository.GetAll());

                for (int i = 0; i < crs.Count; i++)
                    crs[i].User = null;

                return crs;
            }

            return null;
        }

        public bool UpdatePassword(int userID, string oldPass, string newPass)
        {
            var usr = Mapper.Map<Entities.UserCredentials>(UoW.UserCredentialsRepository.GetByID(userID));

            if (usr != null && usr.Password == ServiceProvider.EncryptString(oldPass))
            {
                usr.Password = ServiceProvider.EncryptString(newPass);

                UoW.UserCredentialsRepository.Update(usr.UserID, Mapper.Map<UserCredentials>(usr));

                return true;
            }

            return false;
        }

        public bool UpdateLogin(int userID, string newLogin, string password)
        {
            var usr = Mapper.Map<Entities.UserCredentials>(UoW.UserCredentialsRepository.GetByID(userID));

            if (usr != null && usr.Password == ServiceProvider.EncryptString(password))
            {
                usr.Login = newLogin;

                UoW.UserCredentialsRepository.Update(usr.UserID, Mapper.Map<UserCredentials>(usr));

                return true;
            }

            return false;
        }

        public string UpdateApiToken(int userID)
        {
            var usr = Mapper.Map<Entities.UserCredentials>(UoW.UserCredentialsRepository.GetByID(userID));

            if (usr != null)
            {
                usr.ApiToken = ServiceProvider.RandomStringGenerator();

                UoW.UserCredentialsRepository.Update(usr.UserID, Mapper.Map<UserCredentials>(usr));

                return usr.ApiToken;
            }

            return null;
        }
    }
}