namespace Libreria.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("libros", Schema = "biblioteca")]
public class Libro
{
    [Key]
    [Column("id")]
    public Guid Id { get; private set; }

    [Column("titulo")]
    public string Titulo { get; private set; }

    [Column("anio")]
    public int Anio { get; private set; }

    [Column("genero")]
    public string? Genero { get; private set; }

    [Column("numero_paginas")]
    public int? NumeroPaginas { get; private set; }

    [Column("autor_id")]
    public Guid AutorId { get; private set; }

    [ForeignKey("AutorId")]
    public Autor Autor { get; private set; }

    public Libro(Guid id, string titulo, int anio, string? genero, int? numeroPaginas, Guid autorId)
    {
        Id = id;
        Titulo = titulo;
        Anio = anio;
        Genero = genero;
        NumeroPaginas = numeroPaginas;
        AutorId = autorId;
    }

    public void ActualizarDatos(string titulo, int anio, string? genero, int? numeroPaginas, Guid autorId)
    {
        Titulo = titulo;
        Anio = anio;
        Genero = genero;
        NumeroPaginas = numeroPaginas;
        AutorId = autorId;
    }
}
