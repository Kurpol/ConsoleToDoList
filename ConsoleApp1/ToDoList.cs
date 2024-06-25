using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoItem;


namespace ToDoList
{

    internal class TodoList
    {
        private List<TodoListItem> list;
        private Dictionary<int, TodoListItem> dictionary;

        public TodoList()
        {
            list = new List<TodoListItem>();
            dictionary = new Dictionary<int, TodoListItem>();
        }

        public void AddNewTask(int priority, string taskText)
        {
            TodoListItem newItem = new TodoListItem
            {
                Id = list.Count > 0 ? list.Max(x => x.Id) + 1 : 1,
                Task = taskText,
                Priority = priority,
                Date = DateTime.Now,
            };
            list.Add(newItem);
            dictionary[newItem.Id] = newItem;
        }

        public void UpdateTask(int id, string newTaskText, int newPriority)
        {
            if (dictionary.ContainsKey(id))
            {
                TodoListItem item = dictionary[id];
                item.Task = newTaskText;
                item.Priority = newPriority;

                int index = list.FindIndex(x => x.Id == id);
                if (index != -1)
                {
                    list[index] = item;
                }
            }
            else
            {
                Console.WriteLine("Task ID not found.");
            }
        }

        public void RemoveTask(int id)
        {
            if (dictionary.ContainsKey(id))
            {
                dictionary.Remove(id);
                list.RemoveAll(x => x.Id == id);
            }
            else
            {
                Console.WriteLine("Task ID not found.");
            }
        }

        public List<TodoListItem> GetAllList()
        {
            return list;
        }

        public Dictionary<int, TodoListItem> GetAllDictionary()
        {
            return dictionary;
        }

        public List<TodoListItem> SortByDate()
        {
            return list.OrderBy(x => x.Date).ToList();
        }

        public List<TodoListItem> SortByPriority()
        {
            return list.OrderBy(x => x.Priority).ToList();
        }
    }
}