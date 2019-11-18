using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Schedule_DAL.ORMs;
using E_Schedule_DAL.Repository;
using E_Schedule_DAL.Contexts;

namespace E_Schedule_DAL
{
    public class UoW : IUoW
    {
        ScheduleContext _context = new ScheduleContext();

        private IRepository<Audience> _audienceRepository;
        private IRepository<Discipline> _disciplineRepository;
        private IRepository<Group> _groupRepository;
        private IRepository<Schedule> _scheduleRepository;
        private IRepository<Student> _studentRepository;
        private IRepository<Teacher> _teacherRepository;
        private IRepository<User> _userRepository;
        private IRepository<UserCredentials> _userCredentialsRepository;

        public IRepository<Audience> AudienceRepository
        {
            get
            {
                if (_audienceRepository == null)
                {
                    _audienceRepository = new EF_Repository<Audience>(_context);
                }
                return _audienceRepository;
            }
        }

        public IRepository<Discipline> DisciplineRepository
        {

            get
            {
                if (_disciplineRepository == null)
                {
                    _disciplineRepository = new EF_Repository<Discipline>(_context);
                }
                return _disciplineRepository;
            }

        }

        public IRepository<Group> GroupRepository
        {
            get
            {
                if (_groupRepository == null)
                {
                    _groupRepository = new EF_Repository<Group>(_context);
                }
                return _groupRepository;
            }
        }

        public IRepository<Schedule> ScheduleRepository
        {
            get
            {
                if (_scheduleRepository == null)
                {
                    _scheduleRepository = new EF_Repository<Schedule>(_context);
                }
                return _scheduleRepository;
            }
        }

        public IRepository<Student> StudentRepository
        {
            get
            {
                if (_studentRepository == null)
                {
                    _studentRepository = new EF_Repository<Student>(_context);
                }
                return _studentRepository;
            }
        }

        public IRepository<Teacher> TeacherRepository
        {
            get
            {
                if (_teacherRepository == null)
                {
                    _teacherRepository = new EF_Repository<Teacher>(_context);
                }
                return _teacherRepository;
            }
        }

        public IRepository<User> UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new EF_Repository<User>(_context);
                }
                return _userRepository;
            }
        }

        public IRepository<UserCredentials> UserCredentialsRepository
        {
            get
            {
                if (_userCredentialsRepository == null)
                {
                    _userCredentialsRepository = new EF_Repository<UserCredentials>(_context);
                }
                return _userCredentialsRepository;
            }
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}