using UserService.Models;
using UserService.Models.Dto;

namespace UserService.Service.IService
{
    public interface INPPService
    {
        Task<ResponseDto?> getListNPP();
        Task<ResponseDto?> createNPP(NhaPhanPhoiDto model);
        Task<ResponseDto?> createNPPTemplate(string code);
        Task<ResponseDto?> getNPPTemplate(string code);
        Task<ResponseDto?> updateNPP(NhaPhanPhoiDto model);
        Task<ResponseDto?> deleteNPP(int id);
        Task<ResponseDto?> findNPP(int id);
        Task<ResponseDto?> getListNPPWithCodeArea(string code);
    }
}
