using MediatR;
using Microsoft.AspNetCore.Mvc;
using MoumenProducts.Application.DTOs;
using MoumenProducts.Application.Products.Commands;
using MoumenProducts.Application.Products.Queries;

namespace MoumenProducts.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetAll([FromQuery] string? search, [FromQuery] bool sortByPrice, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllProductsQuery(search, sortByPrice), cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetById(int id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetProductByIdQuery(id), cancellationToken);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> Create(
            [FromBody] CreateProductDto dto, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(
                new CreateProductCommand(dto.Name, dto.Price), cancellationToken);

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
    }
}
