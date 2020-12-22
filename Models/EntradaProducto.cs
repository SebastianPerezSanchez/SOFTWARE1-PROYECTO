using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SOFTWARE1_PROYECTO.Models
{
    [Table("t_EntradaProducto")]
    public class EntradaProducto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID {get; set;}

       [Column("date")]
        public DateTime date {get { return DateTime.Now; }}
        
        [Column("cantidadEntrada")]
        public int cantidadEntrada {get; set;}

        public Producto producto {get; set;}

        public int? ProductoId {get; set;}


    }
}