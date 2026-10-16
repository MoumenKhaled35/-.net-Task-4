using MediatR;
using MoumenProducts.Application.DTOs;

namespace MoumenProducts.Application.Products.Queries
{
    public record GetAllProductsQuery(string? Search = null, bool SortByPrice = false)
        : IRequest<List<ProductDto>>;
}
