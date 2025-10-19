using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComm.Application.Features.Products.Commands.Delete;
public class DeleteProductCommand : IRequest<bool>
{
    public int Id { get; set; }
    public DeleteProductCommand(int id) => Id = id;
}
