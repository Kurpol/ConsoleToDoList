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
            Console.WriteLine("\nChoose an action: add, update, remove, list, dictionary, sortdate, sortpriority, exit");
            command = Console.ReadLine();

            switch (command)
            {
                case "add":
                    Console.Write("Enter task: ");
                    string task = Console.ReadLine();
                    Console.Write("Enter priority (integer): ");
                    if (int.TryParse(Console.ReadLine(), out int priority))
                    {
                        toDoList.AddNewTask(priority, task);
                        Console.WriteLine("Task added.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid priority. Please enter an integer.");
                    }
                    break;

                case "update":
                    Console.Write("Enter task ID to update: ");
                    if (int.TryParse(Console.ReadLine(), out int updateId))
                    {
                        Console.Write("Enter new task: ");
                        string newTask = Console.ReadLine();
                        Console.Write("Enter new priority (integer): ");
                        if (int.TryParse(Console.ReadLine(), out int newPriority))
                        {
                            toDoList.UpdateTask(updateId, newTask, newPriority);
                            Console.WriteLine("Task updated.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid priority. Please enter an integer.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID. Please enter an integer.");
                    }
                    break;

                case "remove":
                    Console.Write("Enter task ID to remove: ");
                    if (int.TryParse(Console.ReadLine(), out int removeId))
                    {
                        toDoList.RemoveTask(removeId);
                        
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID. Please enter an integer.");
                    }
                    break;

                case "list":
                    Console.WriteLine("All tasks (List):");
                    foreach (var item in toDoList.GetAllList())
                    {
                        Console.WriteLine($"{item.Id}. {item.Task} - Priority: {item.Priority} - Added: {item.Date}");
                    }
                    break;

                case "dictionary":
                    Console.WriteLine("All tasks (Dictionary):");
                    foreach (var temp in toDoList.GetAllDictionary())
                    {
                        var item = temp.Value;
                        Console.WriteLine($"{item.Id}. {item.Task} - Priority: {item.Priority} - Added: {item.Date}");
                    }
                    break;

                case "sortdate":
                    Console.WriteLine("Tasks sorted by date added:");
                    foreach (var item in toDoList.SortByDate())
                    {
                        Console.WriteLine($"{item.Id}. {item.Task} - Priority: {item.Priority} - Added: {item.Date}");
                    }
                    break;

                case "sortpriority":
                    Console.WriteLine("Tasks sorted by priority:");
                    foreach (var item in toDoList.SortByPriority())
                    {
                        Console.WriteLine($"{item.Id}. {item.Task} - Priority: {item.Priority} - Added: {item.Date}");
                    }
                    break;

                case "exit":
                    Console.WriteLine("Exiting program.");
                    break;

                default:
                    Console.WriteLine("Invalid command. Please try again.");
                    break;
            }
        }
    }
}