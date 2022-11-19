using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
  Equipo Individual
*/
/*

  Codigo por: Gonzalez Casanova Gallegos Renato Alfonso
  

  Fecha de cración: 19/Nov/2022

  Comentario General: Este programa simula una tienda de productos de hardware, que se conecta directamente con bases de datos.

*/

namespace SimpleHardwareShop.Models
{

    /// <summary>Modelo-Entidad para ApplicationUser</summary>
    
    [Index(nameof(UserName), IsUnique = true)]
    
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
