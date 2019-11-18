using System.Collections.Generic;
using AutoMapper;
using E_Schedule_DAL;
using E_Schedule_DAL.ORMs;
using E_Schedule_BLL.Enums;

namespace E_Schedule_BLL
{
    public partial class BLL : IBLL
    {
        public bool AddDiscipline(int requestingUserID, Entities.Discipline discipline)
        {
            var reqUser = Mapper.Map<Entities.User>(UoW.UserRepository.GetByID(requestingUserID));

            if (reqUser.Role == RoleEnum.Admin)
            {
                UoW.DisciplineRepository.Insert(Mapper.Map<Discipline>(discipline));

                return true;
            }

            return false;
        }

        public bool UpdateDiscipline(int requestingUserID, int disciplineID, Entities.Discipline discipline)
        {
            var reqUser = Mapper.Map<Entities.User>(UoW.UserRepository.GetByID(requestingUserID));

            if (reqUser.Role == RoleEnum.Admin)
            {
                UoW.DisciplineRepository.Update(disciplineID, Mapper.Map<Discipline>(discipline));

                return true;
            }

            return false;
        }

        public bool DeleteDiscipline(int requestingUserID, int disciplineID)
        {
            var reqUser = Mapper.Map<Entities.User>(UoW.UserRepository.GetByID(requestingUserID));

            if (reqUser.Role == RoleEnum.Admin)
            {
                UoW.DisciplineRepository.Delete(disciplineID);

                return true;
            }

            return false;
        }

        public Entities.Discipline GetDiscipline(int requestingUserID, int disciplineID)
        {
            var reqUser = Mapper.Map<Entities.User>(UoW.UserRepository.GetByID(requestingUserID));

            if (reqUser.Role <= RoleEnum.Administration)
                return Mapper.Map<Entities.Discipline>(UoW.DisciplineRepository.GetByID(disciplineID));

            return null;
        }

        public ICollection<Entities.Discipline> GetAllDisciplines(int requestingUserID)
        {
            var reqUser = Mapper.Map<Entities.User>(UoW.UserRepository.GetByID(requestingUserID));

            if (reqUser.Role <= RoleEnum.Administration)
            {
                var lst = Mapper.Map<List<Entities.Discipline>>(UoW.DisciplineRepository.GetAll());
                lst.Sort((a, b) => -1 * a.Schedule.Count.CompareTo(b.Schedule.Count));
                return lst;
            }

            return null;
        }
    }
}