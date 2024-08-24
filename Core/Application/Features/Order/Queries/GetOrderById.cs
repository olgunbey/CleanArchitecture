using Application.Common;
using Application.Dtos;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Order.Queries
{
    public class GetOrderByIdCommand:IRequest<ResponseOrderDto>
    {
        public GetOrderByIdCommand(int id)
        {
            Id = id;
        }
        public int Id{ get; set; }
    }
    public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdCommand, ResponseOrderDto>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        public GetOrderByIdHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public Task<ResponseOrderDto> Handle(GetOrderByIdCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Order Order = _applicationDbContext.Order.FirstOrDefault(y => y.Id == request.Id)!;

            return Task.FromResult(new ResponseOrderDto() { OrderNumber = Order.OrderNumber! });
        }
    }
}
