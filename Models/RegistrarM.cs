using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SOFTWARE1_PROYECTO.Models
{
     [Table("t_mujer")]
    public class RegistrarM
    {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int ID { get; set; }

    [Column("nombre")]
    public string Nombre { get; set; }

    [Column("codigo")]

    public string Codigo{ get; set; }

    [Column("color")]

    public string Color { get; set; }

    [Column("talla36")]

    public int Talla36 { get; set; }

    [Column("talla37")]

    public int Talla37 { get; set; }

    [Column("talla38")]

    public int Talla38 { get; set; }

    [Column("talla39")]

    public int Talla39 { get; set; }
    

    [NotMapped]
    public String Respuesta { get; set; }

    }
}