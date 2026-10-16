using MediatR;
using Microsoft.Extensions.Logging;
using MoumenProducts.Application.DTOs;
using MoumenProducts.Application.Interfaces;
using MoumenProducts.Domain.Entities;

namespace MoumenProducts.Application.Products.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductDto>
    {
        private readonly IProductRepository _repository;
        private readonly ILogger<CreateProductCommandHandler> _logger;

        public CreateProductCommandHandler(
            IProductRepository repository,
            ILogger<CreateProductCommandHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Creating product {ProductName} with price {Price}", request.Name, request.Price);

            var product = new Product
            {
                Name = request.Name,
                Price = request.Price
            };

            await _repository.AddAsync(product, cancellationToken);

            _logger.LogInformation("Product created with Id {ProductId}", product.Id);

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };
        }
    }
}
