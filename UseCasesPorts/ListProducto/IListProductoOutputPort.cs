using Entities.POCOEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCasesPorts.ListProducto
{
    public interface IListProductoOutputPort
    {
        Task Handle(IEnumerable<Producto> productos);

    }
}
