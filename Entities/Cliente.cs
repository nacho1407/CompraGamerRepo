namespace Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = default!;
        public string Apellido { get; set; } = default!;
        public DateTime FechaNacimiento { get; set; }
        public string? Direccion { get; set; } = default!;
        public long? Telefono { get; set; }
        public string? Email { get; set; }
        public long Dni { get; set; }
        public long? Cuit { get; set; }
    }
}
