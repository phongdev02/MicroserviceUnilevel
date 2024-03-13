using AutoMapper;
using FileRetention.Models;
using FileRetention.Models.Dto;

namespace FileRetention
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Tep, TepDto>();
                config.CreateMap<TepDto, Tep>();
            });

            return mappingConfig;
        }
    }
}
