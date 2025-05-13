
CREATE DATABASE libreria;

\c gestion_biblioteca

CREATE EXTENSION IF NOT EXISTS "pgcrypto";

CREATE SCHEMA IF NOT EXISTS biblioteca;

-- Tabla Autores
CREATE TABLE biblioteca.autores (
    id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    nombre_completo VARCHAR(150) NOT NULL,
    fecha_nacimiento DATE NOT NULL,
    ciudad VARCHAR(100),
    correo_electronico VARCHAR(150),
    CONSTRAINT unique_correo UNIQUE (correo_electronico)
);

-- Tabla Libros
CREATE TABLE biblioteca.libros (
    id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    titulo VARCHAR(200) NOT NULL,
    anio INT NOT NULL CHECK (anio >= 0),
    genero VARCHAR(100),
    numero_paginas INT CHECK (numero_paginas > 0),
    autor_id UUID NOT NULL,
    CONSTRAINT fk_autor FOREIGN KEY (autor_id) REFERENCES biblioteca.autores(id) ON DELETE CASCADE
);

-- Índices
CREATE INDEX idx_libros_autor_id ON biblioteca.libros(autor_id);
CREATE INDEX idx_autores_correo ON biblioteca.autores(correo_electronico);
