using Entities.POCOEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCasesPorts.FormProducto
{
    public interface IUpdateProductoInputPort
    {
        Task Update(Producto request);

    }
}
