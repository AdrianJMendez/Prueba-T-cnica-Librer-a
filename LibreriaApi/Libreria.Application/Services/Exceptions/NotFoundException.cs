namespace Libreria.Application.Services.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string mensaje) : base(mensaje) {}
}