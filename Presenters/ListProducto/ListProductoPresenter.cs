using Entities.POCOEntities;
using UseCasesPorts.ListProducto;

namespace Presenters.ListProducto
{
    public class ListProductoPresenter: IListProductoOutputPort, IPresenter<IEnumerable<Producto>>
    {
        public IEnumerable<Producto> Content { get; private set; }

        public Task Handle(IEnumerable<Producto> Productos)
        {
            Content = Productos;
            return Task.CompletedTask;
        }
    }
}
