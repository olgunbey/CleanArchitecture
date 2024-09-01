using Application.Common;
using MediatR;

namespace Application.Features.Order.Commands
{
    public class InsertOrderCommand : IRequest<Domain.Entities.Order>
    {
        public InsertOrderCommand(string orderNumber, decimal orderPrice)
        {
            OrderNumber = orderNumber;
            OrderPrice = orderPrice;
        }
        public string OrderNumber { get; set; }
        public decimal OrderPrice { get; set; }
    }
    public class InsertOrderHandler : IRequestHandler<InsertOrderCommand, Domain.Entities.Order>
    {
        private readonly ICommandApplicationDbContext<Domain.Entities.Order> _orderCommandDb;
        private readonly IApplicationDbContext _applicationDbContext;
        public InsertOrderHandler(ICommandApplicationDbContext<Domain.Entities.Order> orderCommandDb, IApplicationDbContext applicationDbContext)
        {
            _orderCommandDb = orderCommandDb;
            _applicationDbContext = applicationDbContext;
        }
        public async Task<Domain.Entities.Order> Handle(InsertOrderCommand request, CancellationToken cancellationToken)
        {
          IQueryable<Domain.Entities.Order> orders=  _applicationDbContext.GetTable<Domain.Entities.Order>(Domain.GetTableEnum.AsNoTracking);

            if (orders.Any(y => y.OrderNumber == request.OrderNumber))
            {
                var order = new Domain.Entities.Order() { OrderNumber = request.OrderNumber, OrderPrice = request.OrderPrice };
                await _orderCommandDb.AddAsync(order);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);
                return order;
            }
            return new Domain.Entities.Order();
        }
    }
}
