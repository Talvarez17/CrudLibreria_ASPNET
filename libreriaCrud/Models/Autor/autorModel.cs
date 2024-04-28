namespace libreriaCrud.Models.Autor
{
    public class autorModel
    {
        public Guid? Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Nacionalidad { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
