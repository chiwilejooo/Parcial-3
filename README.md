# Parcial #3 - Herramientas de la Programación Aplicada III (.NET)

Universidad Tecnológica de Panamá
Facultad de Ingeniería en Sistemas Computacionales - Campus Víctor Levi Sasso
II Semestre 2026 - Grupo 1IL133
Instructora: Ing. Irina Fong
Fecha: 09 de noviembre de 2026

Repositorio con la parte práctica del Parcial #3 y la evidencia de la parte teórica.

---

## Contenido del repositorio

```
Parcial #3/
|-- README.md
|-- .gitignore
|-- Figura/                         Parte 1: Clase abstracta y polimorfismo (consola, .NET Framework 4.7.2)
|   |-- Figura.slnx
|   `-- Figura/
|       |-- Program.cs
|       |-- Figura.csproj
|       |-- App.config
|       |-- packages.config
|       `-- Properties/AssemblyInfo.cs
|-- Json/                           Parte 2: Serialización JSON con Newtonsoft.Json (consola, .NET 10)
|   `-- parte2/
|       |-- Program.cs
|       `-- parte2.csproj
|-- hash Bcrypt/                    Parte 3: Login con hash BCrypt (Windows Forms, .NET 10)
|   |-- LoginBcrypt.slnx
|   |-- LoginBcrypt/                Código fuente del proyecto
|   `-- Database/                   Script de creación y respaldo (backup) de la base de datos
`-- Referencias/
    |-- Parte Práctica del Parcial #3.pdf
    `-- Parcial #3 - Practica.png   Evidencia de la parte teórica
```

| Parte | Proyecto | Tipo | Framework | Paquetes NuGet | Puntos |
|---|---|---|---|---|---|
| Teórica | Cuestionario H5P en Virtual UTP | Evidencia (captura) | - | - | 27 |
| 1 | `Figura` | Aplicación de consola | .NET Framework 4.7.2 | Newtonsoft.Json 13.0.4 (referenciado) | 15 |
| 2 | `Json/parte2` | Aplicación de consola | .NET 10 | Newtonsoft.Json 13.0.4 | 15 |
| 3 | `hash Bcrypt/LoginBcrypt` | Windows Forms | .NET 10 (Windows) | BCrypt.Net-Next 4.0.3, Microsoft.Data.Sqlite 9.0.0 | 20 |

---

## Parte teórica - Evidencia

Cuestionario "Parcial #3" realizado en la plataforma Virtual UTP (actividad H5P) el lunes 9 de noviembre de 2026.

**Resultado obtenido: 21 / 27**

![Evidencia parte teórica - Resultado 21/27](Referencias/Parcial%20%233%20-%20Practica.png)

---

## Parte 1 - Jerarquía de clases con clase abstracta `Figura` (15 pts)

Carpeta: [`Figura/`](Figura/)

### Enunciado

Diseñar una jerarquía de clases en C# utilizando una clase abstracta llamada `Figura` que defina los métodos abstractos `CalcularArea()` y `CalcularPerimetro()`, implementar clases derivadas, declarar un arreglo unidimensional de tipo `Figura` que almacene instancias de las diferentes formas y aplicar polimorfismo recorriendo el arreglo para mostrar dinámicamente el nombre de la clase, su área y su perímetro.

### Implementación

| Elemento evaluado | Dónde se cumple | Pts |
|---|---|---|
| Clase abstracta como molde obligatorio | `abstract class Figura` | 3 |
| Métodos abstractos desarrollados en los hijos | `CalcularArea()` y `CalcularPerimetro()` sobrescritos con `override` en cada clase derivada | 2 |
| Arreglo unidimensional de tipo padre | `Figura[] figuras = { new Rectangulo(5, 10), new Triangulo(6, 8), new Circulo(4) };` | 5 |
| Recorrido polimórfico | `foreach (Figura figura in figuras)` llamando a los métodos a través de la variable del tipo padre y `figura.GetType().Name` | 5 |

Clases derivadas:

| Clase | Constructor | Área | Perímetro |
|---|---|---|---|
| `Rectangulo` | `(largo, altura)` | `largo * altura` | `2 * (largo + altura)` |
| `Triangulo` | `(base, altura)` | `(base * altura) / 2` | `3 * base` (se asume triángulo equilátero) |
| `Circulo` | `(radio)` | `PI * radio^2` | `2 * PI * radio` |

### Fragmento principal

```csharp
abstract class Figura
{
    public abstract double CalcularArea();
    public abstract double CalcularPerimetro();
}

