using System.Collections.Generic;
using AutoMapper;
using E_Schedule_DAL;
using E_Schedule_DAL.ORMs;
using E_Schedule_BLL.Enums;

namespace E_Schedule_BLL
{
    public partial class BLL : IBLL
    {
        public bool AddStudent(int requestingUserID, Entities.Student student)
        {
            if (student.User == null || student.User.Role != RoleEnum.Student || student.GroupID == 0)
                return false;

            student.User.Student = student;
            return AddUser(requestingUserID, student.User);
        }

        public bool UpdateStudent(int requestingUserID, int studentID, Entities.Student student)
        {
            var reqUser = Mapper.Map<Entities.User>(UoW.UserRepository.GetByID(requestingUserID));

            if (reqUser.Role == RoleEnum.Admin)
            {
                UoW.StudentRepository.Update(studentID, Mapper.Map<Student>(student));

                return true;
            }

            return false;
        }

        public bool DeleteStudent(int requestingUserID, int studentID)
        {
            var reqUser = Mapper.Map<Entities.User>(UoW.UserRepository.GetByID(requestingUserID));

            if (reqUser.Role == RoleEnum.Admin)
            {
                UoW.UserRepository.Delete(studentID);

                return true;
            }

            return false;
        }

        public Entities.Student GetStudent(int requestingUserID, int studentID)
        {
            if (requestingUserID == studentID || Mapper.Map<Entities.User>(UoW.UserRepository.GetByID(requestingUserID)).Role <= RoleEnum.Administration)
                return Mapper.Map<Entities.Student>(UoW.StudentRepository.GetByID(studentID));

            return null;
        }

        public ICollection<Entities.Student> GetAllStudents(int requestingUserID)
        {
            var reqUser = Mapper.Map<Entities.User>(UoW.UserRepository.GetByID(requestingUserID));

            if (reqUser.Role <= RoleEnum.Administration)
            {
                var lst = Mapper.Map<List<Entities.Student>>(UoW.StudentRepository.GetAll());
                lst.Sort((a, b) => -1 * a.Group.Students.Count.CompareTo(b.Group.Students.Count));
                return lst;
            }

            return null;
        }
    }
}