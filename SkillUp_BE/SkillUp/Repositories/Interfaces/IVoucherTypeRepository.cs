using SkillUp.BussinessObjects.Models;

namespace SkillUp.Repositories.Interfaces
{
    public interface IVoucherTypeRepository
    {
        Task<List<VoucherType>> GetVoucherTypesAsync();
        Task<VoucherType?> GetVoucherTypeByIdAsync(int id);
        Task AddVoucherTypeAsync(VoucherType voucherType);
        Task UpdateVoucherTypeAsync(VoucherType voucherType);
        Task<bool> IsDuplicateAsync(string name, int percentage);
    }
}