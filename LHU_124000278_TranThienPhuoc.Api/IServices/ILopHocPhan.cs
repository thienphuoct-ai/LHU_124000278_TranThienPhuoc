using LHU_124000278_TranThienPhuoc.Api.Dto;
namespace LHU_124000278_TranThienPhuoc.Api.IServices
{
    public interface ILopHocPhan
    {
        Task<List<LopHocPhanDto>> GetAllAsync();

        Task<bool> AddAsync(LopHocPhanAddDto req);

        Task<bool> EditAsync(LopHocPhanEditDto req);

        Task<bool> DeleteAsync(int lopHocPhanId);
    }
}
