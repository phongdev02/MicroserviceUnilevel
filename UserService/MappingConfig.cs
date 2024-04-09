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
                config.CreateMap<Nhanvien, NhanvienDto>();
                config.CreateMap<NhanvienDto, Nhanvien>();

                config.CreateMap<Nhanvien, NhanvienDtoNoID>();
                config.CreateMap<NhanvienDtoNoID, Nhanvien>();

                //mapper Chucvu
                config.CreateMap<ChucVu, ChucvuDto>();
                config.CreateMap<ChucvuDto, ChucVu>();

                //mapper quyentruycap
                config.CreateMap<QuyenTruyCap, QuyenTruyCapDto>();
                config.CreateMap<QuyenTruyCapDto, QuyenTruyCap>();

                //mapper area
                config.CreateMap<KhuVuc, AreaViewDto>();
                config.CreateMap<AreaViewDto, KhuVuc>();

                //mapper NPP
                config.CreateMap<NhaPhanPhoi, NhaPhanPhoiDto>();
                config.CreateMap<NhaPhanPhoiDto, NhaPhanPhoi>();

            });

            return mappingConfig;
        }
    }
}
