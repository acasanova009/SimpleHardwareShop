using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SimpleHardwareShop.Models
{
    public class EmployeeUser : ApplicationUser
    {
        public RetailShop RetailShop { get; set; }

        public int EmployeeId { get; set; }



        public override string ToString()
        {
            return " EMPLOYEE USER:" + base.ToString()+ " RetailShop:" + RetailShop + " EmployeeId:" + EmployeeId;
        }

    }
}
