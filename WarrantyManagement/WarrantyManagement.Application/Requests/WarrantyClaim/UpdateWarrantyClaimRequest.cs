namespace WarrantyManagement.Application.Requests.WarrantyClaim;


public class UpdateWarrantyClaimRequest
{
    public Guid Id { get; private set; }

    public Guid WarrantyId { get; private set; }

    public string ProblemDescription { get; private set; } = string.Empty;

    public string? TechnicianNotes { get; private set; }
}