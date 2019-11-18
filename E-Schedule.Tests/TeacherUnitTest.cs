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
        public void GetAllTeachersTest()
        {
            var moq = new Mock<IUoW>();

            moq.Setup(m => m.UserRepository.GetByID(It.IsAny<object>())).Returns(new User()
            {
                UserID = 0,
                Role = RoleEnum.Admin
            });

            moq.Setup(m => m.TeacherRepository.GetAll()).Returns(new List<Teacher>());

            IBLL bll = new BLL(moq.Object);



            var usr = bll.GetAllTeachers(0);



            Assert.NotNull(usr);
        }

        [Test]
        public void GetTeacherTest()
        {
            var moq = new Mock<IUoW>();

            moq.Setup(m => m.UserRepository.GetByID(It.IsAny<object>())).Returns(new User()
            {
                UserID = 0,
                Role = RoleEnum.Admin
            });

            moq.Setup(m => m.TeacherRepository.GetByID(It.IsAny<object>())).Returns(new Teacher());

            IBLL bll = new BLL(moq.Object);



            var usr = bll.GetTeacher(0, 0);



            Assert.NotNull(usr);
        }

        [Test]
        public void DeleteTeacherTest()
        {
            var moq = new Mock<IUoW>();

            moq.Setup(m => m.UserRepository.GetByID(It.IsAny<object>())).Returns(new User()
            {
                UserID = 0,
                Role = RoleEnum.Admin
            });

            moq.Setup(m => m.UserRepository.Delete(It.IsAny<object>())).Verifiable();

            IBLL bll = new BLL(moq.Object);



            var usr = bll.DeleteTeacher(0, 0);



            moq.Verify(m => m.UserRepository.Delete(It.IsAny<object>()), Times.Once);

            Assert.NotNull(usr);
        }

        [Test]
        public void AddTeacherTest()
        {
            var moq = new Mock<IUoW>();

            moq.Setup(m => m.UserRepository.GetByID(It.IsAny<object>())).Returns(new User()
            {
                UserID = 0,
                Role = RoleEnum.Admin
            });

            moq.Setup(m => m.UserRepository.Insert(It.IsAny<User>())).Verifiable();

            IBLL bll = new BLL(moq.Object);



            bll.AddTeacher(0, new E_Schedule_BLL.Entities.Teacher()
            {
                User = new E_Schedule_BLL.Entities.User() { Role = E_Schedule_BLL.Enums.RoleEnum.Teacher }
            });



            moq.Verify(m => m.UserRepository.Insert(It.IsAny<User>()), Times.Once);
        }

        [Test]
        public void UpdTeacherTest()
        {
            var moq = new Mock<IUoW>();

            moq.Setup(m => m.UserRepository.GetByID(It.IsAny<object>())).Returns(new User()
            {
                UserID = 0,
                Role = RoleEnum.Admin
            });

            moq.Setup(m => m.TeacherRepository.Update(0, It.IsAny<Teacher>())).Verifiable();

            IBLL bll = new BLL(moq.Object);



            bll.UpdateTeacher(0, 0, new E_Schedule_BLL.Entities.Teacher());



            moq.Verify(m => m.TeacherRepository.Update(0, It.IsAny<Teacher>()), Times.Once);
        }
    }
}