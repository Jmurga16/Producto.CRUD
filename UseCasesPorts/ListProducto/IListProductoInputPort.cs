using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCasesPorts.ListProducto
{
    public interface IListProductoInputPort
    {
        Task GetAll();
        Task GetById(int id);

    }
}
