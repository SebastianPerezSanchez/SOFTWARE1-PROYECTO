using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SOFTWARE1_PROYECTO.Models
{
     [Table("t_cliente")]
    public class Cliente
    {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Display(Name="Identificador")] 
    [Column("id")]
    public int ID { get; set; }

    [Required(ErrorMessage="Debe ingresar el DNI del cliente a registrar")]
    [Display(Name="DNI")] 
    [Column("dni")]
    public string DNI { get; set; }

    [Required(ErrorMessage="Debe ingresar el nombre del cliente a registrar")]
    [Display(Name="Nombre")]
    [Column("name")]

    public string Nombre { get; set; }

    [Required(ErrorMessage="Debe ingresar el apellido del cliente a registrar")]
    [Display(Name="apellido")]
    [Column("apellido")]

    public string Apellido { get; set; }
    
    [Required(ErrorMessage="Debe ingresar el email del cliente a registrar")]
    [Display(Name="email")]
    [Column("email")]

    public string Correo { get; set; }

    [Required(ErrorMessage="Debe ingresar el sexo del cliente a registrar")]
    [Display(Name="Sexo")] 
    [Column("sexo")]
    public string sexo { get; set; }

    [Required(ErrorMessage="Debe ingresar el distrito del cliente a registrar")]
    [Display(Name="distrito")] 
    [Column("distrito")]
    public string distrito { get; set; }

    [Required(ErrorMessage="Debe ingresar el direccion del cliente a registrar")]
    [Display(Name="direccion")] 
    [Column("direccion")]
    public string direccion { get; set; }

    
    [Required(ErrorMessage="Debe ingresar el celular del cliente a registrar")]
    [Display(Name="celular")] 
    [Column("celular")]
    public string celular { get; set; }
    
    [Required(ErrorMessage="Debe ingresar el compras del cliente a registrar")]
    [Display(Name="compras")] 
    [Column("compras")]
    public int compras { get; set; }


    [NotMapped]
    public String Respuesta { get; set; }

    }
}