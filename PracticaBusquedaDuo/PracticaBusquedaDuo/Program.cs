using PracticaBusquedaDuo.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaBusquedaDuo
{
    internal class Program
    {
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
        // MÉTODO 1: Búsqueda Lineal por Título
        public static List<Libro> BuscarLibrosPorTituloLineal(List<Libro> libros, string tituloBuscado)
        {
            List<Libro> resultados = new List<Libro>();
            string terminoMinusculas = tituloBuscado?.ToLower(); 

            foreach (Libro libro in libros)
            {
                if (!string.IsNullOrEmpty(libro.Titulo) && !string.IsNullOrEmpty(terminoMinusculas))
                {
                    if (libro.Titulo.ToLower().Contains(terminoMinusculas))
                    {
                        resultados.Add(libro);
                    }
                }
            }
            return resultados;
        }

        // MÉTODO 2: Búsqueda Binaria por Autor
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

        // MÉTODO 3: Sugerencias de Autor
        public static List<Libro> BuscarSugerenciasAutor(List<Libro> libros, string termino)
        {
            List<Libro> sugerencias = new List<Libro>();

            foreach (var libro in libros)
            {
                if (libro.Autor.IndexOf(termino, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    sugerencias.Add(libro);
                }
            }
            return sugerencias;
        }
        static void Main(string[] args)
        {
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("=== BIBLIOTECA DIGITAL ===");
                Console.WriteLine("1. Buscar libro por Título (Lineal)");
                Console.WriteLine("2. Buscar libro por Autor (Binaria)");
                Console.WriteLine("3. Salir");
                Console.Write("\nSelecciona una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("\nIngrese palabra clave del título: ");
                        string terminoTitulo = Console.ReadLine();
                        
                        List<Libro> resultados = BuscarLibrosPorTituloLineal(biblioteca, terminoTitulo);

                        if (resultados.Count > 0)
                        {
                            Console.WriteLine("Sugerencias:");
                            Console.WriteLine($"Probablemente te refieres a: {resultados.Count}");
                            // Imprime cada libro usando el método ToString() de la clase Libro
                            resultados.ForEach(libro => Console.WriteLine($"   -> {libro}"));
                        }
                        else
                        {
                            Console.WriteLine("No se encontraron coincidencias.");
                        }

                        break;

                    case "2":
                        Console.Write("\nIngrese el nombre del Autor a buscar: ");
                        string entradaUsuario = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(entradaUsuario)) break;

                        Console.WriteLine($"\n--- Buscando: '{entradaUsuario}' ---");

                        // 1. Ordenar (Obligatorio para binaria)
                        List<Libro> bibliotecaOrdenada = biblioteca.OrderBy(x => x.Autor).ToList();

                        // 2. Búsqueda Exacta
                        Libro libroEncontrado = BuscarLibroPorAutorBinaria(bibliotecaOrdenada, entradaUsuario);

                        if (libroEncontrado != null)
                        {
                            Console.WriteLine("¡Autor encontrado exitosamente!");
                            Console.WriteLine($"   -> {libroEncontrado}");
                        }
                        else
                        {
                            // 3. Sugerencias
                            Console.WriteLine("No se encontró coincidencia exacta.");
                            List<Libro> sugerencias = BuscarSugerenciasAutor(bibliotecaOrdenada, entradaUsuario);

                            if (sugerencias.Count > 0)
                            {
                                Console.WriteLine("\n¿Te refieres a alguno de estos?");
                                foreach (var sugerencia in sugerencias)
                                {
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine($"   -> {sugerencia.Autor}");
                                    Console.WriteLine($"      Libro: {sugerencia.Titulo}");
                                    Console.ResetColor();
                                }
                            }
                            else
                            {
                                Console.WriteLine("No hay resultados similares.");
                            }
                        }
                        break;

                    case "3":
                        continuar = false;
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                if (continuar)
                {
                    Console.WriteLine("\nPresiona cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }
    }
}