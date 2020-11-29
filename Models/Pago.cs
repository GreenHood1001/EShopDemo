using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EShopDemo.Models
{

    public class Pago
    {
        public int ID{ get; set;} 

        public String Name{ get; set; }
        
        public String Description { get; set;}

        public int Price{ get; set;}

        public String imageData { get; set; }



    }
}