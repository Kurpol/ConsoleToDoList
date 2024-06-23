using ToDoList;
using System;

class Program
{
    static void Main()
    {
        TodoList toDoList = new TodoList();
        string command = "";

        while (command != "exit")
        {
            Console.WriteLine("\nВыберите действие: add, update, remove, list, dictionary, sortdate, sortpriority, exit");
            command = Console.ReadLine();

            switch (command)
            {
                case "add":
                    Console.Write("Введите задачу: ");
                    string task = Console.ReadLine();
                    Console.Write("Введите приоритет (целое число): ");
                    int priority = int.Parse(Console.ReadLine());
                    toDoList.AddNewTask(priority, task);
                    Console.WriteLine("Задача добавлена.");
                    break;

                case "update":
                    Console.Write("Введите ID задачи для обновления: ");
                    int updateId = int.Parse(Console.ReadLine());
                    Console.Write("Введите новую задачу: ");
                    string newTask = Console.ReadLine();
                    Console.Write("Введите новый приоритет (целое число): ");
                    int newPriority = int.Parse(Console.ReadLine());
                    toDoList.UpdateTask(updateId, newTask, newPriority);
                    Console.WriteLine("Задача обновлена.");
                    break;

                case "remove":
                    Console.Write("Введите ID задачи для удаления: ");
                    int removeId = int.Parse(Console.ReadLine());
                    toDoList.RemoveTask(removeId);
                    Console.WriteLine("Задача удалена.");
                    break;

                case "list":
                    Console.WriteLine("Все задачи List:");
                    foreach (var item in toDoList.GetAllList())
                    {
                        Console.WriteLine($"{item.Id}. {item.Task} - Приоритет: {item.Priority} - Добавлено: {item.Date}");
                    }
                    break;

                case "dictionary":
                    Console.WriteLine("Все задачи Dictionary:");
                    foreach (var temp in toDoList.GetAllDictionary())
                    {
                        var item = temp.Value;
                        Console.WriteLine($"{item.Id}. {item.Task} - Приоритет: {item.Priority} - Добавлено: {item.Date}");
                    }
                    break;

                case "sortdate":
                    Console.WriteLine("Задачи, отсортированные по дате добавления:");
                    foreach (var item in toDoList.SortByDate())
                    {
                        Console.WriteLine($"{item.Id}. {item.Task} - Приоритет: {item.Priority} - Добавлено: {item.Date}");
                    }
                    break;

                case "sortpriority":
                    Console.WriteLine("Задачи, отсортированные по приоритету:");
                    foreach (var item in toDoList.SortByPriority())
                    {
                        Console.WriteLine($"{item.Id}. {item.Task} - Приоритет: {item.Priority} - Добавлено: {item.Date}");
                    }
                    break;

                case "exit":
                    Console.WriteLine("Выход из программы.");
                    break;

                default:
                    Console.WriteLine("Неверная команда. Попробуйте снова.");
                    break;
            }
        }
    }
}
