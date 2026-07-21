using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WarrantyManagement.Application.Requests.WarrantyClaim;
using WarrantyManagement.Application.Services;

namespace WarrantyManagement.Api.Controllers;

[ApiController]
[Route("api/warranty-claims")]
[Authorize]
public class WarrantyClaimsController(
    WarrantyClaimService warrantyClaimService)
    : ControllerBase
{

    //  Admin=1,
    // Employee=2,
    // user=3
    [HttpPost]
    [Authorize (Roles ="Admin,Employee")]
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
    [Authorize (Roles ="Admin")]
    public async Task<IActionResult> DeleteWarrantyClaim(
        Guid warrantyClaimId)
    {
        await warrantyClaimService.DeleteWarrantyClaimAsync(
            warrantyClaimId);

        return NoContent();
    }
    [Authorize (Roles ="Admin,Employee")]
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
    [Authorize (Roles ="Admin,Employee")]
    [HttpGet]
    public async Task<IActionResult> GetAllWarrantyClaims()
    {
        var warrantyClaims =
            await warrantyClaimService.GetAllWarrantyClaimsAsync();

        return Ok(warrantyClaims);
    }
     [Authorize (Roles ="Admin,Employee")]
    [HttpPut("{warrantyClaimId:guid}/approve")]
    public async Task<IActionResult> ApproveClaim(
        Guid warrantyClaimId)
    {
        var warrantyClaim =
            await warrantyClaimService.ApproveClaimAsync(
                warrantyClaimId);

        return Ok(warrantyClaim);
    }
    [Authorize (Roles ="Admin,Employee")]
    [HttpPut("{warrantyClaimId:guid}/start-repair")]
    public async Task<IActionResult> StartRepairClaim(
        Guid warrantyClaimId)
    {
        var warrantyClaim =
            await warrantyClaimService.StartRepairClaimAsync(
                warrantyClaimId);

        return Ok(warrantyClaim);
    }
     [Authorize (Roles ="Admin,Employee")]
    [HttpPut("complete")]
    public async Task<IActionResult> CompleteClaim(
        UpdateWarrantyClaimRequest request)
    {
        var warrantyClaim =
            await warrantyClaimService.CompleteClaimAsync(request);

        return Ok(warrantyClaim);
    }
    [Authorize (Roles ="Admin,Employee")]
    [HttpPut("reject")]
    public async Task<IActionResult> RejectClaim(
        UpdateWarrantyClaimRequest request)
    {
        var warrantyClaim =
            await warrantyClaimService.RejectClaimAsync(request);

        return Ok(warrantyClaim);
    }
}