using To_do.Shared;

Todo listTask = new Todo();

int op = 0;
do
{
    ShowMenu();
    op = int.Parse(Console.ReadLine());
    Console.Clear();
    switch (op)
    {
        case 1: 
            listTask.AddTask();
            Console.Clear();
            break;
        case 2:
            listTask.ShowTasks();
            Console.WriteLine($"Total de tareas: {listTask.TaskCounter}.");
            break;
        case 3:
            listTask.RemoveTask();
            break;
    }
} while (op != 4);

void ShowMenu()
{
    Console.WriteLine("1. Agregar Tarea");
    Console.WriteLine("2. Mostrar Tareas");
    Console.WriteLine("3. Eliminar Tarea");
    Console.WriteLine("4. Salir");
}