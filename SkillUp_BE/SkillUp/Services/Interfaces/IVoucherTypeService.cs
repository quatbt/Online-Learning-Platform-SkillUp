using SkillUp.BussinessObjects.DTOs;

namespace SkillUp.Services.Interfaces
{
    public interface IVoucherTypeService
    {
        Task<List<VoucherTypeResponse>> GetAllAsync();
        Task<VoucherTypeResponse?> GetByIdAsync(int id);
        Task<VoucherTypeResponse> CreateAsync(VoucherTypeRequest request);
        Task<bool> UpdateAsync(int id, VoucherTypeRequest request);
        Task<bool> UpdateStatusAsync(int id, bool isActive);
    }
}