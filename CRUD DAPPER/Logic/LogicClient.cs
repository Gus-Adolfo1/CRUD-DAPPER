using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
namespace Logic
{
    public class LogicClient
    {
        string connectionString = "Data Source=DESKTOP-6H57L2G;Initial Catalog=CRUD_DAPPER;Integrated Security=True";


        public Cliente Create(Cliente cliente)
        {
            try
            {

                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    Cliente pCliente = new Cliente()
                    {

                        Nombre = cliente.Nombre,
                        Apellido = cliente.Apellido,
                    };

                    string sqlQuery = "INSERT INTO Cliente (Nombre, Apellido) VALUES(@Nombre, @Apellido)";

                    int rowsAffected = db.Execute(sqlQuery, pCliente);

                    if (rowsAffected == 0)
                    {
                        throw new ArgumentException("error al insertar a la base de datos");

                    }
                    return pCliente;
                }

            }
            catch (Exception e)
            {

                throw new ArgumentException("error al insertar a la base de datos");
            }
        }

        public Cliente Update(Cliente cliente, int Id)
        {
            try
            {

                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    Cliente pCliente = new Cliente()
                    {

                        Nombre = cliente.Nombre,
                        Apellido = cliente.Apellido,
                    };

                    string sqlQuery = $"UPDATE Cliente Set Nombre=@Nombre,Apellido=@Apellido where Id={Id}";


                    int rowsAffected = db.Execute(sqlQuery, pCliente);

                    if (rowsAffected == 0)
                    {
                        throw new ArgumentException("error al actualizar a la base de datos");

                    }
                    return pCliente;
                }

            }
            catch (Exception e)
            {

                throw new ArgumentException("error al actualizar a la base de datos");
            }
        }

        public int Delete(int Id)
        {
            try
            {

                using (IDbConnection db = new SqlConnection(connectionString))
                {
                   
                    string sqlQuery = $"DELETE FROM Cliente WHERE Id={Id}";





                    int rowsAffected = db.Execute(sqlQuery);

                    if (rowsAffected == 0)
                    {
                        throw new ArgumentException("error al actualizar a la base de datos");

                    }
                    return rowsAffected;
                }

            }
            catch (Exception e)
            {

                throw new ArgumentException("error al actualizar a la base de datos");
            }
        }

        public List<Cliente> getAll()
        {
            try
            {
                List<Cliente> list = new List<Cliente>();
                using (IDbConnection db = new SqlConnection(connectionString))
                {


                    string sqlQuery = "select * from Cliente";

                    var Clientes = db.Query<Cliente>(sqlQuery);
                    foreach (var item in Clientes)
                    {


                        list.Add(item);
                    }
                    return list;
                }

            }
            catch (Exception e)
            {

                throw new ArgumentException("error al consultar datos");
            }
        }

        public Cliente getId(int Id)
        {

            try
            {
                
                using (IDbConnection db = new SqlConnection(connectionString))
                {


                    string sqlQuery  = "select * from Cliente";

                    var Clientes = db.QuerySingle<Cliente>(sqlQuery);

                    return Clientes;
                }

           
            }
            catch (Exception e)
            {

                throw new ArgumentException("error al consultar datos");
            }
        }
    }
}
