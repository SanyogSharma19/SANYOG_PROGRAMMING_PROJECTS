using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.DAL.PROJECT
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string EmailId { get; set; }
        public long ContactNumber { get; set; }
        public override string ToString()
        {
            return $"customer: {CustomerId},customername:{CustomerName},EmailId:{EmailId},ContactNumber{ContactNumber}";
        }
    }

    
}
