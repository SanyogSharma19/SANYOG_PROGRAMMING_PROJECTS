using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace Mvc_Day1_Project.Models
{
    public class CustomerDataModel
    {
        SqlConnection connectionObj=new SqlConnection(
            ConfigurationManager.AppSettings["DbConnection"]);

        SqlCommand sqlCommand;
        int registerStatus;




        public int RegisterCustomers(customermodel customer)
        {
            try {
                connectionObj.Open();
               string query = $"insert into Customer values({customer.CustomerId},'{customer.CustomerName}','{customer.EmailId}',{customer.ContactNumber})";   
                
                sqlCommand = new SqlCommand(query, connectionObj);
                registerStatus = sqlCommand.ExecuteNonQuery();

            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            connectionObj.Close();
            }
            return registerStatus;

        }

        public List<customermodel> GetCustomers()
        {
            List<customermodel> customerList = new List<customermodel>();
            try
            {
                // step-2
                SqlDataAdapter sqlDataAdapterObj = new SqlDataAdapter("select * from Customer", connectionObj);
                // step-3
                DataSet datasetObj = new DataSet();
                // step-4
                sqlDataAdapterObj.Fill(datasetObj, "Customer");
                // step-5
                 
                foreach (DataRow customerRows in datasetObj.Tables["Customer"].Rows)
                {
                    customerList.Add(new customermodel()
                    {
                        CustomerId = Convert.ToInt32(customerRows["customerId"]),
                        CustomerName = customerRows["customerName"].ToString(),
                        EmailId = customerRows["emailId"].ToString(),
                        ContactNumber = Convert.ToInt64(customerRows["contactNumber"])
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return customerList;
        }
    }
}