static void Main(string[] args)
{
    Figura[] figuras = { new Rectangulo(5, 10), new Triangulo(6, 8), new Circulo(4) };

    foreach (Figura figura in figuras)
    {
        Console.WriteLine($"Figura: {figura.GetType().Name}");
        Console.WriteLine($"Área: {figura.CalcularArea()}");
        Console.WriteLine($"Perímetro: {figura.CalcularPerimetro()}");
        Console.WriteLine();
    }
}
```

### Ejecución

Abrir `Figura/Figura.slnx` en Visual Studio y ejecutar con `F5` (o `Ctrl + F5`).

Salida esperada (el separador decimal depende de la configuración regional de Windows):

```
Figura: Rectangulo
Área: 50
Perímetro: 30

Figura: Triangulo
Área: 24
Perímetro: 18

Figura: Circulo
Área: 50.2654824574367
Perímetro: 25.1327412287183
```

---

## Parte 2 - Trabajar con JSON usando Newtonsoft.Json (15 pts)

Carpeta: [`Json/parte2/`](Json/parte2/)

### Situación

Intercambiar los datos de una persona (Nombre: "Cristell", Edad: 20, Carrera: "Ingenieria en Sistemas") en formato JSON.

### Pasos realizados

1. **Instalar el paquete**

   ```
   dotnet add package Newtonsoft.Json
   ```

2. **Importar el espacio de nombres**

   ```csharp
   using Newtonsoft.Json;
   ```

3. **Crear el objeto con los datos**

   ```csharp
   var persona = new
   {
       Nombre = "Cristell",
       Edad = 20,
       Carrera = "Ingenieria en Sistemas"
   };
   ```

4. **Convertir el objeto a cadena JSON y mostrarlo**

   ```csharp
   string json = JsonConvert.SerializeObject(persona);
   Console.WriteLine(json);
   ```

### Ejecución

```
cd Json/parte2
dotnet run
```

Salida en consola:

```
Hello, World!
{"Nombre":"Cristell","Edad":20,"Carrera":"Ingenieria en Sistemas"}
```

---

## Parte 3 - Login con hash BCrypt (20 pts)

Carpeta: [`hash Bcrypt/`](hash%20Bcrypt/)

Aplicación de escritorio en **Windows Forms (C#, .NET 10)** que implementa un login usando el algoritmo **BCrypt** con la biblioteca **BCrypt.Net-Next**. Los datos se guardan en una base de datos **SQLite** (archivo local, no requiere instalar ningún servidor).

### Requisitos cubiertos

| Requisito del enunciado | Cómo se cumple | Pts |
|---|---|---|
| Programa en C# que cree un login y use BCrypt para generar el hash | Formulario `FrmLogin` y formulario `FrmRegistro`; al registrar se llama a `BCrypt.Net.BCrypt.HashPassword(clave, 11)` | 5 |
| Base de datos con tabla de usuarios y otra tabla con los intentos fallidos y exitosos, el usuario y la fecha | Tablas `Usuarios` e `IntentosLogin` (ver esquema abajo); cada intento de inicio de sesión queda registrado | - |
| Generar el hash de una palabra clave en la base de datos | Solo se guarda el hash (`PasswordHash`), nunca la contraseña en texto plano. El formulario principal incluye además una sección para generar el hash de cualquier palabra clave | 5 |
| Verificar la contraseña original con `BCrypt.Verify()` | `AuthService.IniciarSesion()` usa `BCrypt.Net.BCrypt.Verify(clave, usuario.PasswordHash)`; la sección de prueba del formulario principal también permite verificar una palabra contra un hash | 5 |
| Al tener un acceso exitoso, indicar el nombre del usuario | Mensaje de bienvenida y encabezado del formulario principal con el nombre completo y el nombre de usuario | 5 |
| Subir todo al repositorio incluyendo el backup de la BD | Carpeta `hash Bcrypt/Database/` con el script SQL y el archivo de respaldo; la aplicación tiene el botón "Generar respaldo de la BD" | - |

### Esquema de la base de datos

```sql
CREATE TABLE Usuarios (
    Id              INTEGER PRIMARY KEY AUTOINCREMENT,
    NombreUsuario   TEXT    NOT NULL UNIQUE COLLATE NOCASE,
    NombreCompleto  TEXT    NOT NULL,
    PasswordHash    TEXT    NOT NULL,
    FechaCreacion   TEXT    NOT NULL
);

