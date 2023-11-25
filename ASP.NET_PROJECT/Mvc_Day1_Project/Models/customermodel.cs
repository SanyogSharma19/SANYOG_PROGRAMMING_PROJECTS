using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc_Day1_Project.Models
{
    public class customermodel
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

        public string EmailId { get; set; }

        public long ContactNumber{ get; set;}


        public customermodel customermodelObj{
            get;
            set;                   
        
        }  

        public List<customermodel> customerList { get; set; }

        public List<customermodel> GetAllCustomers() {
            try
            {
                customerList = new List<customermodel>
                {
                    new customermodel { CustomerId = 101,CustomerName="Customer1",EmailId="e1@g.c",ContactNumber=9999992019},

                    new customermodel { CustomerId = 102,CustomerName="Customer2",EmailId="e2@g.c",ContactNumber=99999567484},

                    new customermodel { CustomerId = 103,CustomerName="Customer3",EmailId="e3@g.c",ContactNumber=999999233321},

                };
            }
        catch(Exception ex)
            {

                throw ex;
            }
        return customerList;
        
        
        }
        public customermodel GetCustomer()
        {
            try
            {
                customermodelObj = new customermodel()
                {

                    CustomerId = 101,
                    CustomerName = "Rocks",
                    EmailId = "rock@g.c",
                    ContactNumber = 8989898989
                };


            }catch (Exception ex)
            {

                throw ex;
            }
            return customermodelObj;



        }
    }
}