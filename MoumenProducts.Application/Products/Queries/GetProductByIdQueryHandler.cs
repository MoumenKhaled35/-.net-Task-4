using MediatR;
using Microsoft.Extensions.Logging;
using MoumenProducts.Application.DTOs;
using MoumenProducts.Application.Interfaces;

namespace MoumenProducts.Application.Products.Queries
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto?>
    {
        private readonly IProductRepository _repository;
        private readonly ILogger<GetProductByIdQueryHandler> _logger;

        public GetProductByIdQueryHandler(
            IProductRepository repository,
            ILogger<GetProductByIdQueryHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching product with Id {ProductId}", request.Id);

            var product = await _repository.GetByIdAsync(request.Id, cancellationToken);

            if (product == null)
            {
                _logger.LogWarning("Product with Id {ProductId} was not found", request.Id);
                return null;
            }

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };
        }
    }
}