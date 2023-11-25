using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;

namespace ADO.DAL.PROJECT
{
    public class ordersdal
    {


        SqlConnection connectionObj = new SqlConnection("server=(local);database=trainingp6;Integrated Security=true");

        SqlCommand commandObj;

        public int GetOrderId(orders orders)
        {
            try
            {
                connectionObj.Open();

                commandObj = new SqlCommand("Proc_GetOrderID", connectionObj);
                commandObj.CommandType = System.Data.CommandType.StoredProcedure;

                //define proc paramter   + proc parameter added to command object
                commandObj.Parameters.AddWithValue("@CustomerName", orders.CustomerName);

                commandObj.Parameters.AddWithValue("@ShippingAddress", orders.ShippingAddress);

                commandObj.Parameters.AddWithValue("@ContactNUmber", orders.ContactNUmber);

                SqlParameter orderIdParameter = new SqlParameter()
                {
                    ParameterName = "OrderId",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Output,
                };
                //add proc parameter to command object

                commandObj.Parameters.Add(orderIdParameter);
                commandObj.ExecuteReader();
                       
        orders.OrderId=(int)orderIdParameter.Value; 
                
            }
            catch(Exception ex) { throw ex; }

            finally
            {
                connectionObj.Close();
            }

            return orders.OrderId;

        }
    }
}
