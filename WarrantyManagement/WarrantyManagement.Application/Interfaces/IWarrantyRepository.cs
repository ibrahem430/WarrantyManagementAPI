using System;
using WarrantyManagement.Domain.Entities;

namespace WarrantyManagement.Application.Interfaces;


public interface IWarrantyRepository
{
    Task<Warranty> AddAsync(Warranty warranty);

     Task <IEnumerable<Warranty>>GetAllAsync();

      Task <Warranty?> GetByIdAsync(Guid id);

      Task DeleteAsync(Warranty warranty);
      Task<Warranty?> GetBySaleIdAsync(Guid saleId);

}