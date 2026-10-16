using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using MoumenProducts.Application.DTOs;
using MoumenProducts.Application.Interfaces;

namespace MoumenProducts.Application.Products.Queries
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductDto>>
    {
        private readonly IProductRepository _repository;

        public GetAllProductsQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _repository.GetAllAsync(cancellationToken);

            var filtered = products.AsEnumerable();
            if (!string.IsNullOrWhiteSpace(request.Search))
                filtered = filtered.Where(p => p.Name.Contains(request.Search, StringComparison.OrdinalIgnoreCase));
            if (request.SortByPrice)
                filtered = filtered.OrderBy(p => p.Price);

            return filtered.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price
            }).ToList();
        }
    }
}
