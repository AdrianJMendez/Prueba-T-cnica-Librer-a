namespace Libreria.Application.Services.Exceptions;

public class LimiteDeLibrosException : Exception
{
    public LimiteDeLibrosException(string mensaje) : base(mensaje) {}
}