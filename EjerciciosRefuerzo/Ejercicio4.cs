using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosRefuerzo
{
    internal class Ejercicio4
    {
        public static void ejercicio4()
        {
            CD cd = new CD(3);
            cd.agrega(new Cancion("Hola", "Amaral"));
            cd.agrega(new Cancion("Adiós", "Amaral"));
            cd.grabaCancion(0, new Cancion());
            cd.elimina(0);
            Console.WriteLine(cd.dameCancion(0));
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

        public class CD
        {
            private Cancion[] canciones;
            private int contador;

            public CD(int size = 10)
            {
                canciones = new Cancion[size];
                contador = 0;
            }

            public int numeroCanciones()
            {
                return contador;
            }

            public Cancion dameCancion(int index)
            {
                if (index < 0 || index >= contador)
                {
                    throw new IndexOutOfRangeException("Fuera de rango.");
                }
                return canciones[index];
            }

            public void grabaCancion(int index, Cancion cancion)
            {
                if (index < 0 || index >= contador)
                {
                    throw new IndexOutOfRangeException("Fuera del rango.");
                }
                canciones[index] = cancion;
            }

            public void agrega(Cancion cancion)
            {
                if (contador >= canciones.Length)
                {
                    throw new InvalidOperationException("No se puede agregar más canciones, el CD está lleno.");
                }
                canciones[contador] = cancion;
                contador++;
            }

            public void elimina(int index)
            {
                if (index < 0 || index >= contador)
                {
                    throw new IndexOutOfRangeException("Fuera del rango.");
                }

                // Desplazar las canciones hacia la izquierda después de eliminar
                for (int i = index; i < contador - 1; i++)
                {
                    canciones[i] = canciones[i + 1];
                }

                canciones[contador] = null;
                contador--;
            }
        }
    }
}
