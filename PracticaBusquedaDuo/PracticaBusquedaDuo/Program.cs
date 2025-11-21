using PracticaBusquedaDuo.Clases; // Asegúrate de que este using coincida con donde tengas tu clase Libro
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaBusquedaDuo
{
    internal class Program
    {
        // Copiamos la lista biblioteca EXACTAMENTE como la tiene tu compañero.
        // Esto es necesario para que tu código compile y puedas probarlo.
        // Al hacer el merge, Git intentará unificar esto.
        public static List<Libro> biblioteca = new List<Libro>
        {
            new Libro("Cien años de soledad", "Gabriel García Márquez", 1967, "La épica historia de la familia Buendía a lo largo de siete generaciones en el pueblo ficticio de Macondo."),
            new Libro("1984", "George Orwell", 1949, "Una distopía clásica que aborda la vigilancia gubernamental, la manipulación histórica y la represión social bajo el Gran Hermano."),
            new Libro("Orgullo y prejuicio", "Jane Austen", 1813, "Sigue el desarrollo emocional de Elizabeth Bennet mientras enfrenta asuntos de modales, educación, moral y matrimonio en la sociedad inglesa."),
            new Libro("El señor de los anillos", "J.R.R. Tolkien", 1954, "La aventura de Frodo Bolsón y la Compañía para destruir un anillo con poderes oscuros antes de que el Señor Oscuro tome el control."),
            new Libro("Don Quijote de la Mancha", "Miguel de Cervantes", 1605, "Las cómicas y trágicas aventuras de un hidalgo que enloquece al leer libros de caballerías y decide convertirse en caballero andante."),
            new Libro("Moby Dick", "Herman Melville", 1851, "La obsesiva búsqueda del Capitán Ahab de la gran ballena blanca que lo dejó mutilado, explorando temas de venganza y fe."),
            new Libro("Un mundo feliz", "Aldous Huxley", 1932, "Una novela distópica futurista que presenta una sociedad donde la gente es controlada por el condicionamiento y el consumo de drogas."),
            new Libro("Ensayo sobre la ceguera", "José Saramago", 1995, "La súbita epidemia de una 'ceguera blanca' obliga a la sociedad a replantearse los límites de la humanidad y la civilización.")
        };
        // Algoritmo de Búsqueda Binaria
        public static Libro BuscarLibroPorAutorBinaria(List<Libro> libros, string autorBuscado)
        {
            int izquierda = 0;
            int derecha = libros.Count - 1;

            while (izquierda <= derecha)
            {
                int medio = (izquierda + derecha) / 2;
                string autorMedio = libros[medio].Autor;

                // Comparamos ignorando mayúsculas
                int comparacion = string.Compare(autorMedio, autorBuscado, StringComparison.OrdinalIgnoreCase);

                if (comparacion == 0) return libros[medio];
                else if (comparacion < 0) izquierda = medio + 1;
                else derecha = medio - 1;
            }

            return null;
        }
        // Busca autores que contengan la palabra ingresada (Búsqueda lineal de respaldo)
        public static List<Libro> BuscarSugerenciasAutor(List<Libro> libros, string termino)
        {
            List<Libro> sugerencias = new List<Libro>();

            foreach (var libro in libros)
            {
                // Verificamos si el nombre del autor contiene el término (ignorando mayúsculas)
                if (libro.Autor.IndexOf(termino, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    sugerencias.Add(libro);
                }
            }
            return sugerencias;
        }
        static void Main(string[] args)
        {
            //BÚSQUEDA BINARIA

            Console.Write("\nIngrese el nombre del Autor a buscar: ");
            string entradaUsuario = Console.ReadLine();

            // Validación básica
            if (string.IsNullOrWhiteSpace(entradaUsuario)) { return; }

            Console.WriteLine($"\n--- Buscando: '{entradaUsuario}' ---");

            // 1.Ordenar lista para Búsqueda Binaria
            List<Libro> bibliotecaOrdenada = biblioteca.OrderBy(x => x.Autor).ToList();

            // 2.Búsqueda Binaria (Exacta)
            Libro libroEncontrado = BuscarLibroPorAutorBinaria(bibliotecaOrdenada, entradaUsuario);

            if (libroEncontrado != null)
            {
                // Caso A: El usuario escribió el nombre exacto
                Console.WriteLine("¡Autor encontrado exitosamente!");
                Console.WriteLine($"   -> {libroEncontrado}");
            }
            else
            {
                // Caso B: No es exacto, buscamos sugerencias parciales
                Console.WriteLine("No se encontró una coincidencia exacta.");

                List<Libro> sugerencias = BuscarSugerenciasAutor(bibliotecaOrdenada, entradaUsuario);

                if (sugerencias.Count > 0)
                {
                    Console.WriteLine("\n¿Te refieres a alguno de estos?");
                    foreach (var sugerencia in sugerencias)
                    {

                        Console.ForegroundColor = ConsoleColor.Cyan; // Un toque de color
                        Console.WriteLine($"   -> {sugerencia.Autor}");
                        Console.WriteLine($"      Libro: {sugerencia.Titulo}");
                        Console.ResetColor();
                  }
                }
                else
                {
                    Console.WriteLine("No hay resultados ni sugerencias similares.");
                }
            }

            Console.WriteLine("\nPresiona cualquier tecla para terminar...");
            Console.ReadKey();
        }
    }
}