using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaBusquedaDuo.Clases
{
    public class Libro
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int AñoPublicacion { get; set; }
        public string Descripcion { get; set; }

        // Constructor para inicializar el objeto fácilmente
        public Libro(string titulo, string autor, int anio, string descripcion)
        {
            Titulo = titulo;
            Autor = autor;
            AñoPublicacion = anio;
            Descripcion = descripcion;
        }

        // Método para imprimir la información del libro de forma clara en consola
        public override string ToString()
        {
            return $"[{AñoPublicacion}] {Titulo} por {Autor}";
        }
    }
}