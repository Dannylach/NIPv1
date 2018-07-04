using AutoMapper;
using NIPv1.Entities;
using NIPv1.Models;

namespace NIPv1.App_Start
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(dataMapping => {
                dataMapping.CreateMissingTypeMaps = true;
                dataMapping.CreateMap<CompanyEntity, CompanyModel>().ReverseMap();
                dataMapping.CreateMap<CompanyModel, CompanyJsonModel>().ReverseMap();
                dataMapping.CreateMap<LogModel, LogEntity>().ReverseMap();
            });
        }
    }
}