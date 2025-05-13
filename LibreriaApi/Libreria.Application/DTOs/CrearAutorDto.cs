namespace Libreria.Application.DTOs;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Libreria.Application.Validations;

public class CrearAutorDto
    {
        [Required(ErrorMessage = "El nombre completo es obligatorio.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres.")]
        public string NombreCompleto { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
        
        [FechaNacimientoNoFutura]
        [Column(TypeName = "timestamp without time zone")]
        public DateTime FechaNacimiento { get; set; }

        [StringLength(100, ErrorMessage = "La ciudad no puede tener más de 100 caracteres.")]
        public string? Ciudad { get; set; }

        [CorreoElectronicoValido]
        public string? CorreoElectronico { get; set; }
    }