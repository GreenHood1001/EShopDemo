
using System;
using System.IO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EShopDemo.Models
{
    [Table("t_producto")]
    public class Detalle
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID{ get; set; }

        [Column("titulo")]
        public string titulo {get; set;}

        [Column("descripcion")]
        public String descripcion{get; set;}

        [Column("precio")]
        public int precio{get; set;}

        [Column("id_categoria")]
        public int id_categoria{get; set;}

        [Column("id_user")]
        public int id_user{set; get;}

        


    }
}