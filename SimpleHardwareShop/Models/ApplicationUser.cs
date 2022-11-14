using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHardwareShop.Models
{

    [Index(nameof(UserName), IsUnique = true)]
    //[Index(nameof(Email), IsUnique = true)]
    public abstract class ApplicationUser
    {


        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string LastName { get; set; }
        [Required]

        public string SecondLastName { get; set; }
        
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]

        [MinLength(8, ErrorMessage = "The password must be at least 8 characters long")]
        public string Password { get; set; }

       



    }
}
