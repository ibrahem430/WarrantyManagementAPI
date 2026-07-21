namespace WarrantyManagement.Application.Requests.WarrantyClaim;


public class UpdateWarrantyClaimRequest
{
    public Guid Id { get;  set; }

    public Guid WarrantyId { get;  set; }

    public string ProblemDescription { get;  set; } = string.Empty;

    public string? TechnicianNotes { get;  set; }
}