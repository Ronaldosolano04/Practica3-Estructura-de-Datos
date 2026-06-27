using System;
using System.Collections.Generic;
using System.Linq;

//=========================
// Clase Estudiante
//=========================
class Estudiante
{
    public string Nombre { get; set; }
    public double Calificacion { get; set; }

    public Estudiante(string nombre, double calificacion)
    {
        Nombre = nombre;
        Calificacion = calificacion;
    }
}

class Program
{
    // Lista
    static List<Estudiante> estudiantes = new List<Estudiante>();

    // Cola (FIFO)
    static Queue<string> clientes = new Queue<string>();

    // Pila (LIFO)
    static Stack<string> tareas = new Stack<string>();

    static void Main(string[] args)
    {
        int opcion;

        do
        {
            Console.Clear();

            Console.WriteLine("===================================");
            Console.WriteLine("      SISTEMA DE COLECCIONES");
            Console.WriteLine("===================================");
            Console.WriteLine("1. Lista de Estudiantes");
            Console.WriteLine("2. Cola de Clientes");
            Console.WriteLine("3. Pila de Tareas");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            int.TryParse(Console.ReadLine(), out opcion);

            switch (opcion)
            {
                case 1:
                    MenuEstudiantes();
                    break;

                case 2:
                    MenuClientes();
                    break;

                case 3:
                    MenuTareas();
                    break;

                case 0:
                    Console.WriteLine("Hasta luego...");
                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    Pausa();
                    break;
            }

        } while (opcion != 0);
    }

    //==================================================
    // MENÚ ESTUDIANTES
    //==================================================

    static void MenuEstudiantes()
    {
        int opcion;

        do
        {
            Console.Clear();

            Console.WriteLine("===== LISTA DE ESTUDIANTES =====");
            Console.WriteLine("1. Agregar estudiante");
            Console.WriteLine("2. Eliminar estudiante");
            Console.WriteLine("3. Mostrar estudiantes");
            Console.WriteLine("0. Regresar");
            Console.Write("Seleccione: ");

            int.TryParse(Console.ReadLine(), out opcion);

            switch (opcion)
            {
                case 1:
                    AgregarEstudiante();
                    break;

                case 2:
                    EliminarEstudiante();
                    break;

                case 3:
                    MostrarEstudiantes();
                    break;

                case 0:
                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    Pausa();
                    break;
            }

        } while (opcion != 0);
    }

    static void AgregarEstudiante()
    {
        Console.Clear();

        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();

        if (estudiantes.Any(e => e.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine("Ese estudiante ya existe.");
            Pausa();
            return;
        }

        Console.Write("Calificación: ");

        if (!double.TryParse(Console.ReadLine(), out double nota))
        {
            Console.WriteLine("Calificación inválida.");
            Pausa();
            return;
        }

        estudiantes.Add(new Estudiante(nombre, nota));

        Console.WriteLine("Estudiante agregado.");
        Pausa();
    }

    static void EliminarEstudiante()
    {
        Console.Clear();

        if (estudiantes.Count == 0)
        {
            Console.WriteLine("No hay estudiantes.");
            Pausa();
            return;
        }

        Console.Write("Nombre a eliminar: ");
        string nombre = Console.ReadLine();

        var estudiante = estudiantes.FirstOrDefault(e =>
            e.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));

        if (estudiante != null)
        {
            estudiantes.Remove(estudiante);
            Console.WriteLine("Estudiante eliminado.");
        }
        else
        {
            Console.WriteLine("No encontrado.");
        }

        Pausa();
    }

    static void MostrarEstudiantes()
    {
        Console.Clear();

        if (estudiantes.Count == 0)
        {
            Console.WriteLine("No hay estudiantes registrados.");
        }
        else
        {
            Console.WriteLine("LISTA DE ESTUDIANTES\n");

            foreach (var e in estudiantes)
            {
                Console.WriteLine($"Nombre: {e.Nombre} - Calificación: {e.Calificacion}");
            }
        }

        Pausa();
    }

