using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Services.Interfaces;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Controllers
    {
    public class ReportingController : Controller
        {
        private readonly ITaskService _taskService;
        private readonly IUserService _userService;

        public ReportingController(ITaskService taskService, IUserService userService)
            {
            _taskService = taskService;
            _userService = userService;
            }

        public async Task<IActionResult> Index()
            {
            ViewBag.Users = await _userService.GetAllUsersAsync();
            return View();
            }

        public async Task<IActionResult> FilteredTasks(int? userId, string? priority, string? status)
            {
            var tasks = await _taskService.FilterTasksAsync(userId, priority, status);
            return PartialView("_FilteredTasksPartial", tasks);
            }

        public async Task<IActionResult> Reports()
            {
            var totalByStatus = await _taskService.GetTotalTasksByStatusAsync();
            var overdueTasks = await _taskService.GetOverdueTasksAsync();
            ViewBag.TotalByStatus = totalByStatus;
            ViewBag.OverdueTasks = overdueTasks;
            return View();
            }
        }
    }
