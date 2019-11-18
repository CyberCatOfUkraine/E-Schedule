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
        public void GetAllGroupsTest()
        {
            var moq = new Mock<IUoW>();

            moq.Setup(m => m.UserRepository.GetByID(It.IsAny<object>())).Returns(new User()
            {
                UserID = 0,
                Role = RoleEnum.Admin
            });

            moq.Setup(m => m.GroupRepository.GetAll()).Returns(new List<Group>());

            IBLL bll = new BLL(moq.Object);



            var usr = bll.GetAllGroups(0);



            Assert.NotNull(usr);
        }

        [Test]
        public void GetGroupTest()
        {
            var moq = new Mock<IUoW>();

            moq.Setup(m => m.UserRepository.GetByID(It.IsAny<object>())).Returns(new User()
            {
                UserID = 0,
                Role = RoleEnum.Admin
            });

            moq.Setup(m => m.GroupRepository.GetByID(It.IsAny<object>())).Returns(new Group());

            IBLL bll = new BLL(moq.Object);



            var usr = bll.GetGroup(0, 0);



            Assert.NotNull(usr);
        }

        [Test]
        public void DeleteGroupTest()
        {
            var moq = new Mock<IUoW>();

            moq.Setup(m => m.UserRepository.GetByID(It.IsAny<object>())).Returns(new User()
            {
                UserID = 0,
                Role = RoleEnum.Admin
            });

            moq.Setup(m => m.GroupRepository.Delete(It.IsAny<object>())).Verifiable();

            IBLL bll = new BLL(moq.Object);



            var usr = bll.DeleteGroup(0, 0);



            moq.Verify(m => m.GroupRepository.Delete(It.IsAny<object>()), Times.Once);

            Assert.NotNull(usr);
        }

        [Test]
        public void AddGroupTest()
        {
            var moq = new Mock<IUoW>();

            moq.Setup(m => m.UserRepository.GetByID(It.IsAny<object>())).Returns(new User()
            {
                UserID = 0,
                Role = RoleEnum.Admin
            });

            moq.Setup(m => m.GroupRepository.Insert(It.IsAny<Group>())).Verifiable();

            IBLL bll = new BLL(moq.Object);



            bll.AddGroup(0, new E_Schedule_BLL.Entities.Group());



            moq.Verify(m => m.GroupRepository.Insert(It.IsAny<Group>()), Times.Once);
        }

        [Test]
        public void UpdGroupTest()
        {
            var moq = new Mock<IUoW>();

            moq.Setup(m => m.UserRepository.GetByID(It.IsAny<object>())).Returns(new User()
            {
                UserID = 0,
                Role = RoleEnum.Admin
            });

            moq.Setup(m => m.GroupRepository.Update(0, It.IsAny<Group>())).Verifiable();

            IBLL bll = new BLL(moq.Object);



            bll.UpdateGroup(0, 0, new E_Schedule_BLL.Entities.Group());



            moq.Verify(m => m.GroupRepository.Update(0, It.IsAny<Group>()), Times.Once);
        }
    }
}