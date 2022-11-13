using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SimpleHardwareShop.Models
{
    public class EmployeeUser : ApplicationUser
    {
        
        public RetailShop RetailShop { get; set; }

        [Required]
        public EmployeeType EmployeeType { get; set; }


        public override string ToString()
        {
            var basicInfo = $"[Application User] Id:{Id} Name: {Name} UserType:{EmployeeType} UserName:{UserName}";
            return basicInfo;

        }
        //public override string ToString()
        //{
        //    return " EMPLOYEE USER:" + base.ToString()+ " RetailShop:" + RetailShop + " EmployeeId:" + EmployeeId;
        //}

    }
}
