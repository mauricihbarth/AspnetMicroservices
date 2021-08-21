﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Contracts.Persistence;
using Ordering.Application.Features.Orders.Commands.CheckoutOrder;
using Ordering.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Commands.UpdateOrder
{

    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CheckoutOrderCommandHandler> _logger;

        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var orderToUpdate = await _orderRepository.GetByIdAsync(request.Id);

            if (orderToUpdate == null)
            {
                _logger.LogError("Order not exist on database!");
            }
            
            _mapper.Map(request,orderToUpdate,typeof(UpdateOrderCommand), typeof(Order));
            await _orderRepository.UpdateAsync(orderToUpdate);
            _logger.LogError($"Order {orderToUpdate.Id} is successfully updated");
            return Unit.Value;
        }
    }
}
