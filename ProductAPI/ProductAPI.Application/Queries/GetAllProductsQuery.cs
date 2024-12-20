using MediatR;
using ProductAPI.Application.DTOs;
using ProductAPI.Domain.Entities;

namespace ProductAPI.Application.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<ProductDTO>>
    {
    }
}