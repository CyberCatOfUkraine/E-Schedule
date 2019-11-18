using System.Collections.Generic;
using AutoMapper;
using E_Schedule_DAL;
using E_Schedule_DAL.ORMs;
using E_Schedule_BLL.Enums;

namespace E_Schedule_BLL
{
    public partial class BLL : IBLL
    {
        public bool AddAudience(int requestingUserID, Entities.Audience audience)
        {
            var reqUser = Mapper.Map<Entities.User>(UoW.UserRepository.GetByID(requestingUserID));

            if (reqUser.Role == RoleEnum.Admin)
            {
                UoW.AudienceRepository.Insert(Mapper.Map<Audience>(audience));

                return true;
            }

            return false;
        }

        public bool UpdateAudience(int requestingUserID, int audienceID, Entities.Audience audience)
        {
            var reqUser = Mapper.Map<Entities.User>(UoW.UserRepository.GetByID(requestingUserID));

            if (reqUser.Role == RoleEnum.Admin)
            {
                UoW.AudienceRepository.Update(audienceID, Mapper.Map<Audience>(audience));

                return true;
            }

            return false;
        }

        public bool DeleteAudience(int requestingUserID, int audienceID)
        {
            var reqUser = Mapper.Map<Entities.User>(UoW.UserRepository.GetByID(requestingUserID));

            if (reqUser.Role == RoleEnum.Admin)
            {
                UoW.AudienceRepository.Delete(audienceID);

                return true;
            }

            return false;
        }
        public Entities.Audience GetAudience(int requestingUserID, int audienceID)
        {
            var reqUser = Mapper.Map<Entities.User>(UoW.UserRepository.GetByID(requestingUserID));

            if (reqUser.Role <= RoleEnum.Administration)
                return Mapper.Map<Entities.Audience>(UoW.AudienceRepository.GetByID(audienceID));

            return null;
        }

        public ICollection<Entities.Audience> GetAllAudiences(int requestingUserID)
        {
            var reqUser = Mapper.Map<Entities.User>(UoW.UserRepository.GetByID(requestingUserID));

            if (reqUser.Role <= RoleEnum.Administration)
            {
                var lst = Mapper.Map<List<Entities.Audience>>(UoW.AudienceRepository.GetAll());
                lst.Sort((a, b) => -1 * a.Schedule.Count.CompareTo(b.Schedule.Count));
                return lst;
            }

            return null;
        }
    }
}