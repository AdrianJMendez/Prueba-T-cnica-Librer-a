using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Libreria.Application.Validations
{
    public class CorreoElectronicoValidoAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is string correo && !string.IsNullOrWhiteSpace(correo))
            {
                var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
                return regex.IsMatch(correo);
            }
            return true; // Si es nulo o vacío, no se valida (ya que no es requerido)
        }

        public override string FormatErrorMessage(string name)
        {
            return "El correo electrónico proporcionado no tiene un formato válido.";
        }
    }
}
