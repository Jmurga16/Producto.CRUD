using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCasesPorts.FormProducto
{
    public interface IUpdateProductoOutputPort
    {
        Task Handle(int Id);
    }
}
