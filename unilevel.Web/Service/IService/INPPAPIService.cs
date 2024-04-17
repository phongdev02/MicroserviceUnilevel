using unilevel.Web.Models;

namespace unilevel.Web.Service.IService
{
    public interface INPPAPIService
    {
        Task<ResponseDto?> getListNPP();
        Task<ResponseDto?> createNPP(NhaPhanPhoiDto model);
        Task<ResponseDto?> getNPPTemplate(string code);
        Task<ResponseDto?> updateNPP(NhaPhanPhoiDto model);
        Task<ResponseDto?> deleteNPP(int id);
        Task<ResponseDto?> findNPP(int id);
        Task<ResponseDto?> getListNPPWithCodeArea(string code);
    }
}
