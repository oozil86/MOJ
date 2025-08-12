using MediatR;
using Microsoft.AspNetCore.Mvc;
using MOJ.Application.Features.Supplier.CreateSupplier;
using MOJ.Application.Features.Supplier.DeleteSupplier;
using MOJ.Application.Features.Supplier.GetSupplier;
using MOJ.Application.Features.Supplier.GetSuppliers;
using MOJ.Application.Features.Supplier.UpdateSupplier;

namespace MOJ.Controllers;

[Route("api/suppliers")]
[ApiController]
public class SuppliersController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get(
        [FromQuery] GetSuppliers.Request request,
        CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(request, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("get-by-reference/{Reference}")]
    public async Task<IActionResult> GetByReference(
      GetSupplier.Request request,
       CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(request, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpPost]
    public async Task<IActionResult> Post(
        [FromBody] CreateSupplier.Request request,
        CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(request, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpPut]
    public async Task<IActionResult> Put(
        [FromBody] UpdateSupplier.Request request,
        CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(request, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(
        [FromBody] DeleteSupplier.Request request,
        CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(request, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }
}
