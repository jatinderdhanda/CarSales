using CarSales.Domain.Abstraction;
using MediatR;

namespace CarSales.Application.Abstractions.Messaging
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
