using System.Collections.Generic;
using AutoMapper;
using E_Schedule_DAL;
using E_Schedule_DAL.ORMs;
using E_Schedule_BLL.Enums;

namespace E_Schedule_BLL
{
    public partial class BLL : IBLL
    {
        public bool AddTeacher(int requestingUserID, Entities.Teacher teacher)
        {
            if (teacher.User == null || teacher.User.Role != RoleEnum.Teacher)
                return false;

            teacher.User.Teacher = teacher;
            return AddUser(requestingUserID, teacher.User);
        }

        public bool UpdateTeacher(int requestingUserID, int teacherID, Entities.Teacher teacher)
        {
            var reqUser = Mapper.Map<Entities.User>(UoW.UserRepository.GetByID(requestingUserID));

            if (reqUser.Role == RoleEnum.Admin)
            {
                UoW.TeacherRepository.Update(teacherID, Mapper.Map<Teacher>(teacher));

                return true;
            }

            return false;
        }

        public bool DeleteTeacher(int requestingUserID, int teacherID)
        {
            var reqUser = Mapper.Map<Entities.User>(UoW.UserRepository.GetByID(requestingUserID));

            if (reqUser.Role == RoleEnum.Admin)
            {
                UoW.UserRepository.Delete(teacherID);

                return true;
            }

            return false;
        }

        public Entities.Teacher GetTeacher(int requestingUserID, int teacherID)
        {
            if (requestingUserID == teacherID || Mapper.Map<Entities.User>(UoW.UserRepository.GetByID(requestingUserID)).Role <= RoleEnum.Administration)
                return Mapper.Map<Entities.Teacher>(UoW.TeacherRepository.GetByID(teacherID));
            return null;
        }

        public ICollection<Entities.Teacher> GetAllTeachers(int requestingUserID)
        {
            var reqUser = Mapper.Map<Entities.User>(UoW.UserRepository.GetByID(requestingUserID));

            if (reqUser.Role <= RoleEnum.Administration)
            {
                var lst = Mapper.Map<List<Entities.Teacher>>(UoW.TeacherRepository.GetAll());
                lst.Sort((a, b) => -1 * a.Schedule.Count.CompareTo(b.Schedule.Count));
                return lst;
            }

            return null;
        }
    }
}