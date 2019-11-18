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
        public void GetAllUsersTest()
        {
            var moq = new Mock<IUoW>();

            moq.Setup(m => m.UserRepository.GetByID(It.IsAny<object>())).Returns(new User()
            {
                UserID = 0,
                Role = RoleEnum.Admin
            });

            moq.Setup(m => m.UserRepository.GetAll()).Returns(new List<User>());

            IBLL bll = new BLL(moq.Object);



            var usr = bll.GetAllUsers(0);



            Assert.NotNull(usr);
        }

        [Test]
        public void GetUserTest()
        {
            var moq = new Mock<IUoW>();

            moq.Setup(m => m.UserRepository.GetByID(It.IsAny<object>())).Returns(new User()
            {
                UserID = 0,
                Role = RoleEnum.Admin
            });

            IBLL bll = new BLL(moq.Object);



            var usr = bll.GetUser(0, 0);



            Assert.NotNull(usr);
        }

        [Test]
        public void DeleteUserTest()
        {
            var moq = new Mock<IUoW>();

            moq.Setup(m => m.UserRepository.GetByID(It.IsAny<object>())).Returns(new User()
            {
                UserID = 0,
                Role = RoleEnum.Admin
            });

            moq.Setup(m => m.UserRepository.Delete(It.IsAny<object>())).Verifiable();

            IBLL bll = new BLL(moq.Object);



            var usr = bll.DeleteUser(0, 0);



            moq.Verify(m => m.UserRepository.Delete(It.IsAny<object>()), Times.Once);

            Assert.NotNull(usr);
        }

        [Test]
        public void AddUserTest()
        {
            var moq = new Mock<IUoW>();

            moq.Setup(m => m.UserRepository.GetByID(It.IsAny<object>())).Returns(new User()
            {
                UserID = 0,
                Role = RoleEnum.Admin
            });

            moq.Setup(m => m.UserRepository.Insert(It.IsAny<User>())).Verifiable();

            IBLL bll = new BLL(moq.Object);



            bll.AddUser(0, new E_Schedule_BLL.Entities.User());



            moq.Verify(m => m.UserRepository.Insert(It.IsAny<User>()), Times.Once);
        }

        [Test]
        public void UpdUserTest()
        {
            var moq = new Mock<IUoW>();

            moq.Setup(m => m.UserRepository.GetByID(It.IsAny<object>())).Returns(new User()
            {
                UserID = 0,
                Role = RoleEnum.Admin
            });

            moq.Setup(m => m.UserRepository.Update(0, It.IsAny<User>())).Verifiable();

            IBLL bll = new BLL(moq.Object);



            bll.UpdateUser(0, 0, new E_Schedule_BLL.Entities.User());



            moq.Verify(m => m.UserRepository.Update(0, It.IsAny<User>()), Times.Once);
        }
    }
}