
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using AtlasTaskFlowCSharp.Models;

namespace AtlasTaskFlowCSharp.Controllers
{
    public class TasksController : Controller
    {
        private static readonly string filePath =
            Path.Combine(
                Directory.GetCurrentDirectory(),
                "tasks.json");

        private static List<TaskItem> LoadTasks()
        {
            if (!System.IO.File.Exists(filePath))
            {
                return new List<TaskItem>();
            }

            string json = System.IO.File.ReadAllText(filePath);

            return JsonSerializer.Deserialize<List<TaskItem>>(json)
                   ?? new List<TaskItem>();
        }

        private static void SaveTasks(List<TaskItem> tasks)
        {
            string json = JsonSerializer.Serialize(
                tasks,
                new JsonSerializerOptions { WriteIndented = true });

            System.IO.File.WriteAllText(filePath, json);
        }

        public IActionResult Index()
        {
            return View(LoadTasks());
        }

        [HttpPost]
        public IActionResult Create(string title, string description)
        {
            List<TaskItem> tasks = LoadTasks();

            if (!string.IsNullOrWhiteSpace(title))
            {
                int nextId = tasks.Count == 0
                    ? 1
                    : tasks.Max(t => t.Id) + 1;

                tasks.Add(new TaskItem
                {
                    Id = nextId,
                    Title = title.Trim(),
                    Description = description?.Trim() ?? "",
                    IsCompleted = false
                });

                SaveTasks(tasks);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Complete(int id)
        {
            List<TaskItem> tasks = LoadTasks();

            TaskItem? task = tasks.FirstOrDefault(t => t.Id == id);

            if (task != null)
            {
                task.IsCompleted = true;
                SaveTasks(tasks);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            List<TaskItem> tasks = LoadTasks();

            TaskItem? task = tasks.FirstOrDefault(t => t.Id == id);

            if (task != null)
            {
                tasks.Remove(task);
                SaveTasks(tasks);
            }

            return RedirectToAction("Index");
        }
    }

}