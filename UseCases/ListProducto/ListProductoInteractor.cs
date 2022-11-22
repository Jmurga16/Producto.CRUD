using Dapper;
using DatabaseConnection;
using Entities.Exceptions;
using Entities.POCOEntities;
using System.Data;
using System.Data.SqlClient;
using UseCasesPorts.ListProducto;

namespace UseCases.ListProducto
{
    public class ListProductoInteractor : IListProductoInputPort
    {
        readonly Conexion conexion;
        readonly IListProductoOutputPort OutputPort;

        public ListProductoInteractor(Conexion conexion, IListProductoOutputPort outputPort)
        {
            this.conexion = new Conexion();
            OutputPort = outputPort;
        }

        //Obtener Lista de todos los Productos
        public async Task GetAll()
        {


            IEnumerable<Producto> response;

            try
            {
                using IDbConnection connection = new SqlConnection(conexion.ConnectionString());

                List<Producto> listaProductos = new List<Producto>();


                IEnumerable<Producto> productos = await connection.QueryAsync<Producto>(
                    sql: "dbo.USP_GET_PRODUCTOS",
                    param: new { @nOpcion = 1 },
                    commandType: CommandType.StoredProcedure
                );


                foreach (Producto producto in productos)
                {
                    listaProductos.Add(producto);
                }
                
                response = listaProductos;

            }
            catch (Exception ex)
            {
                throw new GeneralException("Error al listar productos.", ex.Message);
            }

            await OutputPort.Handle(response);
        }


        //Obtener Lista de Productos por Id
        public async Task GetById(int IdProducto)
        {

            IEnumerable<Producto> response;

            try
            {
                using IDbConnection connection = new SqlConnection(conexion.ConnectionString());

                List<Producto> listaProductos = new List<Producto>();


                IEnumerable<Producto> productos = await connection.QueryAsync<Producto>(
                    sql: "dbo.USP_GET_PRODUCTOS",
                    param: new { @nOpcion = 2 , @IdProducto = IdProducto },
                    commandType: CommandType.StoredProcedure
                );


                foreach (Producto producto in productos)
                {
                    listaProductos.Add(producto);
                }

                response = listaProductos;

            }
            catch (Exception ex)
            {
                throw new GeneralException("Error al listar producto.", ex.Message);
            }

            await OutputPort.Handle(response);
        }

    }
}
