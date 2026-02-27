using Microsoft.AspNetCore.Mvc;
using TodoListApp.Models;
using System.Collections.Generic;

namespace TodoListApp.Controllers
{
    public class TodoItemsController : Controller
    {
        
        private static List<TodoItem> _todoItems = new List<TodoItem>
        {
            new TodoItem { Id = 1, Title = "Đi chợ", IsCompleted = true },      // Đã hoàn thành
            new TodoItem { Id = 2, Title = "Chơi thể thao", IsCompleted = false },
            new TodoItem { Id = 3, Title = "Chơi game", IsCompleted = false },
            new TodoItem { Id = 4, Title = "Học bài", IsCompleted = false }
        };

        
        public IActionResult Index()
        {
            return View(_todoItems);
        }

        
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();

            var todoItem = _todoItems.Find(m => m.Id == id);
            if (todoItem == null) return NotFound();

            return View(todoItem);
        }

        
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult Create(TodoItem todoItem)
        {
            if (ModelState.IsValid)
            {
                
                todoItem.Id = _todoItems.Count + 1;
                _todoItems.Add(todoItem);
                return RedirectToAction(nameof(Index));
            }
            return View(todoItem);
        }

        
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var todoItem = _todoItems.Find(m => m.Id == id);
            if (todoItem == null) return NotFound();

            
            return View(todoItem);
        }

        
        [HttpPost]
        public IActionResult Edit(int id, TodoItem todoItem)
        {
            if (id != todoItem.Id) return NotFound();

            var existingItem = _todoItems.Find(m => m.Id == id);
            if (existingItem == null) return NotFound();

            existingItem.Title = todoItem.Title;
            existingItem.IsCompleted = todoItem.IsCompleted;

            return RedirectToAction(nameof(Index));
        }

        
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var todoItem = _todoItems.Find(m => m.Id == id);
            if (todoItem == null) return NotFound();

            return View(todoItem);
        }

        
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var todoItem = _todoItems.Find(m => m.Id == id);
            if (todoItem != null)
            {
                _todoItems.Remove(todoItem);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
