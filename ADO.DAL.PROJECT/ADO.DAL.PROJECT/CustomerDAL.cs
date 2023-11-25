using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADO.DAL.PROJECT;

namespace ADO.DAL.PROJECT
{
    public class CustomerDAL
    {

        SqlConnection connectionObj = new SqlConnection("server=(local);database=trainingp6;Integrated Security=true");

        SqlCommand commandObj;
        int registerStatus;

        public List<Customer> customerList = new List<Customer>();
        SqlDataReader readerObj;


        public List<Customer> GetCustomers()
        {
            try
            {
                //connectionObj.Open();

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select * from Customer", connectionObj);
                DataSet dataSetObj = new DataSet();
                sqlDataAdapter.Fill(dataSetObj, "Customer");

                foreach (DataRow customer in dataSetObj.Tables["Customer"].Rows)
                {
                    customerList.Add(new Customer()
                    {
                        CustomerId = (int)customer["customerId"],
                        CustomerName = (string)customer["customerName"],
                        EmailId = (string)customer["emailId"],
                        ContactNumber = (long)customer["contactNumber"]
                    });
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
            return customerList;
        }


        public Customer Search(int id)
        {
            Customer customerWithId = new Customer();
            try
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"select * from Customer where customerId = {id};", connectionObj);
                DataSet dataSetObj = new DataSet();
                sqlDataAdapter.Fill(dataSetObj, "Customer");


                var row0 = dataSetObj.Tables["Customer"].Rows[0];
                customerWithId.CustomerId = (int)row0["customerId"];
                customerWithId.CustomerName = (string)row0["customerName"];
                customerWithId.EmailId = (string)row0["emailId"];
                customerWithId.ContactNumber = (long)row0["contactNumber"];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {

            }
            return customerWithId;

        }

        public void Update(int id, string newEmail, long newContactNumber)
        {
            //email id and contact

            string query = $"update Customer set emailId= '{newEmail}', contactNumber = {newContactNumber} where customerId = {id}";
            try
            {

                connectionObj.Open();
                commandObj = new SqlCommand(query, connectionObj);
                readerObj = commandObj.ExecuteReader();


                //if (result == 0)
                //{
                //    throw new Exception("No row updated");
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                connectionObj.Close();
                readerObj.Close();
            }
        }

        public bool Delete(int id)
        {

            string query = $"delete from Customer where customerId = {id}";
            try
            {

                connectionObj.Open();
                commandObj = new SqlCommand(query, connectionObj);
                //readerObj = commandObj.ExecuteReader();
                int registerStatus = commandObj.ExecuteNonQuery();

                if (registerStatus == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
                //if (result == 0)
                //{
                //    throw new Exception("No row updated");
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                connectionObj.Close();
                //readerObj.Close();
            }

            return false;

        }
        public List<Customer> GetCustomerDetails()
        {
            try
            {
                connectionObj.Open();
                commandObj = new SqlCommand("Select * from Customer;", connectionObj);
                readerObj = commandObj.ExecuteReader();
                while (readerObj.Read())
                {
                    Console.WriteLine($"{readerObj["customerId"]} {readerObj["customerName"]} {readerObj["emailId"]} {readerObj["contactNumber"]} ");

                    customerList.Add(new Customer()
                    {
                        CustomerId = (int)readerObj["customerId"],
                        CustomerName = (string)readerObj["customerName"],
                        EmailId = (string)readerObj["emailId"],
                        ContactNumber = (long)readerObj["contactNumber"]
                    });
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                readerObj.Close();
                connectionObj.Close();
            }
            return customerList;
        }

        public int RegisterCustomer(Customer customer)
        {
            try
            {
                connectionObj.Open();
                string s = $"insert into Customer values('{customer.CustomerName}','{customer.EmailId}',{customer.ContactNumber})";
                commandObj = new SqlCommand(s, connectionObj);
                registerStatus = commandObj.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                connectionObj.Close();
            }
            return registerStatus;

        }
    }
}