using libreriaCrud.Models.Autor;
using Microsoft.EntityFrameworkCore;

namespace libreriaCrud.Persistence.Autor
{
    public class autorPersistence : DbContext
    {
        public autorPersistence(DbContextOptions<autorPersistence> options) : base(options) { }
        public DbSet<autorModel> autor { get; set; }
    }
}
