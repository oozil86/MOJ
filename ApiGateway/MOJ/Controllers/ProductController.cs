using MediatR;
using Microsoft.AspNetCore.Mvc;
using MOJ.Application.Features.Product.CreateProduct;
using MOJ.Application.Features.Product.DeleteProduct;

namespace MOJ.Controllers;

[ApiController]
[Route("api/product")]
public class ProductController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post(
        [FromBody] CreateProduct.Request request,
        CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(request, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    //[HttpGet("{Reference}")]
    //public async Task<IActionResult> Get(
    //   [FromRoute] GetProduct.Request request,
    //   CancellationToken cancellationToken = default)
    //{
    //    var result = await mediator.Send(request, cancellationToken);
    //    return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    //}

    //[HttpPut]
    //public async Task<IActionResult> Put(
    //  UpdateProduct.Request request,
    //  CancellationToken cancellationToken = default)
    //{
    //    var result = await mediator.Send(request, cancellationToken);
    //    return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    //}

    [HttpDelete]
    public async Task<IActionResult> Delete(
     DeleteProduct.Request request,
     CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(request, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }
}