using System;
using System.IO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace EShopDemo.Models
{
    [Table("t_categoria")]
    public class Categoria
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID{ get; set; }

        [Column("name")]
        public String Name { get; set; }

        [Column("mini_preview")]
        public byte[] Preview { get; set; }

        [NotMapped]
        public String imageData { get; set; }
    }
}