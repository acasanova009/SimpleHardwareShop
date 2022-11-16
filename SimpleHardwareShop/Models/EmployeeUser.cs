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

        [Required]
        public int? EmployeeAdressId { get; set; }

        public ICollection<Adress>? Adresses { get; set; }

       


        public override string ToString()
        {
            var basicInfo = $"[Application User] Id:{Id} UserType:{EmployeeType} RetailShop:{RetailShop} UserName:{UserName}";
            basicInfo += "\n";

            basicInfo += $"Nombre: {Name} {LastName} {SecondLastName} \n Email: {Email}  \n";

            if (Adresses is not null)
            foreach (var item in Adresses)
            {
                    if (item.Id == EmployeeAdressId)
                    {
                        basicInfo+= $"\n Adress: {item}";

                    }
            }
            basicInfo+= "\n";

            return basicInfo;

        }
        //public override string ToString()
        //{
        //    return " EMPLOYEE USER:" + base.ToString()+ " RetailShop:" + RetailShop + " EmployeeId:" + EmployeeId;
        //}

    }
}
