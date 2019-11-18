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
        public void GetAllDisciplinesTest()
        {
            var moq = new Mock<IUoW>();

            moq.Setup(m => m.UserRepository.GetByID(It.IsAny<object>())).Returns(new User()
            {
                UserID = 0,
                Role = RoleEnum.Admin
            });

            moq.Setup(m => m.DisciplineRepository.GetAll()).Returns(new List<Discipline>());

            IBLL bll = new BLL(moq.Object);



            var usr = bll.GetAllDisciplines(0);



            Assert.NotNull(usr);
        }

        [Test]
        public void GetDisciplineTest()
        {
            var moq = new Mock<IUoW>();

            moq.Setup(m => m.UserRepository.GetByID(It.IsAny<object>())).Returns(new User()
            {
                UserID = 0,
                Role = RoleEnum.Admin
            });

            moq.Setup(m => m.DisciplineRepository.GetByID(It.IsAny<object>())).Returns(new Discipline());

            IBLL bll = new BLL(moq.Object);



            var usr = bll.GetDiscipline(0, 0);



            Assert.NotNull(usr);
        }

        [Test]
        public void DeleteDisciplineTest()
        {
            var moq = new Mock<IUoW>();

            moq.Setup(m => m.UserRepository.GetByID(It.IsAny<object>())).Returns(new User()
            {
                UserID = 0,
                Role = RoleEnum.Admin
            });

            moq.Setup(m => m.DisciplineRepository.Delete(It.IsAny<object>())).Verifiable();

            IBLL bll = new BLL(moq.Object);



            var usr = bll.DeleteDiscipline(0, 0);



            moq.Verify(m => m.DisciplineRepository.Delete(It.IsAny<object>()), Times.Once);

            Assert.NotNull(usr);
        }

        [Test]
        public void AddDisciplineTest()
        {
            var moq = new Mock<IUoW>();

            moq.Setup(m => m.UserRepository.GetByID(It.IsAny<object>())).Returns(new User()
            {
                UserID = 0,
                Role = RoleEnum.Admin
            });

            moq.Setup(m => m.DisciplineRepository.Insert(It.IsAny<Discipline>())).Verifiable();

            IBLL bll = new BLL(moq.Object);



            bll.AddDiscipline(0, new E_Schedule_BLL.Entities.Discipline());



            moq.Verify(m => m.DisciplineRepository.Insert(It.IsAny<Discipline>()), Times.Once);
        }

        [Test]
        public void UpdDisciplineTest()
        {
            var moq = new Mock<IUoW>();

            moq.Setup(m => m.UserRepository.GetByID(It.IsAny<object>())).Returns(new User()
            {
                UserID = 0,
                Role = RoleEnum.Admin
            });

            moq.Setup(m => m.DisciplineRepository.Update(0, It.IsAny<Discipline>())).Verifiable();

            IBLL bll = new BLL(moq.Object);



            bll.UpdateDiscipline(0, 0, new E_Schedule_BLL.Entities.Discipline());



            moq.Verify(m => m.DisciplineRepository.Update(0, It.IsAny<Discipline>()), Times.Once);
        }
    }
}