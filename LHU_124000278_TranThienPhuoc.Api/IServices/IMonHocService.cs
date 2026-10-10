using LHU_124000278_TranThienPhuoc.Api.Dto;

namespace LHU_124000278_TranThienPhuoc.Api.IServices
{
    public interface IMonHocService
    {
        Task<List<MonHocDto>> GetAllAsync();

        Task<bool> AddAsync(MonHocAddDto req);

        Task<bool> EditAsync(MonHocEditDto req);

        Task<bool> DeleteAsync(int monHocID);
    }
}
