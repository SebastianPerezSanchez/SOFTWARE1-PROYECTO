using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SOFTWARE1_PROYECTO.Models
{
     [Table("t_usuario")]
    public class Registrar
    {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int ID { get; set; }

    [Column("dni")]
    public string DNI { get; set; }

    [Column("nombre")]

    public string Nombre { get; set; }

    [Column("apellido")]

    public string Apellido { get; set; }

    [Column("correo")]

    public string Correo { get; set; }

    [Column("cargo")]

    public string Cargo { get; set; }

    [Column("contraseña")]

    public string Contraseña { get; set; }
    

    [NotMapped]
    public String Respuesta { get; set; }

    }
}