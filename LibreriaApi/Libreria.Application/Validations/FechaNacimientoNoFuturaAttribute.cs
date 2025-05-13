using System;
using System.ComponentModel.DataAnnotations;

namespace Libreria.Application.Validations
{
    public class FechaNacimientoNoFuturaAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is DateTime fechaNacimiento)
            {
                return fechaNacimiento <= DateTime.Today;
            }
            return true; // Si no es fecha, se ignora la validación aquí
        }

        public override string FormatErrorMessage(string name)
        {
            return "La fecha de nacimiento no puede ser una fecha futura.";
        }
    }
}
