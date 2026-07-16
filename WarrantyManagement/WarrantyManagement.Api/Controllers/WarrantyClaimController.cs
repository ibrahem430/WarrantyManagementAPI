using Microsoft.AspNetCore.Mvc;
using WarrantyManagement.Application.Requests.WarrantyClaim;
using WarrantyManagement.Application.Services;

namespace WarrantyManagement.Api.Controllers;

[ApiController]
[Route("api/warranty-claims")]
public class WarrantyClaimsController(
    WarrantyClaimService warrantyClaimService)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddWarrantyClaim(
        CreateWarrantyClaimRequest request)
    {
        var warrantyClaim =
            await warrantyClaimService.CreateWarrantyClaimAsync(request);

        return CreatedAtRoute(
            "GetWarrantyClaimById",
            new { warrantyClaimId = warrantyClaim.Id },
            warrantyClaim);
    }

    [HttpDelete("{warrantyClaimId:guid}")]
    public async Task<IActionResult> DeleteWarrantyClaim(
        Guid warrantyClaimId)
    {
        await warrantyClaimService.DeleteWarrantyClaimAsync(
            warrantyClaimId);

        return NoContent();
    }

    [HttpGet(
        "{warrantyClaimId:guid}",
        Name = "GetWarrantyClaimById")]
    public async Task<IActionResult> GetWarrantyClaimById(
        Guid warrantyClaimId)
    {
        var warrantyClaim =
            await warrantyClaimService.GetWarrantyClaimAsync(
                warrantyClaimId);

        return Ok(warrantyClaim);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllWarrantyClaims()
    {
        var warrantyClaims =
            await warrantyClaimService.GetAllWarrantyClaimsAsync();

        return Ok(warrantyClaims);
    }

    [HttpPut("{warrantyClaimId:guid}/approve")]
    public async Task<IActionResult> ApproveClaim(
        Guid warrantyClaimId)
    {
        var warrantyClaim =
            await warrantyClaimService.ApproveClaimAsync(
                warrantyClaimId);

        return Ok(warrantyClaim);
    }

    [HttpPut("{warrantyClaimId:guid}/start-repair")]
    public async Task<IActionResult> StartRepairClaim(
        Guid warrantyClaimId)
    {
        var warrantyClaim =
            await warrantyClaimService.StartRepairClaimAsync(
                warrantyClaimId);

        return Ok(warrantyClaim);
    }

    [HttpPut("complete")]
    public async Task<IActionResult> CompleteClaim(
        UpdateWarrantyClaimRequest request)
    {
        var warrantyClaim =
            await warrantyClaimService.CompleteClaimAsync(request);

        return Ok(warrantyClaim);
    }

    [HttpPut("reject")]
    public async Task<IActionResult> RejectClaim(
        UpdateWarrantyClaimRequest request)
    {
        var warrantyClaim =
            await warrantyClaimService.RejectClaimAsync(request);

        return Ok(warrantyClaim);
    }
}