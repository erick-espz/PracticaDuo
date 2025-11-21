# 🔎 Módulo de Búsqueda para Biblioteca C#
Este proyecto es un módulo ejecutable por consola desarrollado en C# y Visual Studio 2022.

 1. Objetivos del Proyecto
El proyecto se enfoca en la implementación y demostración de diversos algoritmos de búsqueda y recuperación de datos dentro de una colección de objetos Libro. Nuestro objetivo general es implementar la Búsqueda Lineal para encontrar libros por título y la Búsqueda Binaria para encontrar libros por autor (en una lista ordenada). Además, el programa debe identificar los libros más recientes y más antiguos (búsqueda de máximos y mínimos) y realizar búsquedas de coincidencias dentro de descripciones textuales. Todo el desarrollo se realiza utilizando buenas prácticas de colaboración en Git/GitHub, como el uso de ramas (main, dev, feature) y Pull Requests para la revisión de código.
2. Integrantes del Equipo:
   - Erick Antonio Arana Espinoza (erick-espz)
   - Jesser Jadiel Rodriguez Chavarria (rjez12)
  
     
📚 3. Instrucciones de Uso
3.1. Prerrequisitos y Configuración
Para utilizar el programa, es necesario tener instalado Visual Studio 2022 y el SDK de .NET (versión 6.0 o superior). El inicio del proyecto se realiza clonando el repositorio desde la terminal (git clone...) y ejecutando el comando dotnet run dentro del directorio del proyecto. Alternativamente, se puede abrir la solución (.sln) directamente en Visual Studio y presionar F5.

3.2. Uso del Programa y Funcionalidades
Una vez ejecutado, el programa procesa automáticamente la lista de libros precargada (biblioteca) e imprime los resultados en la consola:

Búsqueda Lineal: Se ejecuta para encontrar libros cuyo título contenga un término específico. Esta función es clave para búsquedas rápidas y parciales.

Búsqueda Binaria: Se utiliza para localizar un libro por autor exacto. Es importante destacar que el algoritmo se aplica sobre una lista previamente ordenada, demostrando su eficiencia.

Búsqueda de Extremos: El programa identifica y muestra el libro más reciente y el libro más antiguo de la colección, basándose en el AñoPublicacion.

Búsqueda Textual: El sistema realiza una búsqueda de coincidencias dentro del campo descripción, mostrando aquellos libros cuyo texto descriptivo contenga una palabra clave específica.

⚙️ 4. Flujo de Trabajo en Git
Adoptamos un flujo de trabajo basado en ramas (branching) para garantizar la colaboración organizada y la estabilidad del código.

Estructura de Ramas
La rama main es la rama de producción y solo contiene código estable y funcional. La rama dev sirve como la rama de integración, siendo la base de todo el desarrollo. Todas las nuevas funcionalidades, como la feature/busqueda-lineal y la feature/busqueda-binaria, se crean desde dev y contienen el código de trabajo individual.

Proceso de Colaboración
Una vez que se termina una funcionalidad en una rama feature, se abre un Pull Request (PR) con destino a la rama dev. El compañero de equipo es asignado obligatoriamente como Revisor. La fusión (merge) solo se realiza en dev después de que el Revisor apruebe el código. Este proceso garantiza un registro claro de comentarios, revisiones y cambios sugeridos, manteniendo la calidad del código y el registro de la colaboración.
