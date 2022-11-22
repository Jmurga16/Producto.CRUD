

using Microsoft.Extensions.Configuration;
using NLog;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseConnection
{
    public class Conexion
    {
        #region Variables
        private readonly String oSqlConnIN;
        private readonly SqlTransaction? sqlTransaction;
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        #endregion


        #region Conexion a la Base de Datos
        public Conexion()
        {
            try
            {

                var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

                IConfiguration configuration = builder.Build();
                oSqlConnIN = configuration["ConnectionStrings:connectionString"];

                //using IDbConnection connection = new SqlConnection(connectionString);
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw;
            }

        }
        #endregion
    
        public string ConnectionString()
        {
            return oSqlConnIN;
        }
    }
}