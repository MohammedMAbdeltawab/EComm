using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComm.Domain.Entities;
public abstract class BaseEntity
{
    public Guid Id { get; set; } 
    public bool IsDeleted { get; set; }
    public DateTime CreationTime { get; set; }
}
