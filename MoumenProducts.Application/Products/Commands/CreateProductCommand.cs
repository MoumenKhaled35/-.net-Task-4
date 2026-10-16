using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using global::MoumenProducts.Application.DTOs;
using MediatR;
using MoumenProducts.Application.DTOs;

namespace MoumenProducts.Application.Products.Commands
{
    public record CreateProductCommand(string Name, decimal Price) : IRequest<ProductDto>;
}
