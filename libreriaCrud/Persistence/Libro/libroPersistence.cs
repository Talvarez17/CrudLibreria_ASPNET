using libreriaCrud.Models.Libro;
using Microsoft.EntityFrameworkCore;

namespace libreriaCrud.Persistence.Libro
{
    public class libroPersistence : DbContext
    {
        public libroPersistence(DbContextOptions<libroPersistence> options) : base(options) { }
        public DbSet<libroModel> libro { get; set; }
    }
}
