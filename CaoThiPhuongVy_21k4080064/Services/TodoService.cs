using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static CaoThiPhuongVy_21k4080064.Pages.Todo;

namespace CaoThiPhuongVy_21k4080064.Services
{
    public class TodoService
    {
        public event Action? OnChange;

        private List<TodoList> todoLists = new();

        public List<TodoList> GetTodoLists()
        {
            return todoLists;
        }

        public async Task AddNewList(TodoList newList)
        {
            todoLists.Add(newList);
            NotifyStateChanged();
            await Task.CompletedTask;
        }

        public async Task SaveTodoLists(List<TodoList> lists) 
        {
            todoLists = lists;
            NotifyStateChanged();
            await Task.CompletedTask;
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
