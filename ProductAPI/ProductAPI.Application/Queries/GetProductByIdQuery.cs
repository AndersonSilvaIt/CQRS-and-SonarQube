using MediatR;
using ProductAPI.Application.DTOs;

namespace ProductAPI.Application.Queries
{
    public class GetProductByIdQuery : IRequest<ProductDTO>
    {
        public Guid Id { get; }

        public GetProductByIdQuery(Guid id)
        {
            Id = id;
        }

    }
}