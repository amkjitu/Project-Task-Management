using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Models;
using TaskManagementSystem.Services.Interfaces;

namespace TaskManagementSystem.Controllers
    {
    public class TaskController : Controller
        {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
            {
            _taskService = taskService;
            }

        public async Task<IActionResult> Index()
            {
            var tasks = await _taskService.GetAllTasksAsync();
            return View(tasks);
            }

        public IActionResult Create()
            {
            return View();
            }

        [HttpPost]
        public async Task<IActionResult> Create(TaskModel task)
            {
            if (ModelState.IsValid)
                {
                await _taskService.AddTaskAsync(task);
                return RedirectToAction(nameof(Index));
                }
            return View(task);
            }

        public async Task<IActionResult> Edit(int id)
            {
            var task = await _taskService.GetTaskByIdAsync(id);
            if (task == null) return NotFound();
            return View(task);
            }

        [HttpPost]
        public async Task<IActionResult> Edit(TaskModel task)
            {
            if (ModelState.IsValid)
                {
                await _taskService.UpdateTaskAsync(task);
                return RedirectToAction(nameof(Index));
                }
            return View(task);
            }

        public async Task<IActionResult> Delete(int id)
            {
            var task = await _taskService.GetTaskByIdAsync(id);
            if (task == null) return NotFound();
            return View(task);
            }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
            {
            await _taskService.DeleteTaskAsync(id);
            return RedirectToAction(nameof(Index));
            }
        }
    }
