using WarrantyManagement.Domain.Entities;

namespace WarrantyManagement.Application.Responses.Warranties;

public class WarrantyResponse
{
    public Guid Id { get; private set; }

    public Guid SaleId { get; private set; }

    public DateTime StartDate { get; private set; }

    public DateTime EndDate { get; private set; }

    public static WarrantyResponse FromModel(Warranty warranty)
    {
        ArgumentNullException.ThrowIfNull(warranty);

        var warrantyResponse = new WarrantyResponse
        {
            Id = warranty.Id,
            SaleId = warranty.SaleId,
            StartDate = warranty.StartDate,
            EndDate = warranty.EndDate
        };

        return warrantyResponse;
    }

    public static IEnumerable<WarrantyResponse> FromModels( IEnumerable<Warranty> warranties)
    {
        ArgumentNullException.ThrowIfNull(warranties);

        return warranties.Select(FromModel);
    }
}