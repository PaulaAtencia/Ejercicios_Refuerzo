using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosRefuerzo
{
    internal class Ejercicio3
    {
        public static void ejercicio3()
        {
            Cancion c1 = new Cancion("Hola", "Paula");
            Cancion c2 = new Cancion();

            Console.WriteLine(c1.ToString());
            Console.WriteLine(c2.ToString());

            c1.ponTitulo("Adiós");
            c2.ponAutor("Lindo");

            Console.WriteLine(c1.dameTitulo());
            Console.WriteLine(c2.dameAutor());

        }

        public class Cancion
        {
            private string titulo;
            private string autor;

            public Cancion(string titulo = "", string autor = "")
            {
                this.titulo = titulo;
                this.autor = autor; 
            }

            public string dameTitulo()
            {
                return this.titulo;
            }

            public string dameAutor()
            {
                return this.autor;
            }

            public void ponTitulo(string titulo)
            {
                this.titulo = titulo;
            }

            public void ponAutor(string autor)
            {
                this.autor = autor;
            }

            public override string ToString()
            {
                return $"Canción: Título: {this.titulo} | Autor: {this.autor}";
            }
        }
    }
}
