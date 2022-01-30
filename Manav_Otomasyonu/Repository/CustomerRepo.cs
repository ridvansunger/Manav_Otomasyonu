using Manav_Otomasyonu.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace Manav_Otomasyonu.Repository
{
    public class CustomerRepo : RepositoryBase, IRepository<Customer>
    {
        public int Create(Customer item)
        {
            //select CustomerId,FirstName,LastName,City,Region,Phone,ProductId from Customers
            int id = 0;

            try
            {
                SqlCommand command = new SqlCommand("Sp_Customer_Create_Update", this.Connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CustomerId", item.CustomerId);
                command.Parameters.AddWithValue("@FirstName", item.FirstName);
                command.Parameters.AddWithValue("@LastName", item.LastName);
                command.Parameters.AddWithValue("@City", item.City);
                command.Parameters.AddWithValue("@Region", item.Region);
                command.Parameters.AddWithValue("@Phone", item.Phone);
              

                if (this.Connection.State == ConnectionState.Closed) this.Connection.Open();
                id = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception ex)
            {

                
            }
            finally
            {
                if (this.Connection.State == ConnectionState.Open) this.Connection.Close();
            }
            return id;
            
        }

        public int Update(Customer item)
        {
            int id = 0;

            try
            {
                SqlCommand command = new SqlCommand("Sp_Customer_Create_Update", this.Connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CustomerId", item.CustomerId);
                command.Parameters.AddWithValue("@FirstName", item.FirstName);
                command.Parameters.AddWithValue("@LastName", item.LastName);
                command.Parameters.AddWithValue("@City", item.City);
                command.Parameters.AddWithValue("@Region", item.Region);
                command.Parameters.AddWithValue("@Phone", item.Phone);
       

                if (this.Connection.State == ConnectionState.Closed) this.Connection.Open();
                id = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception ex)
            {
                
                
            }
            finally
            {
                if (this.Connection.State == ConnectionState.Open) this.Connection.Close();
            }
            return id;
        }

        public void Delete(int id)
        {
            try
            {
                SqlCommand command = new SqlCommand("Sp_Customer_Delete", this.Connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CustomerId", id);
                if (this.Connection.State == ConnectionState.Closed) this.Connection.Open();
                command.ExecuteScalar();
            }
            catch (Exception)
            {


            }
            finally
            {
                if (this.Connection.State == ConnectionState.Open) this.Connection.Close();
            }
        }

        public List<Customer> Get()
        {

            List<Customer> customers = new List<Customer>();

            
            try
            {
                SqlCommand command = new SqlCommand("Sp_Customers", this.Connection);
                command.CommandType = CommandType.StoredProcedure;
                if (this.Connection.State == ConnectionState.Closed) this.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var customer = CustomerMapping(reader);
                    customers.Add(customer as Customer);
                   

                }

                if (this.Connection.State == ConnectionState.Open) this.Connection.Close();



            }
            catch (Exception)
            {


            }
            finally
            {
                if (this.Connection.State == ConnectionState.Open) this.Connection.Close();
            }
            return customers;
        }

        private object CustomerMapping(SqlDataReader reader)
        {
            //select CustomerId,FirstName,LastName,City,Region,Phone,ProductId from Customers
            Customer customer = new Customer();
            customer.CustomerId = Convert.ToInt32(reader["CustomerId"]);
            customer.FirstName = reader["FirstName"].ToString();
            customer.LastName = reader["LastName"].ToString();
            customer.City = reader["City"].ToString();
            customer.Region = reader["Region"].ToString();
            customer.Phone = reader["Phone"].ToString();
        

            return customer;
        }

        public Customer GetById(int id)
        {
            Customer customer = null;
            try
            {
                SqlCommand command = new SqlCommand("Sp_Customers", this.Connection);
                command.CommandType = CommandType.StoredProcedure;
                if (this.Connection.State == ConnectionState.Closed) this.Connection.Open();
                command.Parameters.AddWithValue("@CustomerId", id);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    customer = CustomerMapping(reader) as Customer;

                }


            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (this.Connection.State == ConnectionState.Open) this.Connection.Close();
            }
            return customer;
        }


    }
}
