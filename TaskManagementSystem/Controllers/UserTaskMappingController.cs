using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Models;
using TaskManagementSystem.Services.Interfaces;

namespace TaskManagementSystem.Controllers
    {
    public class UserTaskMappingController : Controller
        {
        private readonly IUserTaskMappingService _mappingService;
        private readonly IUserService _userService;
        private readonly ITaskService _taskService;

        public UserTaskMappingController(
            IUserTaskMappingService mappingService,
            IUserService userService,
            ITaskService taskService)
            {
            _mappingService = mappingService;
            _userService = userService;
            _taskService = taskService;
            }

        public async Task<IActionResult> Index()
            {
            var mappings = await _mappingService.GetAllMappingsAsync();
            return View(mappings);
            }

        public async Task<IActionResult> Create()
            {
            ViewBag.Users = await _userService.GetAllUsersAsync();
            ViewBag.Tasks = await _taskService.GetAllTasksAsync();
            return View();
            }

        [HttpPost]
        public async Task<IActionResult> Create(UserTaskMappingModel mapping)
            {
            if (mapping == null) return BadRequest();
            var existingMapping = await _mappingService.GetUserTaskMappingAsync(mapping.UserId, mapping.TaskId);
            // Add the mapping if it passes validation and doesn't already exist
            if(existingMapping == null) await _mappingService.AddMappingAsync(mapping);
            return RedirectToAction(nameof(Index)); // Redirect to the Index action
            }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(int id)
            {

            var mapping = await _mappingService.GetMappingByIdAsync(id);
            if (mapping == null) return NotFound();
            await _mappingService.DeleteMappingAsync(id);
            return RedirectToAction(nameof(Index));
            }

        //[HttpPost, ActionName("Delete")]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //    {
        //    await _mappingService.DeleteMappingAsync(id);
        //    return RedirectToAction(nameof(Index));
        //    }
        }
    }