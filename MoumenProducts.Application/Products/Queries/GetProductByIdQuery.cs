using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using MoumenProducts.Application.DTOs;

namespace MoumenProducts.Application.Products.Queries
{
    public record GetProductByIdQuery(int Id) : IRequest<ProductDto?>;
}