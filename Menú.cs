using System;

class Program
{
    static string[] tareas = new string[10];
    static int contadorTareas = 0;

    static void Main(string[] args)
    {
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Mostrar tareas");
            Console.WriteLine("2. Agregar tarea");
            Console.WriteLine("3. Eliminar tarea");
            Console.WriteLine("4. Salir");
            Console.WriteLine("Seleccione una opción:");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    MostrarTareas();
                    break;
                case "2":
                    AgregarTarea();
                    break;
                case "3":
                    EliminarTarea();
                    break;
                case "4":
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                    break;
            }
        }
    }

    static void MostrarTareas()
    {
        Console.WriteLine("Tareas pendientes de realizar:");
        for (int i = 0; i < contadorTareas; i++)
        {
            Console.WriteLine($"{i + 1}. {tareas[i]}");
        }
    }

    static void AgregarTarea()
    {
        if (contadorTareas < tareas.Length)
        {
            Console.WriteLine("Por favor ingrese la nueva tarea:");
            string nuevaTarea = Console.ReadLine();
            tareas[contadorTareas] = nuevaTarea;
            contadorTareas++;
            Console.WriteLine("La tarea fue agregada exitosamente.");
        }
        else
        {
            Console.WriteLine("No se permiten agregar más tareas, la lista está llena.");
        }
    }

    static void EliminarTarea()
    {
        if (contadorTareas > 0)
        {
            Console.WriteLine("Ingrese el número de la tarea que le gustaría eliminar:");
            if (int.TryParse(Console.ReadLine(), out int indice) && indice >= 1 && indice <= contadorTareas)
            {
                for (int i = indice - 1; i < contadorTareas - 1; i++)
                {
                    tareas[i] = tareas[i + 1];
                }
                contadorTareas--;
                Console.WriteLine("La tarea fue eliminada exitosamente.");
            }
            else
            {
                Console.WriteLine("Número de tarea no válido.");
            }
        }
        else
        {
            Console.WriteLine("No hay tareas para eliminar.");
        }
    }
}
