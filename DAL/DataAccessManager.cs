using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Fresher;

namespace DataAccess
{
    public class DataAccessManager
    {
        private readonly SqlConnection connection = new SqlConnection("data source=.; database=FresherManagement;" +
                                                                      " integrated security=SSPI");

        public SqlConnection GetConnection()
        { 
            return connection;
        }

        public IEnumerable<FresherDetail> GetDatas(string command)
        {
            List<FresherDetail> freshersList = new List<FresherDetail>();

            try
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    FresherDetail fresher = new FresherDetail();
                    fresher.id = Convert.ToInt32(dataReader["id"]);
                    fresher.name = dataReader["name"].ToString();
                    DateTime dateTime = DateTime.Parse(dataReader["date_of_birth"].ToString());
                    fresher.dateOfBirth = dateTime.ToString("dd/MM/yyyy");
                    fresher.mobileNumber = long.Parse(dataReader["mobile_number"].ToString());
                    fresher.address = dataReader["address"].ToString();
                    fresher.qualification = dataReader["qualification"].ToString();

                    freshersList.Add(fresher);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }

            return freshersList;
        }
    }
}
