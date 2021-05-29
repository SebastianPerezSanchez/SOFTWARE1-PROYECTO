using SOFTWARE1_PROYECTO.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace SOFTWARE1_PROYECTO.Data
{
    public class InventarioContext : DbContext
    {
        public InventarioContext(DbContextOptions<InventarioContext> options)
            :base(options)
            {
            }
        
                 public DbSet<SOFTWARE1_PROYECTO.Models.Producto> Productos { get; set; }
                //Después de utilizar el Registrar, se debe eliminar y trabajar con RegistrarH, RegistrarM, Registrar N.
                public DbSet<SOFTWARE1_PROYECTO.Models.Registrar> Registrar { get; set; }

                public DbSet<SOFTWARE1_PROYECTO.Models.RegistrarH> RegistrarH { get; set; }

                public DbSet<SOFTWARE1_PROYECTO.Models.RegistrarM> RegistrarM { get; set; }

                public DbSet<SOFTWARE1_PROYECTO.Models.RegistrarN> RegistrarN { get; set; }
                public DbSet<SOFTWARE1_PROYECTO.Models.EntradaProducto> EntradaProductos { get; set; }
                public DbSet<SOFTWARE1_PROYECTO.Models.Cliente> Cliente { get; set; }



    }
}