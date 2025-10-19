using EComm.Domain.Aggregates.ProductAggregate.Events;
using EComm.Domain.Common;

namespace EComm.Domain.Aggregates.ProductAggregate;
public class Product : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public string CategoryName { get; set; }

    public ProductCreatedEvent CreateEvent() =>
        new ProductCreatedEvent(Id, CategoryName);
}