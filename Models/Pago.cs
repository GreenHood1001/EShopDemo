using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EShopDemo.Models
{
    public class Pago
    {
        public int Price {get; set;}

        public string Description {get; set;}


    }
}