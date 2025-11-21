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

        public static List<Libro> BuscarLibrosPorTituloLineal(List<Libro> libros, string tituloBuscado)
        {
            List<Libro> resultados = new List<Libro>();

            // 1. Convertimos el término buscado a minúsculas una sola vez
            string terminoMinusculas = tituloBuscado?.ToLower(); // El operador ? previene NullReferenceException si tituloBuscado es null

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

       
        static void Main(string[] args)
        {
           //Busqueda lineal
            string termino = "señor";
            Console.WriteLine($"\n--- Búsqueda Lineal de Títulos que contienen: '{termino}' ---");

            List<Libro> resultados = BuscarLibrosPorTituloLineal(biblioteca, termino);

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

            Console.WriteLine("\nPresiona cualquier tecla para terminar...");
            Console.ReadKey();
        }
    }
}