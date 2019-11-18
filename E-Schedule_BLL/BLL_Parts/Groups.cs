using System.Collections.Generic;
using AutoMapper;
using E_Schedule_DAL;
using E_Schedule_DAL.ORMs;
using E_Schedule_BLL.Enums;

namespace E_Schedule_BLL
{
    public partial class BLL : IBLL
    {
        public bool AddGroup(int requestingUserID, Entities.Group group)
        {
            var reqUser = Mapper.Map<Entities.User>(UoW.UserRepository.GetByID(requestingUserID));

            if (reqUser.Role == RoleEnum.Admin)
            {
                UoW.GroupRepository.Insert(Mapper.Map<Group>(group));

                return true;
            }

            return false;
        }

        public bool UpdateGroup(int requestingUserID, int groupID, Entities.Group group)
        {
            var reqUser = Mapper.Map<Entities.User>(UoW.UserRepository.GetByID(requestingUserID));

            if (reqUser.Role == RoleEnum.Admin)
            {
                UoW.GroupRepository.Update(groupID, Mapper.Map<Group>(group));

                return true;
            }

            return false;
        }

        public bool DeleteGroup(int requestingUserID, int groupID)
        {
            var reqUser = Mapper.Map<Entities.User>(UoW.UserRepository.GetByID(requestingUserID));

            if (reqUser.Role == RoleEnum.Admin)
            {
                UoW.GroupRepository.Delete(groupID);

                return true;
            }

            return false;
        }

        public Entities.Group GetGroup(int requestingUserID, int groupID)
        {
            var reqUser = Mapper.Map<Entities.User>(UoW.UserRepository.GetByID(requestingUserID));

            if (reqUser.Role <= RoleEnum.Administration)
                return Mapper.Map<Entities.Group>(UoW.GroupRepository.GetByID(groupID));

            return null;
        }

        public ICollection<Entities.Group> GetAllGroups(int requestingUserID)
        {
            var reqUser = Mapper.Map<Entities.User>(UoW.UserRepository.GetByID(requestingUserID));

            if (reqUser.Role <= RoleEnum.Administration)
            {
                var lst = Mapper.Map<List<Entities.Group>>(UoW.GroupRepository.GetAll());
                lst.Sort((a, b) => -1 * a.Students.Count.CompareTo(b.Students.Count));
                return lst;
            }

            return null;
        }
    }
}