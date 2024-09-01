using Application.Common;
using Application.Dtos;
using MediatR;

namespace Application.Features.Order.Queries
{
    public class GetOrderByIdCommand : IRequest<ResponseOrderDto>
    {
        public GetOrderByIdCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
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
            IQueryable<Domain.Entities.Order> orders = _applicationDbContext.GetTable<Domain.Entities.Order>(Domain.GetTableEnum.AsNoTracking);
            Domain.Entities.Order Order = orders.FirstOrDefault(y => y.Id == request.Id)!;
            return Task.FromResult(new ResponseOrderDto() { OrderNumber = Order.OrderNumber! });
        }
    }
}
