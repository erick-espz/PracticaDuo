using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticaBusquedaDuo.Clases;

namespace PracticaBusquedaDuo
{
    internal class Program
    {
        //Búsqueda Binaria (Por Autor)
        public static Libro BuscarLibroPorAutorBinaria(List<Libro> libros, string autorBuscado)
        {
            int izquierda = 0;
            int derecha = libros.Count - 1;

            while (izquierda <= derecha)
            {
                int medio = (izquierda + derecha) / 2;

                // Comparamos el autor del medio con el buscado
                // StringComparison.OrdinalIgnoreCase ignora mayúsculas/minúsculas
                int comparacion = string.Compare(libros[medio].Autor, autorBuscado, StringComparison.OrdinalIgnoreCase);

                if (comparacion == 0)
                {
                    return libros[medio]; // ¡Encontrado!
                }
                else if (comparacion < 0)
                {
                    // El autor buscado es "mayor" alfabéticamente, buscamos en la mitad derecha
                    izquierda = medio + 1;
                }
                else
                {
                    // El autor buscado es "menor", buscamos en la mitad izquierda
                    derecha = medio - 1;
                }
            }

            return null; // Retornamos null si no se encuentra
        }
    }
}