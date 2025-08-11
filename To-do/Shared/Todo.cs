using System.Reflection.Emit;
using System.Threading.Tasks;
using To_do.Interfaces;

namespace To_do.Shared
{
    public class Todo: ITodo
    {
        private List<Task> _tasks = new List<Task>();
        private string[] _statusOptions = { "TO-DO", "DONE", "In-Progress" };

        public int TaskCounter
        {
            get { return _tasks.Count; }
        }
        

        public void AddTask()
        {
            Task task = new Task();
            Console.WriteLine("Escribe el nombre de la tarea");
            task.TaskName = Console.ReadLine();
            Console.WriteLine("Seleccione el status de la tarea (↑↓ y Enter):");
            task.TaskStatus = ChooseState();
            Console.WriteLine("Escribe la descripcion de la tarea");
            task.TaskDescription = Console.ReadLine();
            task.TaskId = _tasks.Count() + 1;
            _tasks.Add(task);
        }

        public void ShowTasks()
        {
            if (!_tasks.Any())
            {
                Console.WriteLine("No hay tareas registradas.");
                return;
            }

            Console.WriteLine("Id\tNombre\tEstado\tDescripción");
            foreach (var task in _tasks)
            {

                Console.WriteLine($"{task.TaskId}\t{task.TaskName}\t{task.TaskStatus}\t{task.TaskDescription}");
            }
            Console.WriteLine("");
        }

        public void RemoveTask()
        {
            Console.WriteLine("Diligencia el id de la tarea");
            int taskId = int.Parse(Console.ReadLine());
            var taskToRemove = _tasks.FirstOrDefault(t => t.TaskId == taskId);
            if (taskToRemove != null)
            {
                _tasks.Remove(taskToRemove);
                Console.WriteLine("Tarea eliminada.");
            }
            else
            {
                Console.WriteLine("No se encontro la tarea.");
            }
        }

        public string ChooseState()
        {
            int indice = 0;

            ConsoleKey tecla;
            do
            {
                Console.Clear();
                for (int i = 0; i < _statusOptions.Length; i++)
                {
                    if (i == indice)
                        Console.WriteLine($"> {_statusOptions[i]}"); // opción seleccionada
                    else
                        Console.WriteLine($"  {_statusOptions[i]}");
                }

                tecla = Console.ReadKey(true).Key;

                if (tecla == ConsoleKey.UpArrow && indice > 0) indice--;
                if (tecla == ConsoleKey.DownArrow && indice < _statusOptions.Length - 1) indice++;

            } while (tecla != ConsoleKey.Enter);
            return _statusOptions[indice];
        }
    }
}
