using System;
using System.IO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShopDemo.Models
{
    public class Producto
    {
        
        public int ID{ get; set;} 

        public int userID{ get; set; }

        public String Name{ get; set; }
        
        public String Description { get; set;}

        public int Price{ get; set;}

        public byte[] Preview { get; set; }

        public String imageData { get; set; }

    }
}