using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace practica01.Models
{
    [Table("t_producto")]
    public class Producto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Column("id")]
        public int id { get; set; }

        [Column("nombre")]
        public string nombre { get; set; }

        [Column("categoria")]
        public string categoria { get; set; }

        [Column("precio")]
        public double precio { get; set; }

        [Column("descuento")]
        public double descuento { get; set; }


    }
}