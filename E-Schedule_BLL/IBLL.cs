using System;
using System.Collections.Generic;
using E_Schedule_BLL.Entities;

namespace E_Schedule_BLL
{
    public interface IBLL : IDisposable
    {
        bool AddAudience(int requestingUserID, Audience audience);
        bool UpdateAudience(int requestingUserID, int audienceID, Audience audience);
        bool DeleteAudience(int requestingUserID, int audienceID);
        Audience GetAudience(int requestingUserID, int audienceID);
        ICollection<Audience> GetAllAudiences(int requestingUserID);


        bool AddDiscipline(int requestingUserID, Discipline discipline);
        bool UpdateDiscipline(int requestingUserID, int disciplineID, Discipline discipline);
        bool DeleteDiscipline(int requestingUserID, int disciplineID);
        Discipline GetDiscipline(int requestingUserID, int disciplineID);
        ICollection<Discipline> GetAllDisciplines(int requestingUserID);


        bool AddGroup(int requestingUserID, Group group);
        bool UpdateGroup(int requestingUserID, int groupID, Group group);
        bool DeleteGroup(int requestingUserID, int groupID);
        Group GetGroup(int requestingUserID, int groupID);
        ICollection<Group> GetAllGroups(int requestingUserID);


        bool AddSchedule(int requestingUserID, Schedule schedule);
        bool UpdateSchedule(int requestingUserID, int scheduleID, Schedule schedule);
        bool DeleteSchedule(int requestingUserID, int scheduleID);
        Schedule GetScheduleByID(int requestingUserID, int scheduleID);
        ICollection<Schedule> GetSchedule(int requestingUserID);
        ICollection<Schedule> GetAllSchedule(int requestingUserID);


        bool AddStudent(int requestingUserID, Student student);
        bool UpdateStudent(int requestingUserID, int studentID, Student student);
        bool DeleteStudent(int requestingUserID, int studentID);
        Student GetStudent(int requestingUserID, int studentID);
        ICollection<Student> GetAllStudents(int requestingUserID);


        bool AddTeacher(int requestingUserID, Teacher teacher);
        bool UpdateTeacher(int requestingUserID, int teacherID, Teacher teacher);
        bool DeleteTeacher(int requestingUserID, int teacherID);
        Teacher GetTeacher(int requestingUserID, int teacherID);
        ICollection<Teacher> GetAllTeachers(int requestingUserID);


        bool AddUser(int requestingUserID, User user);
        bool UpdateUser(int requestingUserID, int userID, User user);
        bool DeleteUser(int requestingUserID, int userID);
        User GetUser(int requestingUserID, int userID);
        ICollection<User> GetAllUsers(int requestingUserID);


        int SignIn(string login, string password);
        int ApiTokenToID(string token);
        string GetApiToken(int userID);
        UserCredentials GetUserCredetial(int userID);
        ICollection<UserCredentials> GetAllUserCredentials(int requestingUserID);
        bool UpdatePassword(int userID, string oldPass, string newPass);
        bool UpdateLogin(int userID, string newLogin, string password);
        string UpdateApiToken(int userID);
    }
}