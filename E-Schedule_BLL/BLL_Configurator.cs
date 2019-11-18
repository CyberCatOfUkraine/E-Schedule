using Ninject.Modules;
using AutoMapper;
using E_Schedule_DAL;
using E_Schedule_DAL.ORMs;

namespace E_Schedule_BLL
{
    public static class BLL_Configurator
    {
        public static void CreateMap(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Entities.User, User>().ReverseMap();
            cfg.CreateMap<Entities.UserCredentials, UserCredentials>().ReverseMap();
            cfg.CreateMap<Entities.Student, Student>().ReverseMap();
            cfg.CreateMap<Entities.Teacher, Teacher>().ReverseMap();
            cfg.CreateMap<Entities.Audience, Audience>().ReverseMap();
            cfg.CreateMap<Entities.Group, Group>().ReverseMap();
            cfg.CreateMap<Entities.Discipline, Discipline>().ReverseMap();
            cfg.CreateMap<Entities.Schedule, Schedule>().ReverseMap();
        }

        public class DAL_Module : NinjectModule
        {
            public override void Load()
            {
                Bind<IUoW>().To<UoW>();
            }
        }
    }
}