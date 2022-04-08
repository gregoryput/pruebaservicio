using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace api.Model
{

    public class ClienteRopository
    {
        private string connectionString;

        public ClienteRopository()
        {
            connectionString = @"Server=localhost;Database=DataServicio;Trusted_Connection=True;";
        }

        public IDbConnection connection
        {
            get { return new SqlConnection(connectionString); }
        }
        public void add(Cliente cl)
        {
            using (IDbConnection dbConnection = connection)
            {

                string Query = @"insert into Clientes (NombreCompleto ,RNC ,Direccion,Sector,Ciudad, Provincia ,Telefono ,Correo  ) values(@NombreCompleto ,@RNC,@Direccion,@Sector,@Ciudad,@Provincia,@Telefono,@Correo)";
                dbConnection.Open();
                dbConnection.Execute(Query, cl);
            }
        }

        public IEnumerable<Cliente> Get()
        {
            using (IDbConnection dbConnection = connection)
            {
                string Query = @"Select * from Clientes";
                dbConnection.Open();
                return dbConnection.Query<Cliente>(Query);

            }


        }

        public Cliente GetporID(int id)
        {
            using (IDbConnection dbConnection = connection)
            {
                string Query = @"Select * from Clientes where ClienteID  = @ID ";
                dbConnection.Open();
                return dbConnection.Query<Cliente>(Query, new { ID = id }).FirstOrDefault();

            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = connection)
            {
                string Query = @"DELETE from Clientes where ClienteID  = @ID ";
                dbConnection.Open();
                dbConnection.Execute(Query, new { ID = id });

            }
        }

        public void Update(Cliente cl)
        {
            using (IDbConnection dbConnection = connection)
            {
                string Query = @"Update Clientes set  NombreCompleto = @NombreCompleto ,RNC=@RNC,Direccion=@Direccion,Sector=@Sector,Ciudad =@Ciudad,Provincia = @Provincia,Telefono =@Telefono, Correo = @Correo where ClienteID  = @ClienteID  ";
                dbConnection.Open();
                dbConnection.Query(Query, cl);

            }
        }

    }



}