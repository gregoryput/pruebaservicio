using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace api.Model
{
    public class FacturaRepository
    {
          private string connectionString;

        public FacturaRepository()
        {
            connectionString = @"Server=localhost;Database=DataServicio;Trusted_Connection=True;";
        }

        public IDbConnection connection
        {
            get { return new SqlConnection(connectionString); }
        }
        public void add(Factura fact)
        {
            using (IDbConnection dbConnection = connection)
            {

                string Query = @"insert into Factura (Fecha,ClienteID) values(@Fecha,@ClienteID)";
                dbConnection.Open();
                dbConnection.Execute(Query, fact);
            }
        }

        public IEnumerable<Factura> GetFacturas()
        {
            using (IDbConnection dbConnection = connection)
            {
                string Query = @"Select * from factura";
                dbConnection.Open();
                return dbConnection.Query<Factura>(Query);

            }


        }

        public Factura GetporID(int id)
        {
            using (IDbConnection dbConnection = connection)
            {
                string Query = @"Select * from factura where FacturaID = @ID ";
                dbConnection.Open();
                return dbConnection.Query<Factura>(Query, new { ID = id }).FirstOrDefault();

            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = connection)
            {
                string Query = @"DELETE from factura where FacturaID = @ID ";
                dbConnection.Open();
                dbConnection.Execute(Query, new { ID = id });

            }
        }

        public void Update(Factura fac)
        {
            using (IDbConnection dbConnection = connection)
            {
                string Query = @"Update factura set Fecha=@Fecha,Cliente = @ClienteID where FacturaID = @FacturaID ";
                dbConnection.Open();
                dbConnection.Query(Query,fac);

            }
        }

    }
}