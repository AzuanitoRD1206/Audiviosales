-- FILEPATH: d:\CrudAudiovisuales\DefaultConnection.session.sql

-- Show all databases
INSERT INTO usuarios (
    ID,
    Nombre,
    Cedula,
    NoCarnet,
    TipoUsuario,
    TipoPersona,
    Estado,
    UserName,
    Email,
    PasswordHash
  )
VALUES (
    ID:int,
    'Nombre:varchar',
    'Cedula:varchar',
    'NoCarnet:varchar',
    'TipoUsuario:varchar',
    'TipoPersona:varchar',
    'Estado:varchar',
    'UserName:varchar',
    'Email:varchar',
    'PasswordHash:varchar',
  );SELECT DISTINCT owner AS database_name
FROM all_tables;