CREATE TABLE IntentosLogin (
    Id              INTEGER PRIMARY KEY AUTOINCREMENT,
    NombreUsuario   TEXT    NOT NULL,
    UsuarioId       INTEGER NULL REFERENCES Usuarios(Id),
    Exitoso         INTEGER NOT NULL,      -- 1 = exitoso, 0 = fallido
    Fecha           TEXT    NOT NULL,      -- yyyy-MM-dd HH:mm:ss
    Detalle         TEXT    NULL
);
```

- `Usuarios`: guarda el usuario y el hash BCrypt de su contraseña.
- `IntentosLogin`: guarda cada intento (exitoso o fallido), el usuario escrito, la fecha y un detalle ("Usuario no existe", "Contraseña incorrecta", "Acceso concedido"), para un posible análisis posterior.

### Funcionamiento

1. **Inicio de sesión (`FrmLogin`)**: se escribe usuario y contraseña. Se busca el usuario en la tabla `Usuarios` y se verifica la contraseña con `BCrypt.Verify()`. El intento se guarda en `IntentosLogin` sea exitoso o fallido.
2. **Registro (`FrmRegistro`)**: crea un usuario nuevo. La contraseña se convierte en hash con BCrypt (factor de trabajo 11) y solo el hash se guarda en la base de datos.
3. **Formulario principal (`FrmPrincipal`)**, al que se entra solo con acceso exitoso:
   - Muestra el nombre del usuario que inició sesión.
   - Pestaña **Intentos de inicio de sesión**: tabla con el historial y totales de intentos exitosos y fallidos.
   - Pestaña **Usuarios**: lista de usuarios registrados con su hash.
   - Pestaña **Generar y verificar hash**: genera el hash BCrypt de una palabra clave y verifica una palabra contra un hash con `BCrypt.Verify()`.
   - Botón **Generar respaldo de la BD**: crea una copia de la base de datos en la ubicación elegida.
   - Botón **Cerrar sesión**.

### Usuario de prueba

| Usuario | Contraseña |
|---|---|
| `admin` | `Admin123` |

Este usuario se crea automáticamente la primera vez que se ejecuta la aplicación (y ya viene dentro del respaldo de la base de datos).

### Ejecución

Requisitos: Windows, Visual Studio 2022 (17.14 o superior) o Visual Studio 2026 con la carga de trabajo "Desarrollo de escritorio de .NET", y el SDK de .NET 10.

1. Abrir `hash Bcrypt/LoginBcrypt.slnx` en Visual Studio.
2. Visual Studio restaura los paquetes NuGet automáticamente (o ejecutar `dotnet restore`).
3. Ejecutar con `F5`.

También desde la terminal:

```
cd "hash Bcrypt/LoginBcrypt"
dotnet run
```

Paquetes utilizados:

```
dotnet add package BCrypt.Net-Next --version 4.0.3
dotnet add package Microsoft.Data.Sqlite --version 9.0.0
```

### Base de datos y respaldo

- Al ejecutarse, la aplicación usa el archivo `LoginBcrypt.db` ubicado junto al ejecutable (`bin/Debug/net10.0-windows/`). Si no existe, lo crea con las tablas y el usuario de prueba.
- `hash Bcrypt/Database/script_creacion.sql`: script con la creación de las tablas.
- `hash Bcrypt/Database/LoginBcrypt_backup.db`: respaldo de la base de datos con datos de ejemplo. Para restaurarlo, copiarlo junto al ejecutable con el nombre `LoginBcrypt.db`.
- El archivo `.db` se puede abrir con [DB Browser for SQLite](https://sqlitebrowser.org/) para revisar las tablas.

### Ejemplo de consultas para análisis

```sql
-- Intentos por usuario
SELECT NombreUsuario,
       SUM(Exitoso)      AS Exitosos,
       COUNT(*) - SUM(Exitoso) AS Fallidos
FROM IntentosLogin
GROUP BY NombreUsuario;

-- Últimos intentos fallidos
SELECT NombreUsuario, Fecha, Detalle
FROM IntentosLogin
WHERE Exitoso = 0
ORDER BY Fecha DESC;
```

---

## Herramientas utilizadas

- C# / .NET Framework 4.7.2 y .NET 10
- Visual Studio y Visual Studio Code
- Newtonsoft.Json 13.0.4
- BCrypt.Net-Next 4.0.3
- Microsoft.Data.Sqlite 9.0.0 (SQLite)
