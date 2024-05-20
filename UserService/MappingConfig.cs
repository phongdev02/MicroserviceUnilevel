using AutoMapper;
using UserService.Models;
using UserService.Models.Dto;

namespace UserService
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Account, AccountDto>();
                config.CreateMap<AccountDto, Account>();

                config.CreateMap<Account, AccountDtoNoID>();
                config.CreateMap<AccountDtoNoID, Account>();

                //mapper area
                config.CreateMap<Area, AreaViewDto>();
                config.CreateMap<AreaViewDto, Area>();

                config.CreateMap<Area, AreaDto>();
                config.CreateMap<AreaDto, Area>();

                config.CreateMap<Title, TitleDto>();
                config.CreateMap<TitleDto, Title>();


                /*  //mapper NPP
                  config.CreateMap<distributor, NhaPhanPhoiDto>();
                  config.CreateMap<NhaPhanPhoiDto, distributor>();*/

                //vieng tham
                config.CreateMap<ViengTham,  ViengThamDto>();
                config.CreateMap<ViengThamDto, ViengTham>();

            });

            return mappingConfig;
        }
    }
}
