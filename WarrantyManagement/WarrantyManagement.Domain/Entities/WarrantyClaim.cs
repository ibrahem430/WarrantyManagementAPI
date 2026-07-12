using WarrantyManagement.Domain.Enums;

namespace WarrantyManagement.Domain.Entities;


public class WarrantyClaim
{
    public Guid Id { get; private set; }

    public Guid WarrantyId { get; private set; }

    public DateTime ClaimDate { get; private set; }

    public string ProblemDescription { get; private set; }

    public ClaimStatus Status { get; private set; }

    public string? TechnicianNotes { get; private set; }

    public DateTime? ResolvedAt { get; private set; }


    public WarrantyClaim(Guid warrantyId,string problemDescription )
    {
        ValidateWarrantyId(warrantyId);
        ValidateProblemDescription(problemDescription);
        Id=Guid.NewGuid();
        WarrantyId=warrantyId;
        ClaimDate=DateTime.UtcNow;
        ProblemDescription=problemDescription;
        Status=ClaimStatus.Pending;
        TechnicianNotes=null;
        ResolvedAt=null;
    }


     private static void ValidateWarrantyId(Guid warrantyId)
    {
        if(warrantyId==Guid.Empty)
        throw new ArgumentException("warrantyId must have Value");
    }

     private static void ValidateProblemDescription(string problemDescription)
    {
        if(string.IsNullOrWhiteSpace(problemDescription))
        throw new ArgumentException("problem Description must have value ");
    }
     
     private static void ValidateTechnicianNotes(string technicianNotes)
    {
        if(string.IsNullOrWhiteSpace(technicianNotes))
        throw new ArgumentException("technicianNotes must have value ");
    }

    public void Approve()
    {
        if (Status!=ClaimStatus.Pending)
        throw new InvalidOperationException( "Only pending claims can be approved.");
        Status=ClaimStatus.Approved;
    }
      public void StartRepair()
    {
          if (Status!=ClaimStatus.Approved)
        throw new InvalidOperationException( "Only Approved claims can be InRepair.");
        Status=ClaimStatus.InRepair;
    }
      public void Complete(string technicianNotes)
    {
         if (Status!=ClaimStatus.InRepair)
        throw new InvalidOperationException( "Only Repair claims can be completed.");

        ValidateTechnicianNotes(technicianNotes);

        Status=ClaimStatus.Completed;
        TechnicianNotes= technicianNotes;
        ResolvedAt=DateTime.UtcNow;
    }
      public void Reject(string technicianNotes)
    {
       

         if (Status==ClaimStatus.Completed)
        throw new InvalidOperationException( "it is Completed you can not be Rejected.");

      if (Status==ClaimStatus.Rejected)
        throw new InvalidOperationException( "it is already Rejected.");
        
       if (Status!=ClaimStatus.Pending)
        throw new InvalidOperationException( "Only pending claims can be Rejected.");
        ValidateTechnicianNotes(technicianNotes);

        Status=ClaimStatus.Rejected;
        TechnicianNotes= technicianNotes;
        ResolvedAt=DateTime.UtcNow;
    }
}

