using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SOFTWARE1_PROYECTO.Models
{
     [Table("t_producto")]
    public class Producto
    {
     [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int ID { get; set; }

    [Column("product")]

    public string product { get; set; }

    [Column("color")]

    public string color { get; set; }

    [Column("tallas")]

    public string tallas { get; set; }

    [Column("sexo")]

    public string sexo { get; set; }

    [Column("cantidad")]

    public int cantidad { get; set; }

    [Column("modelo")]

    public string modelo { get; set; }
    

    [NotMapped]
    public String Respuesta { get; set; }

    }
}
