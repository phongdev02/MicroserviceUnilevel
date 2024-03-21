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

                //mapper Chucvu
                config.CreateMap<ChucVu, ChucvuDto>();
                config.CreateMap<ChucvuDto, ChucVu>();

                //mapper quyentruycap
                config.CreateMap<QuyenTruyCap, QuyenTruyCapDto>();
                config.CreateMap<QuyenTruyCapDto, QuyenTruyCap>();

            });

            return mappingConfig;
        }
    }
}
