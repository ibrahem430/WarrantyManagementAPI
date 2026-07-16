using WarrantyManagement.Application.Interfaces;
using WarrantyManagement.Application.Requests.WarrantyClaim;
using WarrantyManagement.Application.Responses.WarrantyClaims;
using WarrantyManagement.Domain.Entities;

namespace WarrantyManagement.Application.Services;

public class WarrantyClaimService(
    IWarrantyClaimRepository warrantyClaimRepository,
    IWarrantyRepository warrantyRepository)
{
    public async Task<WarrantyClaimResponse> CreateWarrantyClaimAsync(
        CreateWarrantyClaimRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);

        var warranty =
            await warrantyRepository.GetByIdAsync(request.WarrantyId);

        if (warranty is null)
            throw new KeyNotFoundException("Warranty not found.");

        if (!warranty.IsActive)
            throw new InvalidOperationException(
                "Cannot create a claim for an expired warranty.");

        var existingClaim =
            await warrantyClaimRepository.GetByWarrantyIdAsync(warranty.Id);

        if (existingClaim is not null)
            throw new InvalidOperationException(
                "A warranty claim already exists for this warranty.");

        var warrantyClaim = new WarrantyClaim(
            warranty.Id,
            request.ProblemDescription);

        var savedWarrantyClaim =
            await warrantyClaimRepository.AddAsync(warrantyClaim);

        return WarrantyClaimResponse.FromModel(savedWarrantyClaim);
    }

    public async Task<WarrantyClaimResponse> ApproveClaimAsync(
        Guid warrantyClaimId)
    {
        ValidateId(warrantyClaimId);

        var claim =
            await warrantyClaimRepository.GetByIdAsync(warrantyClaimId);

        if (claim is null)
            throw new KeyNotFoundException("Warranty claim not found.");

        claim.Approve();

        await warrantyClaimRepository.UpdateAsync(claim);

        return WarrantyClaimResponse.FromModel(claim);
    }

    public async Task<WarrantyClaimResponse> StartRepairClaimAsync(
        Guid warrantyClaimId)
    {
        ValidateId(warrantyClaimId);

        var claim =
            await warrantyClaimRepository.GetByIdAsync(warrantyClaimId);

        if (claim is null)
            throw new KeyNotFoundException("Warranty claim not found.");

        claim.StartRepair();

        await warrantyClaimRepository.UpdateAsync(claim);

        return WarrantyClaimResponse.FromModel(claim);
    }

    public async Task<WarrantyClaimResponse> CompleteClaimAsync(
        UpdateWarrantyClaimRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        ValidateId(request.Id);

        var claim =
            await warrantyClaimRepository.GetByIdAsync(request.Id);

        if (claim is null)
            throw new KeyNotFoundException("Warranty claim not found.");

        claim.Complete(request.TechnicianNotes);

        await warrantyClaimRepository.UpdateAsync(claim);

        return WarrantyClaimResponse.FromModel(claim);
    }

    public async Task<WarrantyClaimResponse> RejectClaimAsync(
        UpdateWarrantyClaimRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        ValidateId(request.Id);

        var claim =
            await warrantyClaimRepository.GetByIdAsync(request.Id);

        if (claim is null)
            throw new KeyNotFoundException("Warranty claim not found.");

        claim.Reject(request.TechnicianNotes);

        await warrantyClaimRepository.UpdateAsync(claim);

        return WarrantyClaimResponse.FromModel(claim);
    }

    public async Task<WarrantyClaimResponse> GetWarrantyClaimAsync(Guid id)
    {
        ValidateId(id);

        var claim =
            await warrantyClaimRepository.GetByIdAsync(id);

        if (claim is null)
            throw new KeyNotFoundException("Warranty claim not found.");

        return WarrantyClaimResponse.FromModel(claim);
    }

    public async Task DeleteWarrantyClaimAsync(Guid id)
    {
        ValidateId(id);

        var claim =
            await warrantyClaimRepository.GetByIdAsync(id);

        if (claim is null)
            throw new KeyNotFoundException("Warranty claim not found.");

        await warrantyClaimRepository.DeleteAsync(claim);
    }

    public async Task<IEnumerable<WarrantyClaimResponse>>
        GetAllWarrantyClaimsAsync()
    {
        var claims = await warrantyClaimRepository.GetAllAsync();

        return WarrantyClaimResponse.FromModels(claims);
    }

    private static void ValidateId(Guid id)
    {
        if (id == Guid.Empty)
            throw new ArgumentException(
                "Warranty claim id cannot be empty.",
                nameof(id));
    }
}