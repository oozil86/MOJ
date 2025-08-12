using MediatR;
using Microsoft.AspNetCore.Mvc;
using MOJ.Application.Features.Product.CreateProduct;
using MOJ.Application.Features.Product.DeleteProduct;
using MOJ.Application.Features.Product.GetProduct;
using MOJ.Application.Features.Product.GetProducts;
using MOJ.Application.Features.Product.UpdateProduct;

namespace MOJ.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post(
        [FromBody] CreateProduct.Request request,
        CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(request, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet]
    public async Task<IActionResult> Get(
       [FromQuery] GetProducts.Request request,
       CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(request, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("get-by-reference/{Reference}")]
    public async Task<IActionResult> GetByReference(
        GetProduct.Request request,
       CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(request, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpPut]
    public async Task<IActionResult> Put(
      UpdateProduct.Request request,
      CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(request, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(
     DeleteProduct.Request request,
     CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(request, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }
}