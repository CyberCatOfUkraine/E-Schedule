using NUnit.Framework;
using E_Schedule_BLL;
using AutoMapper;
using AutoMapper.Configuration;

namespace E_Schedule.Tests
{
    [TestFixture]
    partial class UnitTest
    {
        public UnitTest()
        {
            var cfg = new MapperConfigurationExpression();
            BLL_Configurator.CreateMap(cfg);
            Mapper.Initialize(cfg);
        }
    }
}