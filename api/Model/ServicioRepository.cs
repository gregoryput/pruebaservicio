using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;

namespace api.Model
{
    public class ServicioRepository
    {
        private string connectionString;

        public ServicioRepository()
        {
            connectionString = @"Server=localhost;Database=DataServicio;Trusted_Connection=True;";
        }

        public IDbConnection connection
        {
            get { return new SqlConnection(connectionString); }
        }
        public void add(Servicios servi)
        {
            using (IDbConnection dbConnection = connection)
            {

                string Query = @"insert into Servicios (NombreServicio,CategoriaID) values(@NombreServicio,@CategoriaID)";
                dbConnection.Open();
                dbConnection.Execute(Query, servi);
            }
        }

        public IEnumerable<Servicios> GetServicios()
        {
            using (IDbConnection dbConnection = connection)
            {
                string Query = @"Select * from Servicios";
                dbConnection.Open();
                return dbConnection.Query<Servicios>(Query);

            }


        }

        public Servicios GetporID(int id)
        {
            using (IDbConnection dbConnection = connection)
            {
                string Query = @"Select * from Servicios where ServicioID = @ID ";
                dbConnection.Open();
                return dbConnection.Query<Servicios>(Query, new { ID = id }).FirstOrDefault();

            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = connection)
            {
                string Query = @"DELETE from Servicios where ServicioID = @ID ";
                dbConnection.Open();
                dbConnection.Execute(Query, new { ID = id });

            }
        }

        public void Update(Servicios servicios)
        {
            using (IDbConnection dbConnection = connection)
            {
                string Query = @"Update servicios set  NombreServicio=@NombreServicio ,CategoriaID=@CategoriaID where ServicioID = @ServicioID ";
                dbConnection.Open();
                dbConnection.Query(Query,servicios);

            }
        }

    }
}