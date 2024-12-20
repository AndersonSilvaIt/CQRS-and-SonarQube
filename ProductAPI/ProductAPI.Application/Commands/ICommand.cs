using MediatR;

namespace ProductAPI.Application.Commands
{
    public interface ICommand : IRequest<bool>
    {
    }
}