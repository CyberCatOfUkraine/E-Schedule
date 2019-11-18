using System;
using System.Collections.Generic;
using NUnit.Framework;
using Moq;
using E_Schedule_BLL;
using E_Schedule_DAL;
using E_Schedule_DAL.ORMs;
using E_Schedule_DAL.Enums;

namespace E_Schedule.Tests
{
    [TestFixture]
    partial class UnitTest
    {
        [Test]
        public void GetAllStudentsTest()
        {
            var moq = new Mock<IUoW>();

            moq.Setup(m => m.UserRepository.GetByID(It.IsAny<object>())).Returns(new User()
            {
                UserID = 0,
                Role = RoleEnum.Admin
            });

            moq.Setup(m => m.StudentRepository.GetAll()).Returns(new List<Student>());

            IBLL bll = new BLL(moq.Object);



            var usr = bll.GetAllStudents(0);



            Assert.NotNull(usr);
        }

        [Test]
        public void GetStudentTest()
        {
            var moq = new Mock<IUoW>();

            moq.Setup(m => m.UserRepository.GetByID(It.IsAny<object>())).Returns(new User()
            {
                UserID = 0,
                Role = RoleEnum.Admin
            });

            moq.Setup(m => m.StudentRepository.GetByID(It.IsAny<object>())).Returns(new Student());

            IBLL bll = new BLL(moq.Object);



            var usr = bll.GetStudent(0, 0);



            Assert.NotNull(usr);
        }

        [Test]
        public void DeleteStudentTest()
        {
            var moq = new Mock<IUoW>();

            moq.Setup(m => m.UserRepository.GetByID(It.IsAny<object>())).Returns(new User()
            {
                UserID = 0,
                Role = RoleEnum.Admin
            });

            moq.Setup(m => m.UserRepository.Delete(It.IsAny<object>())).Verifiable();

            IBLL bll = new BLL(moq.Object);



            var usr = bll.DeleteStudent(0, 0);



            moq.Verify(m => m.UserRepository.Delete(It.IsAny<object>()), Times.Once);

            Assert.NotNull(usr);
        }

        [Test]
        public void AddStudentTest()
        {
            var moq = new Mock<IUoW>();

            moq.Setup(m => m.UserRepository.GetByID(It.IsAny<object>())).Returns(new User()
            {
                UserID = 0,
                Role = RoleEnum.Admin
            });

            moq.Setup(m => m.UserRepository.Insert(It.IsAny<User>())).Verifiable();

            IBLL bll = new BLL(moq.Object);



            bll.AddStudent(0, new E_Schedule_BLL.Entities.Student()
            {
                GroupID = 1,
                User = new E_Schedule_BLL.Entities.User() { Role = E_Schedule_BLL.Enums.RoleEnum.Student }
            });



            moq.Verify(m => m.UserRepository.Insert(It.IsAny<User>()), Times.Once);
        }

        [Test]
        public void UpdStudentTest()
        {
            var moq = new Mock<IUoW>();

            moq.Setup(m => m.UserRepository.GetByID(It.IsAny<object>())).Returns(new User()
            {
                UserID = 0,
                Role = RoleEnum.Admin
            });

            moq.Setup(m => m.StudentRepository.Update(0, It.IsAny<Student>())).Verifiable();

            IBLL bll = new BLL(moq.Object);



            bll.UpdateStudent(0, 0, new E_Schedule_BLL.Entities.Student());



            moq.Verify(m => m.StudentRepository.Update(0, It.IsAny<Student>()), Times.Once);
        }
    }
}