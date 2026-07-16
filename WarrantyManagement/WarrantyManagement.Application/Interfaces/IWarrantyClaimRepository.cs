using WarrantyManagement.Domain.Entities;

namespace WarrantyManagement.Application.Interfaces;


public interface IWarrantyClaimRepository
{
    Task<WarrantyClaim> AddAsync(WarrantyClaim warrantyClaim);

     Task <IEnumerable<WarrantyClaim>>GetAllAsync();

     Task  UpdateAsync(WarrantyClaim warrantyClaim);

      Task <WarrantyClaim?> GetByIdAsync(Guid id);

      Task DeleteAsync(WarrantyClaim warrantyClaim);

      Task<WarrantyClaim> GetByWarrantyIdAsync(Guid warrantyId);
}