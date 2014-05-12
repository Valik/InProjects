using AutoMapper;
using InProjects.Business.Models;
using InProjects.Business.Models.ViewModels.Account;

namespace InProjects.Business.Mappers
{
    public class CommonMapper : IMapper
    {
        static CommonMapper()
        {
            Mapper.CreateMap<User, RegisterViewModel>();
            Mapper.CreateMap<RegisterViewModel, User>();
        }

        public TMap Map<TMap>(object source)
        {
            return Mapper.Map<TMap>(source);
        }
    }
}