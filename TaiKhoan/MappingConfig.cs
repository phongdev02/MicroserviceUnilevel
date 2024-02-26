using AutoMapper;
using TaiKhoan.Models;
using TaiKhoan.Models.Dto;

namespace TaiKhoan
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
            });

            return mappingConfig;
        }
    }
}
