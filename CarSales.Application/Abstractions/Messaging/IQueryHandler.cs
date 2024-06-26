﻿using CarSales.Domain.Abstraction;
using MediatR;

namespace CarSales.Application.Abstractions.Messaging
{
    public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
    {
    }
}
