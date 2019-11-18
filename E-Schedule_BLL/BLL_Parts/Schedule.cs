using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using E_Schedule_DAL;
using E_Schedule_DAL.ORMs;
using E_Schedule_BLL.Enums;

namespace E_Schedule_BLL
{
    public partial class BLL : IBLL
    {
        public bool AddSchedule(int requestingUserID, Entities.Schedule schedule)
        {
            var reqUser = Mapper.Map<Entities.User>(UoW.UserRepository.GetByID(requestingUserID));

            if (reqUser.Role <= RoleEnum.Editor)
            {
                List<Entities.Schedule> schedules = GetAllSchedule(requestingUserID).ToList();

                var sch = schedules.FindAll(x => 
                x.Week == schedule.Week && x.Lesson == schedule.Lesson &&
                (x.UserID == schedule.UserID || x.GroupID == schedule.GroupID)).ToList();

                if (sch.Count > 0)
                {
                    if (null != sch.Find(x =>
                    x.UserID == schedule.UserID && x.GroupID != schedule.GroupID &&
                    x.Subgroup != SubgroupEnum.full && schedule.Subgroup != SubgroupEnum.full))
                        return false;
                    if (null != sch.Find(x =>
                    x.UserID != schedule.UserID && x.Group == schedule.Group &&
                    (x.Subgroup == SubgroupEnum.full || schedule.Subgroup == SubgroupEnum.full || x.Subgroup == schedule.Subgroup)))
                        return false;
                }

                UoW.ScheduleRepository.Insert(Mapper.Map<Schedule>(schedule));

                return true;
            }

            return false;
        }

        public bool UpdateSchedule(int requestingUserID, int scheduleID, Entities.Schedule schedule)
        {
            var reqUser = Mapper.Map<Entities.User>(UoW.UserRepository.GetByID(requestingUserID));

            if (reqUser.Role <= RoleEnum.Editor)
            {
                UoW.ScheduleRepository.Update(scheduleID, Mapper.Map<Schedule>(schedule));

                return true;
            }

            return false;
        }

        public bool DeleteSchedule(int requestingUserID, int scheduleID)
        {
            var reqUser = Mapper.Map<Entities.User>(UoW.UserRepository.GetByID(requestingUserID));

            if (reqUser.Role <= RoleEnum.Editor)
            {
                UoW.ScheduleRepository.Delete(scheduleID);

                return true;
            }

            return false;
        }

        public Entities.Schedule GetScheduleByID(int requestingUserID, int scheduleID)
        {
            var reqUser = Mapper.Map<Entities.User>(UoW.UserRepository.GetByID(requestingUserID));

            if (reqUser.Role <= RoleEnum.Teacher)
                return Mapper.Map<Entities.Schedule>(UoW.ScheduleRepository.GetByID(scheduleID));

            return null;
        }

        public ICollection<Entities.Schedule> GetSchedule(int requestingUserID)
        {
            var reqUser = Mapper.Map<Entities.User>(UoW.UserRepository.GetByID(requestingUserID));

            if (reqUser.Role == RoleEnum.Teacher)
            {
                var lst = Mapper.Map<List<Entities.Schedule>>(UoW.TeacherRepository.GetByID(requestingUserID).Schedule.ToList());
                lst.OrderBy(x => x.Week).ThenBy(x => x.Lesson).ThenBy(x => x.Subgroup);
                return lst;
            }

            if (reqUser.Role == RoleEnum.Student)
            {
                var lst = Mapper.Map<List<Entities.Schedule>>(UoW.StudentRepository.GetByID(requestingUserID).Group.Schedule.ToList());
                lst.OrderBy(x => x.Week).ThenBy(x => x.Lesson).ThenBy(x => x.Subgroup);
                return lst;
            }

            return null;
        }

        public ICollection<Entities.Schedule> GetAllSchedule(int requestingUserID)
        {
            var reqUser = Mapper.Map<Entities.User>(UoW.UserRepository.GetByID(requestingUserID));

            if (reqUser.Role <= RoleEnum.Teacher)
            {
                var lst = Mapper.Map<List<Entities.Schedule>>(UoW.ScheduleRepository.GetAll());
                lst.OrderBy(x => x.Week).ThenBy(x => x.Lesson).ThenBy(x => x.Subgroup);
                return lst;
            }

            return null;
        }
    }
}