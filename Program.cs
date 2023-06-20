        List<string> TaskList  = new List<string>();

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
        
        /// <summary>
        /// Show the options for task 1. Nueva tarea  2. Remover tarea 3. Tareas pendientes
        /// <returns>Returns option selected by user</returns>
        int ShowMainMenu()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Ingrese la opción a realizar: ");
            Console.WriteLine("1. Nueva tarea");
            Console.WriteLine("2. Remover tarea");
            Console.WriteLine("3. Tareas pendientes");
            Console.WriteLine("4. Salir");

            string opcion = Console.ReadLine();
            return Convert.ToInt32(opcion);
        }

        void ShowMenuRemove()
        {
            try
            {
                Console.WriteLine("Ingrese el número de la tarea a remover: ");
                ShowMenuTaskList();

                string opcion = Console.ReadLine();
                // Remove one position because the array starts in 0
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

        void ShowMenuAdd()
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

        void ShowMenuTaskList()
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
    
    public enum menu
    {
        Add     = 1,
        Remove  = 2,
        List    = 3,
        Exit    = 4
    }

