using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SOFTWARE1_PROYECTO.Models
{
     [Table("t_hombre")]
    public class RegistrarH
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

    [Column("talla39")]

    public int Talla39 { get; set; }

    [Column("talla40")]

    public int Talla40 { get; set; }

    [Column("talla41")]

    public int Talla41 { get; set; }

    [Column("talla42")]

    public int Talla42 { get; set; }

    [Column("talla43")]

    public int Talla43 { get; set; }
    

    [NotMapped]
    public String Respuesta { get; set; }

    }
}