    //==================================================
    // CLIENTES
    //==================================================

    static void MenuClientes()
    {
        int opcion;

        do
        {
            Console.Clear();

            Console.WriteLine("===== COLA DE CLIENTES =====");
            Console.WriteLine("1. Agregar cliente");
            Console.WriteLine("2. Atender cliente");
            Console.WriteLine("3. Mostrar cola");
            Console.WriteLine("0. Regresar");
            Console.Write("Seleccione: ");

            int.TryParse(Console.ReadLine(), out opcion);

            switch (opcion)
            {
                case 1:
                    AgregarCliente();
                    break;

                case 2:
                    AtenderCliente();
                    break;

                case 3:
                    MostrarClientes();
                    break;
            }

        } while (opcion != 0);
    }

    static void AgregarCliente()
    {
        Console.Clear();

        Console.Write("Nombre del cliente: ");
        string nombre = Console.ReadLine();

        if (clientes.Contains(nombre))
        {
            Console.WriteLine("Ese cliente ya está en la cola.");
        }
        else
        {
            clientes.Enqueue(nombre);
            Console.WriteLine("Cliente agregado.");
        }

        Pausa();
    }

    static void AtenderCliente()
    {
        Console.Clear();

        if (clientes.Count == 0)
        {
            Console.WriteLine("No hay clientes.");
        }
        else
        {
            Console.WriteLine($"Atendiendo a: {clientes.Dequeue()}");
        }

        Pausa();
    }

    static void MostrarClientes()
    {
        Console.Clear();

        if (clientes.Count == 0)
        {
            Console.WriteLine("No hay clientes en espera.");
        }
        else
        {
            Console.WriteLine("CLIENTES EN ESPERA\n");

            foreach (var cliente in clientes)
            {
                Console.WriteLine(cliente);
            }
        }

        Pausa();
    }

    //==================================================
    // TAREAS
    //==================================================

    static void MenuTareas()
    {
        int opcion;

        do
        {
            Console.Clear();

            Console.WriteLine("===== PILA DE TAREAS =====");
            Console.WriteLine("1. Agregar tarea");
            Console.WriteLine("2. Completar tarea");
            Console.WriteLine("3. Mostrar tareas");
            Console.WriteLine("0. Regresar");
            Console.Write("Seleccione: ");

            int.TryParse(Console.ReadLine(), out opcion);

            switch (opcion)
            {
                case 1:
                    AgregarTarea();
                    break;

                case 2:
                    CompletarTarea();
                    break;

                case 3:
                    MostrarTareas();
                    break;
            }

        } while (opcion != 0);
    }

    static void AgregarTarea()
    {
        Console.Clear();

        Console.Write("Descripción: ");
        string tarea = Console.ReadLine();

        if (tareas.Contains(tarea))
        {
            Console.WriteLine("La tarea ya existe.");
        }
        else
        {
            tareas.Push(tarea);
            Console.WriteLine("Tarea agregada.");
        }

        Pausa();
    }

    static void CompletarTarea()
    {
        Console.Clear();

        if (tareas.Count == 0)
        {
            Console.WriteLine("No hay tareas.");
        }
        else
        {
            Console.WriteLine($"Tarea completada: {tareas.Pop()}");
        }

        Pausa();
    }

    static void MostrarTareas()
    {
        Console.Clear();

        if (tareas.Count == 0)
        {
            Console.WriteLine("No hay tareas pendientes.");
        }
        else
        {
            Console.WriteLine("TAREAS PENDIENTES\n");

            foreach (var tarea in tareas)
            {
                Console.WriteLine("- " + tarea);
            }
        }

        Pausa();
    }

    //==================================================
    // PAUSA
    //==================================================

    static void Pausa()
    {
        Console.WriteLine("\nPresione ENTER para continuar...");
        Console.ReadLine();
    }
}