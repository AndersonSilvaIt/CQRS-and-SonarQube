using MediatR;
using ProductAPI.Application.Models;

namespace ProductAPI.Application.Commands
{
    public interface ICommand : IRequest<OperationResult>
    {
    }
}