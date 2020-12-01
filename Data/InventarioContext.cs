using SOFTWARE1_PROYECTO.Models;
using Microsoft.EntityFrameworkCore;

namespace SOFTWARE1_PROYECTO.Data
{
    public class InventarioContext : DbContext
    {
        public InventarioContext(DbContextOptions<InventarioContext> options)
            :base(options)
            {
            }
        
        
    }
}