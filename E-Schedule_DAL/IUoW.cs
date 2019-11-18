using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Schedule_DAL.ORMs;
using E_Schedule_DAL.Repository;

namespace E_Schedule_DAL
{
    public interface IUoW : IDisposable
    {
        IRepository<Audience> AudienceRepository { get; }
        IRepository<Discipline> DisciplineRepository { get; }
        IRepository<Group> GroupRepository { get; }
        IRepository<Schedule> ScheduleRepository { get; }
        IRepository<Student> StudentRepository { get; }
        IRepository<Teacher> TeacherRepository { get; }
        IRepository<User> UserRepository { get; }
        IRepository<UserCredentials> UserCredentialsRepository { get; }
    }
}