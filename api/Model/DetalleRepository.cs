using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace api.Model
{
    public class DetalleRepository
    {
          private string connectionString;

        public DetalleRepository()
        {
            connectionString = @"Server=localhost;Database=DataServicio;Trusted_Connection=True;";
        }

        public IDbConnection connection
        {
            get { return new SqlConnection(connectionString); }
        }
        public void add(FacturaDetalle fact)
        {
            using (IDbConnection dbConnection = connection)
            {

                string Query = @"insert into FacturaDetalle (Fecha,ClienteID) values(@Fecha,@ClienteID)";
                dbConnection.Open();
                dbConnection.Execute(Query, fact);
            }
        }

        public IEnumerable<FacturaDetalle> GetFacturas()
        {
            using (IDbConnection dbConnection = connection)
            {
                string Query = @"Select * from FacturaDetalle";
                dbConnection.Open();
                return dbConnection.Query<FacturaDetalle>(Query);

            }


        }

        public FacturaDetalle GetporID(int id)
        {
            using (IDbConnection dbConnection = connection)
            {
                string Query = @"Select * from FacturaDetalle where DetalleID = @ID ";
                dbConnection.Open();
                return dbConnection.Query<FacturaDetalle>(Query, new { ID = id }).FirstOrDefault();

            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = connection)
            {
                string Query = @"DELETE from FacturaDetalle where DetalleID = @ID ";
                dbConnection.Open();
                dbConnection.Execute(Query, new { ID = id });

            }
        }

        public void Update(FacturaDetalle fac)
        {
            using (IDbConnection dbConnection = connection)
            {
                string Query = @"Update FacturaDetalle set FacturaID=@FacturaID,Servicio=@Servicio,precio=@precio,cantidad=@cantidad where DetalleID = @DetalleID ";
                dbConnection.Open();
                dbConnection.Query(Query,fac);

            }
        }


    }
}