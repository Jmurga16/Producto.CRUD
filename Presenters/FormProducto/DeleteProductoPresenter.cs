using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCasesPorts.FormProducto;

namespace Presenters.FormProducto
{
    public class DeleteProductoPresenter : IDeleteProductoOutputPort, IPresenter<int>
    {
        public int Content { get; private set; }

        public Task Handle(int Id)
        {
            Content = Id;
            return Task.CompletedTask;
        }
    }
}
