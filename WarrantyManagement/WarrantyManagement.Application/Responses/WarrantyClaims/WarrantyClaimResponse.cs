using System.Net.NetworkInformation;
using WarrantyManagement.Domain.Entities;
using WarrantyManagement.Domain.Enums;

namespace WarrantyManagement.Application.Responses.WarrantyClaims;


public class WarrantyClaimResponse
{
        public Guid Id { get; private set; }

    public Guid WarrantyId { get; private set; }

    public DateTime ClaimDate { get; private set; }

    public string ProblemDescription { get; private set; } = string.Empty;

    public ClaimStatus Status { get; private set; }

    public string? TechnicianNotes { get; private set; }

    public DateTime? ResolvedAt { get; private set; }


     public static WarrantyClaimResponse FromModel(WarrantyClaim warrantyClaim)
    {
        ArgumentNullException.ThrowIfNull(warrantyClaim);

        var warrantyClaimResponse = new WarrantyClaimResponse
        {
            Id = warrantyClaim.Id,
            WarrantyId = warrantyClaim.WarrantyId,
            ProblemDescription = warrantyClaim.ProblemDescription,
            ClaimDate = warrantyClaim.ClaimDate,
            Status=warrantyClaim.Status,
            TechnicianNotes=warrantyClaim.TechnicianNotes,
            ResolvedAt=warrantyClaim.ResolvedAt

        };

        return warrantyClaimResponse;
    }

    public static IEnumerable<WarrantyClaimResponse> FromModels( IEnumerable<WarrantyClaim> warrantyClaims)
    {
        ArgumentNullException.ThrowIfNull(warrantyClaims);

        return warrantyClaims.Select(FromModel);
    }
}

