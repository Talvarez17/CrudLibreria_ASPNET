namespace libreriaCrud.Models.Usuario
{
    public class usuarioModel
    {
        public Guid? Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Correo { get; set; }
        public string? Contraseña { get; set; }
    }
}
