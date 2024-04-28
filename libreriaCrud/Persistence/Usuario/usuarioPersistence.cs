using libreriaCrud.Models.Usuario;
using Microsoft.EntityFrameworkCore;

namespace libreriaCrud.Persistence.Usuario
{
    public class usuarioPersistence : DbContext
    {
        public usuarioPersistence(DbContextOptions<usuarioPersistence> options) : base(options) { }
        public DbSet<usuarioModel> usuario { get; set; }
    }
}
