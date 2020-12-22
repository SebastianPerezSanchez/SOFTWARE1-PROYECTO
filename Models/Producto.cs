using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SOFTWARE1_PROYECTO.Models
{
     [Table("t_producto")]
    public class Producto
    {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Display(Name="Identificador")]
    [Column("id")]
    public int ID { get; set; }

    [Required(ErrorMessage="Debe ingresar el nombre del producto a registrar")]
    [Display(Name="Producto")] 
    [Column("product")]
    public string product { get; set; }

    [Required(ErrorMessage="Debe ingresar el color del producto a registrar")]
    [Display(Name="Color del producto")] 
    [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "Solo se permiten letras")]
    [Column("color")]
    public string color { get; set; }

    [Required(ErrorMessage="Debe ingresar la talla del producto a registrar")]
    [Display(Name="Talla del producto")] 
    [Column("tallas")]
    public string tallas { get; set; }

    [Required(ErrorMessage="Debe ingresar el sexo del producto a registrar")]
    [Display(Name="Sexo")] 
    [Column("sexo")]
    public string sexo { get; set; }


    [Required(ErrorMessage="Debe ingresar la cantidad a registrar")]
    [Display(Name="Cantidad del producto")] 
    [Column("cantidad")]
    public int cantidad { get; set; }


    [Required(ErrorMessage="Debe ingresar el modelo del producto a registrar")]
    [Display(Name="Modelo del producto")] 
    [Column("modelo")]
    public string modelo { get; set; }

    public ICollection<EntradaProducto> EntradaProductos { get; set; }

    

    [NotMapped]
    public String Response { get; set; }

    }
}
