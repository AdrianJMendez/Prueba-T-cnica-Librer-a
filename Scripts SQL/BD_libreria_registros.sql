-- AUTOR 1
INSERT INTO biblioteca.autores (id, nombre_completo, fecha_nacimiento, ciudad, correo_electronico)
VALUES
    ('d290f1ee-6c54-4b01-90e6-d701748f0851', 'Gabriel García Márquez', '1927-03-06', 'Aracataca', 'gabriel@example.com');

INSERT INTO biblioteca.libros (titulo, anio, genero, numero_paginas, autor_id) VALUES
    ('Cien años de soledad', 1967, 'Realismo mágico', 471, 'd290f1ee-6c54-4b01-90e6-d701748f0851'),
    ('El amor en los tiempos del cólera', 1985, 'Romance', 348, 'd290f1ee-6c54-4b01-90e6-d701748f0851'),
    ('Crónica de una muerte anunciada', 1981, 'Misterio', 122, 'd290f1ee-6c54-4b01-90e6-d701748f0851');

-- AUTOR 2
INSERT INTO biblioteca.autores (id, nombre_completo, fecha_nacimiento, ciudad, correo_electronico)
VALUES
    ('a9a9d3f1-3b11-4e23-81c2-f4e2b1a2bc11', 'Isabel Allende', '1942-08-02', 'Lima', 'isabel@example.com');

INSERT INTO biblioteca.libros (titulo, anio, genero, numero_paginas, autor_id) VALUES
    ('La casa de los espíritus', 1982, 'Drama', 433, 'a9a9d3f1-3b11-4e23-81c2-f4e2b1a2bc11'),
    ('Eva Luna', 1987, 'Ficción', 272, 'a9a9d3f1-3b11-4e23-81c2-f4e2b1a2bc11'),
    ('Paula', 1994, 'Memorias', 432, 'a9a9d3f1-3b11-4e23-81c2-f4e2b1a2bc11');

-- AUTOR 3
INSERT INTO biblioteca.autores (id, nombre_completo, fecha_nacimiento, ciudad, correo_electronico)
VALUES
    ('b1c2d3e4-1234-5678-90ab-abcdef123456', 'Mario Vargas Llosa', '1936-03-28', 'Arequipa', 'mario@example.com');

INSERT INTO biblioteca.libros (titulo, anio, genero, numero_paginas, autor_id) VALUES
    ('La ciudad y los perros', 1963, 'Drama', 384, 'b1c2d3e4-1234-5678-90ab-abcdef123456'),
    ('Conversación en La Catedral', 1969, 'Ficción', 601, 'b1c2d3e4-1234-5678-90ab-abcdef123456'),
    ('La fiesta del chivo', 2000, 'Histórico', 518, 'b1c2d3e4-1234-5678-90ab-abcdef123456');

-- AUTOR 4
INSERT INTO biblioteca.autores (id, nombre_completo, fecha_nacimiento, ciudad, correo_electronico)
VALUES
    ('c3c3c3c3-0000-1111-2222-333344445555', 'Julio Cortázar', '1914-08-26', 'Bruselas', 'julio@example.com');

INSERT INTO biblioteca.libros (titulo, anio, genero, numero_paginas, autor_id) VALUES
    ('Rayuela', 1963, 'Experimental', 736, 'c3c3c3c3-0000-1111-2222-333344445555'),
    ('Bestiario', 1951, 'Cuentos', 152, 'c3c3c3c3-0000-1111-2222-333344445555'),
    ('Final del juego', 1956, 'Cuentos', 180, 'c3c3c3c3-0000-1111-2222-333344445555');

-- AUTOR 5
INSERT INTO biblioteca.autores (id, nombre_completo, fecha_nacimiento, ciudad, correo_electronico)
VALUES
    ('e4e4e4e4-5555-6666-7777-88889999aaaa', 'Laura Esquivel', '1950-09-30', 'Ciudad de México', 'laura@example.com');

INSERT INTO biblioteca.libros (titulo, anio, genero, numero_paginas, autor_id) VALUES
    ('Como agua para chocolate', 1989, 'Romántica', 246, 'e4e4e4e4-5555-6666-7777-88889999aaaa'),
    ('Tan veloz como el deseo', 2001, 'Romántica', 204, 'e4e4e4e4-5555-6666-7777-88889999aaaa'),
    ('Malinche', 2006, 'Histórica', 304, 'e4e4e4e4-5555-6666-7777-88889999aaaa');
