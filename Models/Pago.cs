using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EShopDemo.Models
{
//TO crear base de datos y vincular
    public class Pago
    {

        [Required]
        public String Name{ get; set; }
        
        [Required]
        public int Price{ get; set;}

        [Required]
        public int CVV { get; set; }

        [Required]
        public int NumCard { get; set; }

        [Required]
        public int mesCard { get; set; }

        [Required]
        public int anioCard { get; set; }




    }
}