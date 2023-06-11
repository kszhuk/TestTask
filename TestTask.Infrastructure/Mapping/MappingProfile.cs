using AutoMapper;

namespace TestTask.Infrastructure.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to db
            CreateMap<Domain.Models.Order, DataModels.Order>();

            // Db to Domain
            CreateMap<DataModels.Order, Domain.Models.Order>();
        }
    }
}
