using EComm.Domain.Common;

namespace EComm.Domain.Aggregates.CategoryAggregate;
public class Category : BaseEntity
{
    public string Name { get; set; } 
    public string Description { get; set; } 
}