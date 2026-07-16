namespace WarrantyManagement.Application.Requests.WarrantyClaim;


public class CreateWarrantyClaimRequest
{


    public Guid WarrantyId { get;  set; }

    public string ProblemDescription { get;  set; }

}