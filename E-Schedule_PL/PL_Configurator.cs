using Ninject.Modules;
using AutoMapper;
using E_Schedule_BLL;
using E_Schedule_BLL.Entities;

namespace E_Schedule_PL
{
    public static class PL_Configurator
    {
        public static void CreateMap(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Models.User, User>().ReverseMap();
            cfg.CreateMap<Models.UserCredentials, UserCredentials>().ReverseMap();
            cfg.CreateMap<Models.Student, Student>().ReverseMap();
            cfg.CreateMap<Models.Teacher, Teacher>().ReverseMap();
            cfg.CreateMap<Models.Audience, Audience>().ReverseMap();
            cfg.CreateMap<Models.Group, Group>().ReverseMap();
            cfg.CreateMap<Models.Discipline, Discipline>().ReverseMap();
            cfg.CreateMap<Models.Schedule, Schedule>().ReverseMap();
        }

        public class BLL_Module : NinjectModule
        {
            public override void Load()
            {
                Bind<IBLL>().To<BLL>();
            }
        }
    }
}