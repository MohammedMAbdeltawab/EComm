﻿namespace EComm.Domain.Common;
public abstract class BaseEntity
{
    public int Id { get; set; } 
    public bool IsDeleted { get; set; }
    public DateTime CreationTime { get; set; }
}
