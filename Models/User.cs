using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShopDemo.Models
{
    public class User
    {
        [Display(Name="Email")]
        [DataType(DataType.EmailAddress)]
        public String Email{ get; set; }

        [Display(Name="Contraseña")]
        public String Password{ get; set; }
    }
}