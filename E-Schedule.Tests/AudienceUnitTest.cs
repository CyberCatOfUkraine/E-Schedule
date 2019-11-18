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
        public void GetAllAudiencesTest()
        {
            var moq = new Mock<IUoW>();

            moq.Setup(m => m.UserRepository.GetByID(It.IsAny<object>())).Returns(new User()
            {
                UserID = 0,
                Role = RoleEnum.Admin
            });

            moq.Setup(m => m.AudienceRepository.GetAll()).Returns(new List<Audience>());

            IBLL bll = new BLL(moq.Object);



            var usr = bll.GetAllAudiences(0);



            Assert.NotNull(usr);
        }

        [Test]
        public void GetAudienceTest()
        {
            var moq = new Mock<IUoW>();

            moq.Setup(m => m.UserRepository.GetByID(It.IsAny<object>())).Returns(new User()
            {
                UserID = 0,
                Role = RoleEnum.Admin
            });

            moq.Setup(m => m.AudienceRepository.GetByID(It.IsAny<object>())).Returns(new Audience());

            IBLL bll = new BLL(moq.Object);



            var usr = bll.GetAudience(0, 0);



            Assert.NotNull(usr);
        }

        [Test]
        public void DeleteAudienceTest()
        {
            var moq = new Mock<IUoW>();

            moq.Setup(m => m.UserRepository.GetByID(It.IsAny<object>())).Returns(new User()
            {
                UserID = 0,
                Role = RoleEnum.Admin
            });

            moq.Setup(m => m.AudienceRepository.Delete(It.IsAny<object>())).Verifiable();

            IBLL bll = new BLL(moq.Object);



            var usr = bll.DeleteAudience(0, 0);



            moq.Verify(m => m.AudienceRepository.Delete(It.IsAny<object>()), Times.Once);

            Assert.NotNull(usr);
        }

        [Test]
        public void AddAudienceTest()
        {
            var moq = new Mock<IUoW>();

            moq.Setup(m => m.UserRepository.GetByID(It.IsAny<object>())).Returns(new User()
            {
                UserID = 0,
                Role = RoleEnum.Admin
            });

            moq.Setup(m => m.AudienceRepository.Insert(It.IsAny<Audience>())).Verifiable();

            IBLL bll = new BLL(moq.Object);



            bll.AddAudience(0, new E_Schedule_BLL.Entities.Audience());



            moq.Verify(m => m.AudienceRepository.Insert(It.IsAny<Audience>()), Times.Once);
        }

        [Test]
        public void UpdAudienceTest()
        {
            var moq = new Mock<IUoW>();

            moq.Setup(m => m.UserRepository.GetByID(It.IsAny<object>())).Returns(new User()
            {
                UserID = 0,
                Role = RoleEnum.Admin
            });

            moq.Setup(m => m.AudienceRepository.Update(0, It.IsAny<Audience>())).Verifiable();

            IBLL bll = new BLL(moq.Object);



            bll.UpdateAudience(0, 0, new E_Schedule_BLL.Entities.Audience());



            moq.Verify(m => m.AudienceRepository.Update(0, It.IsAny<Audience>()), Times.Once);
        }
    }
}