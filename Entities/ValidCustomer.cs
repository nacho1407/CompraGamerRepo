using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class ValidCustomer
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(50)]
        public string Nombre { get; set; } = default!;
        [Required(ErrorMessage = "El Apellido es requerido")]
        [StringLength(50)]
        public string Apellido { get; set; } = default!;
        [Required(ErrorMessage = "Debe ser formato fecha")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }
        public string? Direccion { get; set; } = default!;
        public long? Telefono { get; set; }
        public string? Email { get; set; }
        [Required(ErrorMessage = "El DNI es requerido")]
        public long Dni { get; set; }
        public long? Cuit { get; set; }
    }
}

