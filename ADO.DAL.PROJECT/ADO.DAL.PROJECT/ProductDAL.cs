using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;

namespace ADO.DAL.PROJECT
{
    public class ProductDAL
    {
        SqlConnection connectionObj = new SqlConnection("server=(local);database=trainingp6;Integrated Security=true");

        SqlCommand commandObj;
        int registerStatus;

        public int RegisterProduct(Product product)
        {
            try
            {
                connectionObj.Open();
                commandObj = new SqlCommand("Proc_ProductRegister", connectionObj);
                commandObj.CommandType = System.Data.CommandType.StoredProcedure;
                //mapping procedure parameters =product object properties               commandObj.Parameters.AddWithValue("@productId",product.ProductId);
                commandObj.Parameters.AddWithValue("productId", product.ProductId);
                commandObj.Parameters.AddWithValue("@Name", product.ProductName);
                commandObj.Parameters.AddWithValue("@Price", product.Price);
                commandObj.Parameters.AddWithValue("@Category", product.Category);

                if (commandObj.ExecuteNonQuery() > 0)
                {
                    registerStatus = 1;
                }
            }
            catch (Exception ex)
            { 
                throw ex;
            }
            finally { connectionObj.Close(); }
            return registerStatus;
        }


    }
}
