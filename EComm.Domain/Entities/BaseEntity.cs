namespace EComm.Domain.Entities;
public abstract class BaseEntity
{
    public int Id { get; set; } 
    public bool IsDeleted { get; set; }
    public DateTime CreationTime { get; set; }
}
