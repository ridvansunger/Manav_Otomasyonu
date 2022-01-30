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
    public class CategoryRepo : RepositoryBase, IRepository<Category>
    {
        //private SqlConnection con;
        //private string connectionString;

        //public CategoryRepo()
        //{
        //    connectionString = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
        //    con = new SqlConnection(connectionString);
        //}

        private void ConnectionClose()
        {
            if (this.Connection.State == ConnectionState.Open) this.Connection.Close();
        }



        public List<Category> Get()
        {
            List<Category> categories = new List<Category>();

            //select CategoryId, CategoryName, UstCategoryId, Description from Categories
            try
            {
                SqlCommand command = new SqlCommand("Sp_Categories", this.Connection);
                command.CommandType = CommandType.StoredProcedure;
                if (this.Connection.State == ConnectionState.Closed) this.Connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var category = CategoryMapping(reader);
                    categories.Add(category);

                }

                ConnectionClose();

            }
            catch (Exception)
            {


            }
            finally
            {
                if (this.Connection.State == ConnectionState.Open) this.Connection.Close();
            }
            return categories;
        }

     

        public Category GetById(int id)
        {
            Category category = null;
            try
            {
                SqlCommand command = new SqlCommand("Sp_Categories", this.Connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CategoryId", id);
                if (this.Connection.State == ConnectionState.Closed) this.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    category = CategoryMapping(reader);
                }
            }
            catch (Exception)
            {
            }

            finally
            {
                if (this.Connection.State == ConnectionState.Open) this.Connection.Close();
            }
            return category;
        }

        private Category CategoryMapping(SqlDataReader reader)
        {
            Category category = new Category();
            category.CategoryID = Convert.ToInt32(reader["CategoryID"]);
            category.CategoryName = reader["CategoryName"].ToString();
            category.UstCategoryId = Convert.ToInt32(reader["UstCategoryId"]);
            category.Description = reader["Description"].ToString();

            return category;
        }



        public int Create(Category item)
        {
            //select CategoryId, CategoryName, UstCategoryId, Description from Categories

            int id = 0;
            try
            {

                SqlCommand command = new SqlCommand("Sp_Category_Create_Update", this.Connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CategoryId", item.CategoryID);
                command.Parameters.AddWithValue("@CategoryName", item.CategoryName);
                command.Parameters.AddWithValue("@UstCategoryId", item.UstCategoryId);
                command.Parameters.AddWithValue("@Description", item.Description);

                if (this.Connection.State == ConnectionState.Closed) this.Connection.Open();
                id = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (this.Connection.State == ConnectionState.Open) this.Connection.Close();
            }

            return id;
        }


        public int Update(Category item)
        {

            int id = 0;
            try
            {

                SqlCommand command = new SqlCommand("Sp_Category_Create_Update", this.Connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CategoryId", item.CategoryID);
                command.Parameters.AddWithValue("@CategoryName", item.CategoryName);
                command.Parameters.AddWithValue("@UstCategoryId", item.UstCategoryId);
                command.Parameters.AddWithValue("@Description", item.Description);

                if (this.Connection.State == ConnectionState.Closed) this.Connection.Open();
                id = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception)
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
                SqlCommand command = new SqlCommand("Sp_Category_Delete", this.Connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CategoryId", id);
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
    }
}
