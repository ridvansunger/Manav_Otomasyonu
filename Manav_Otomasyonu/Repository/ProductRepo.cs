using Manav_Otomasyonu.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
namespace Manav_Otomasyonu.Repository
{
    public class ProductRepo : RepositoryBase, IRepository<Product>
    {
        private SqlConnection con;
        private string connectionString;

        public ProductRepo()
        {
            connectionString = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            con = new SqlConnection(connectionString);
        }


        public int Create(Product item)
        {
            int id = 0;

            try
            {
                SqlCommand command = new SqlCommand("Sp_Product_Create_Update", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ProductId", item.ProductId);
                command.Parameters.AddWithValue("@ProductName", item.ProductName);
                command.Parameters.AddWithValue("@CategoryId", item.CategoryId);
                command.Parameters.AddWithValue("@QuantityPerUnit", item.QuantityPerUnit);
                command.Parameters.AddWithValue("@UnitPrice", item.UnitPrice);
                command.Parameters.AddWithValue("@UnitsInStock", item.UnitsInStock);
                command.Parameters.AddWithValue("@UnitsOnOrder", item.UnitsOnOrder);
                command.Parameters.AddWithValue("@Discontinued", item.Discontinued);

                if (con.State == ConnectionState.Closed) con.Open();
                id = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }
            return id;
        

        }

        public int Update(Product item)
        {
            int id = 0;

            try
            {
                SqlCommand command = new SqlCommand("Sp_Product_Create_Update", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ProductId", item.ProductId);
                command.Parameters.AddWithValue("@ProductName", item.ProductName);
                command.Parameters.AddWithValue("@CategoryId", item.CategoryId);
                command.Parameters.AddWithValue("@QuantityPerUnit", item.QuantityPerUnit);
                command.Parameters.AddWithValue("@UnitPrice", item.UnitPrice);
                command.Parameters.AddWithValue("@UnitsInStock", item.UnitsInStock);
                command.Parameters.AddWithValue("@UnitsOnOrder", item.UnitsOnOrder);
                command.Parameters.AddWithValue("@Discontinued", item.Discontinued);

                if (con.State == ConnectionState.Closed) con.Open();
                id = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }
            return id;
        }

        public void Delete(int id)
        {
            try
            {
                SqlCommand command = new SqlCommand("Sp_Product_Delete", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ProductId", id);
                if (con.State == ConnectionState.Closed) con.Open();
                command.ExecuteScalar();
            }
            catch (Exception)
            {
                
                
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }
        }

        public List<Product> Get()
        {
            List<Product> products = new List<Product>();

            ////select ProductId,ProductName,CategoryId,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,Discontinued from Products
            try
            {
                SqlCommand command = new SqlCommand("Sp_Products", con);
                command.CommandType = CommandType.StoredProcedure;
                if (con.State == ConnectionState.Closed) con.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var product = ProductMapping(reader);             
                    products.Add(product);
                }


            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }
            return products;

        }

        private Product ProductMapping(SqlDataReader reader)
        {
            Product product = new Product();
            product.ProductId = Convert.ToInt32(reader["ProductId"]);
            product.ProductName = reader["ProductName"].ToString();
            product.CategoryId = Convert.ToInt32(reader["CategoryId"]);
            product.QuantityPerUnit = reader["QuantityPerUnit"].ToString();
            product.UnitPrice = Convert.ToDecimal(reader["UnitPrice"]);
            product.UnitsInStock = Convert.ToInt16(reader["UnitsInStock"]);
            product.UnitsOnOrder = Convert.ToInt16(reader["UnitsOnOrder"]);
            product.Discontinued = Convert.ToBoolean(reader["Discontinued"]);

            return product;
        }




        public Product GetById(int id)
        {
            Product product = null;
            try
            {
                SqlCommand command = new SqlCommand("Sp_Products", con);
                command.CommandType = CommandType.StoredProcedure;
                if (con.State == ConnectionState.Closed) con.Open();
                command.Parameters.AddWithValue("@ProductId", id);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    product = ProductMapping(reader);
                   
                }


            }
            catch (Exception)
            {

                
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }
            return product;
        }

    }
}
