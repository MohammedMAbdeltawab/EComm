using MediatR;

namespace EComm.Domain.Aggregates.ProductAggregate.Events;
public class ProductCreatedEvent: INotification
{
    public int ProductId { get; }
    public string CategoryName { get; }
    public ProductCreatedEvent(int productId, string categoryName)
    {
        ProductId = productId;
        CategoryName = categoryName;
    }
}
