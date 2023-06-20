using System;
using System.Collections.Generic;

namespace ToDo
{
    internal class Program
    {
        public static List<string> TaskList { get; set; } = new List<string>();

        static void Main(string[] args)
        {
            int menuSelected = 0;
            do
            {
                menuSelected = ShowMainMenu();
                if ((menu)menuSelected == menu.Add)
                {
                    ShowMenuAdd();
                }
                else if ((menu)menuSelected == menu.Remove)
                {
                    ShowMenuRemove();
                }
                else if ((menu)menuSelected == menu.List)
                {
                    ShowMenuTaskList();
                }
            } while ((menu)menuSelected != menu.Exit);
        }
        /// <summary>
        /// Show the main menu 
        /// </summary>
        /// <returns>Returns option indicated by user</returns>
        public static int ShowMainMenu()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Ingrese la opción a realizar: ");
            Console.WriteLine("1. Nueva tarea");
            Console.WriteLine("2. Remover tarea");
            Console.WriteLine("3. Tareas pendientes");
            Console.WriteLine("4. Salir");

            // Read line
            string opcion = Console.ReadLine();
            return Convert.ToInt32(opcion);
        }

        public static void ShowMenuRemove()
        {
            try
            {
                Console.WriteLine("Ingrese el número de la tarea a remover: ");
                // Show current taks
                ShowMenuTaskList();

                string opcion = Console.ReadLine();
                // Remove one position
                int indexToRemove = Convert.ToInt32(opcion) - 1;

                if (indexToRemove>(TaskList.Count -1) || indexToRemove < 0)
                {
                    System.Console.WriteLine("Numero de tarea seleccionado no es valido");
                }
                    else
                    {
                     if (indexToRemove > -1 && TaskList.Count > 0)
                        {
                        string task = TaskList[indexToRemove];
                        TaskList.RemoveAt(indexToRemove);
                        Console.WriteLine($"Tarea {task} eliminada");
                        }
                    }
            }
            catch (Exception)
            {
                System.Console.WriteLine("Ha ocurrido un error al eliminar la tarea");
            }
        }

        public static void ShowMenuAdd()
        {
            try
            {
                Console.WriteLine("Ingrese el nombre de la tarea: ");
                string task = Console.ReadLine();
                TaskList.Add(task);
                Console.WriteLine("Tarea registrada");
            }
            catch (Exception)
            {
                System.Console.WriteLine("Ha ocurrido un error al ingresar la tarea");
            }
        }

        public static void ShowMenuTaskList()
        {
            if (TaskList?.Count>0)
            {
                Console.WriteLine("----------------------------------------");
                var indexTask =0;
                TaskList.ForEach (p=> Console.WriteLine($"{++indexTask}. {p}"));                
                Console.WriteLine("----------------------------------------");
            } 
            else
            {                
                Console.WriteLine("No hay tareas por realizar");
            }
        }
    }
    public enum menu
    {
        Add     = 1,
        Remove  = 2,
        List    = 3,
        Exit    = 4
    }
}
