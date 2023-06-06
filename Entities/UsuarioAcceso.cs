namespace Entities
{
    public class UsuarioAcceso
    {
        public int Id { get; set; }
        public string Usuario { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
