using MediatR;
using Microsoft.AspNetCore.Mvc;
using MOJ.Application.Features.Statistics.GetGetDashboardStatistics;
using MOJ.Application.Features.Supplier.CreateSupplier;
using MOJ.Application.Features.Supplier.DeleteSupplier;
using MOJ.Application.Features.Supplier.UpdateSupplier;

namespace MOJ.Controllers;

[Route("api/statistics")]
[ApiController]
public class StatisticsController(IMediator mediator) : ControllerBase
{   
    [HttpGet]
    public async Task<IActionResult> Get(
        [FromQuery] GetGetDashboardStatistics.Request request,
        CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(request, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }
}
