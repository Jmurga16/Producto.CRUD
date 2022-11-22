using Dapper;
using DatabaseConnection;
using Entities.Exceptions;
using Entities.POCOEntities;
using System.Data;
using System.Data.SqlClient;
using UseCasesPorts.FormProducto;

namespace UseCases.CreateProducto
{
    public class CreateProductoInteractor : ICreateProductoInputPort
    {
        readonly Conexion conexion;
        readonly ICreateProductoOutputPort OutputPort;

        public CreateProductoInteractor(Conexion conexion, ICreateProductoOutputPort outputPort)
        {
            this.conexion = new Conexion();
            OutputPort = outputPort;
        }

        //Crear Productos
        public async Task Create(Producto request)
        {

            int response = 0;

            try
            {
                using IDbConnection connection = new SqlConnection(conexion.ConnectionString());

                var parameters = new DynamicParameters();               
                parameters.Add("@Nombre", request.Nombre);
                parameters.Add("@Precio", request.Precio);
                parameters.Add("@Stock", request.Stock);
                parameters.Add("@Id", dbType: DbType.Int32, direction: ParameterDirection.Output);

                int result = await connection.ExecuteAsync(sql: "dbo.[USP_CREATE_PRODUCTO]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                response = parameters.Get<int>("@Id");

            }


            catch (Exception ex)
            {
                throw new GeneralException("Error al crear productos.", ex.Message);
            }

            await OutputPort.Handle(response);
        }
    }
}
