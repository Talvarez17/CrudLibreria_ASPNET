﻿namespace libreriaCrud.App.Libro
{
    public class libroDto
    {
        public Guid? Id { get; set; }
        public string? Nombre { get; set; }
        public string? Sinopsis { get; set; }
        public string? Editorial { get; set; }
        public DateTime? Fecha { get; set; }
        public Guid? Autor { get; set; }
        public Guid? Idusuario { get; set; }
    }
}
