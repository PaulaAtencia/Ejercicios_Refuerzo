using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosRefuerzo
{
    internal class Ejercicio2
    {
        public static void ejercicio2()
        {
            Agenda agenda = new Agenda();
            int opcion;

            do
            {
                Console.WriteLine("\n[ Menú de Agenda ]");
                Console.WriteLine("1. Añadir Contacto");
                Console.WriteLine("2. Listar Contactos");
                Console.WriteLine("3. Buscar Contacto");
                Console.WriteLine("4. Eliminar Contacto");
                Console.WriteLine("5. Comprobar Agenda Llena");
                Console.WriteLine("6. Huecos Libres");
                Console.WriteLine("7. Salir");
                Console.Write("Elija una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese el nombre: ");
                        string nombre = Console.ReadLine();
                        Console.Write("Ingrese el teléfono: ");
                        string telefono = Console.ReadLine();
                        agenda.AñadirContacto(new Contacto(nombre, telefono));
                        break;

                    case 2:
                        agenda.ListarContactos();
                        break;

                    case 3:
                        Console.Write("Ingrese el nombre del contacto a buscar: ");
                        string nombreBuscar = Console.ReadLine();
                        agenda.BuscarContacto(nombreBuscar);
                        break;

                    case 4:
                        Console.Write("Ingrese el nombre del contacto a eliminar: ");
                        string nombreEliminar = Console.ReadLine();
                        agenda.EliminarContacto(new Contacto(nombreEliminar, ""));
                        break;

                    case 5:
                        Console.WriteLine(agenda.AgendaLlena() ? "La agenda está llena." : "La agenda no está llena.");
                        break;

                    case 6:
                        Console.WriteLine($"Huecos libres: {agenda.HuecosLibres()}");
                        break;

                    case 7:
                        Console.WriteLine("Saliendo...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida, intente de nuevo.");
                        break;
                }

            } while (opcion != 7);

        }

        class Contacto
        {
            public string Nombre { get; set; }
            public string Telefono { get; set; }

            public Contacto(string nombre, string telefono)
            {
                Nombre = nombre;
                Telefono = telefono;
            }

            public override bool Equals(object obj)
            {
                if (obj is Contacto contacto)
                {
                    return this.Nombre == contacto.Nombre;
                }
                return false;
            }
        }

        class Agenda
        {
            private Contacto[] contactos;
            private int index; // Próxima posición valida a añadir un contacto

            public Agenda(int size = 10)
            {
                contactos = new Contacto[size];
                index = 0;
            }

            public void AñadirContacto(Contacto c)
            {
                if (index >= contactos.Length)
                {
                    Console.WriteLine("La agenda está llena. No se pueden agregar más contactos.");
                    return;
                }

                if (ExisteContacto(c))
                {
                    Console.WriteLine("El contacto ya existe. No se pueden duplicar nombres.");
                    return;
                }

                contactos[index] = c;
                index++;
                Console.WriteLine($"Contacto {c.Nombre} añadido.");
            }

            public bool ExisteContacto(Contacto c)
            {
                foreach (var contacto in contactos)
                {
                    if (contacto != null && contacto.Equals(c))
                    {
                        return true;
                    }
                }
                return false;
            }

            public void ListarContactos()
            {
                Console.WriteLine("Lista de Contactos:");
                foreach (var contacto in contactos)
                {
                    if (contacto != null)
                    {
                        Console.WriteLine($"Nombre: {contacto.Nombre}, Teléfono: {contacto.Telefono}");
                    }
                }
            }

            public void BuscarContacto(string nombre)
            {
                foreach (var contacto in contactos)
                {
                    if (contacto != null && contacto.Nombre.Equals(nombre))
                    {
                        Console.WriteLine($"Teléfono de {nombre}: {contacto.Telefono}");
                        return;
                    }
                }
                Console.WriteLine($"No se encontró el contacto con nombre: {nombre}");
            }

            public void EliminarContacto(Contacto c)
            {
                for (int i = 0; i < index; i++)
                {
                    if (contactos[i] != null && contactos[i].Equals(c))
                    {
                        contactos[i] = null;
                        Console.WriteLine($"Contacto {c.Nombre} eliminado.");
                        // Reorganizar la agenda
                        for (int j = i; j < index - 1; j++)
                        {
                            contactos[j] = contactos[j + 1];
                        }
                        contactos[index - 1] = null;
                        index--;
                        return;
                    }
                }
                Console.WriteLine($"No se encontró el contacto {c.Nombre} para eliminar.");
            }

            public bool AgendaLlena()
            {
                return index >= contactos.Length;
            }

            public int HuecosLibres()
            {
                return contactos.Length - index;
            }
        }

    }
}
