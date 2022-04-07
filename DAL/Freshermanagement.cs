using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Fresher;

namespace DataAccess
{
    public class Freshermanagement : IFresherManagement
    {
        private readonly DataAccessManager dataManager = new DataAccessManager();

        public IEnumerable<FresherDetail> GetFreshers()
        {
            return dataManager.GetDatas("spGetFreshers");
        }

        public int SaveFreshers(FresherDetail fresher)
        {
            int affectedRow = 0;
            DateTime dateTime = DateTime.Parse(fresher.dateOfBirth);
            fresher.dateOfBirth = dateTime.ToString("yyyy/MM/dd");
            SqlConnection connection = new SqlConnection(dataManager.GetConnection().ConnectionString);
            try
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand($"spSaveFreshers", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@id", fresher.id);
                sqlCommand.Parameters.AddWithValue("@name", fresher.name);
                sqlCommand.Parameters.AddWithValue("@mobileNumber", fresher.mobileNumber);
                sqlCommand.Parameters.AddWithValue("@dateOfBirth", fresher.dateOfBirth);
                sqlCommand.Parameters.AddWithValue("@qualification", fresher.qualification);
                sqlCommand.Parameters.AddWithValue("@address", fresher.address);

                affectedRow = sqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }

            return affectedRow;
        }

        public int DeleteFresher(int id)
        {
            int affectedRow = 0;
            SqlConnection connection = new SqlConnection(dataManager.GetConnection().ConnectionString);
            try
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand($"spDeleteFresher", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@id", id);

                affectedRow = sqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }

            return affectedRow;
        }
    }
}
