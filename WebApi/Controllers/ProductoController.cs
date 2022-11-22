using Entities.POCOEntities;
using Microsoft.AspNetCore.Mvc;
using Presenters.FormProducto;
using Presenters.ListProducto;
using UseCasesPorts.FormProducto;
using UseCasesPorts.ListProducto;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : Controller
    {

        readonly IListProductoInputPort ListProductoInputPort;
        readonly IListProductoOutputPort ListProductoOutputPort;

        readonly ICreateProductoInputPort CreateInputPort;
        readonly ICreateProductoOutputPort CreateOutputPort;

        readonly IUpdateProductoInputPort UpdateInputPort;
        readonly IUpdateProductoOutputPort UpdateOutputPort;

        readonly IDeleteProductoInputPort DeleteInputPort;
        readonly IDeleteProductoOutputPort DeleteOutputPort;

        public ProductoController(IListProductoInputPort listProductoInputPort, IListProductoOutputPort listProductoOutputPort
            , ICreateProductoInputPort createInputPort, ICreateProductoOutputPort createOutputPort
            , IUpdateProductoInputPort updateInputPort, IUpdateProductoOutputPort updateOutputPort,
            IDeleteProductoInputPort deleteInputPort, IDeleteProductoOutputPort deleteOutputPort) =>
                (ListProductoInputPort, ListProductoOutputPort, CreateInputPort, CreateOutputPort
            , UpdateInputPort, UpdateOutputPort, DeleteInputPort, DeleteOutputPort) =
                (listProductoInputPort, listProductoOutputPort, createInputPort, createOutputPort,
            updateInputPort, updateOutputPort, deleteInputPort, deleteOutputPort);


        //EndPoint para Obtener Productos
        [HttpGet]
        public async Task<IEnumerable<Producto>> GetAll()
        {

            await ListProductoInputPort.GetAll();

            var Presenter = ListProductoOutputPort as ListProductoPresenter;

            return Presenter.Content;
        }

        //EndPoint para Obtener Producto por Id
        [HttpGet("{id}")]
        public async Task<IEnumerable<Producto>> GetById(int id)
        {

            await ListProductoInputPort.GetById(id);

            var Presenter = ListProductoOutputPort as ListProductoPresenter;

            return Presenter.Content;
        }

        //EndPoint para Crear Producto
        [HttpPost]
        public async Task<int> Create(Producto request)
        {

            await CreateInputPort.Create(request);
            var Presenter = CreateOutputPort as CreateProductoPresenter;

            return Presenter.Content;
        }

        //EndPoint para Actualizar Producto
        [HttpPut]
        public async Task<int> Update(Producto request)
        {

            await UpdateInputPort.Update(request);
            var Presenter = UpdateOutputPort as UpdateProductoPresenter;

            return Presenter.Content;
        }

        //EndPoint para borrado lógico Producto
        [HttpDelete("{id}")]
        public async Task<int> Delete(int id)
        {

            await DeleteInputPort.Delete(id);
            var Presenter = DeleteOutputPort as DeleteProductoPresenter;

            return Presenter.Content;
        }
    }
}
