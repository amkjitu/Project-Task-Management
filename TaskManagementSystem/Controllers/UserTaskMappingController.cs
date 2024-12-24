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

        //[HttpPost]
        //public async Task<IActionResult> Create(UserTaskMappingModel mapping)
        //    {
        //    if (ModelState.IsValid)
        //        {
        //        try
        //            {
        //            await _mappingService.AddMappingAsync(mapping);
        //            return RedirectToAction(nameof(Index));
        //            }
        //        catch (InvalidOperationException ex)
        //            {
        //            ModelState.AddModelError("", ex.Message);
        //            }
        //        }

        //    ViewBag.Users = await _userService.GetAllUsersAsync();
        //    ViewBag.Tasks = await _taskService.GetAllTasksAsync();
        //    return View(mapping);
        //    }

        //[HttpPost]
        //public async Task<IActionResult> Create(UserTaskMappingModel mapping)
        //    {
        //    //if (!ModelState.IsValid)
        //      //  {
        //        foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
        //            {
        //            Console.WriteLine(error.ErrorMessage);
        //            }

        //        ViewBag.Users = await _userService.GetAllUsersAsync();
        //        ViewBag.Tasks = await _taskService.GetAllTasksAsync();
        //        return View(mapping);
        //       // }

        //    await _mappingService.AddMappingAsync(mapping);
        //    return RedirectToAction(nameof(Index));
        //    }

        [HttpPost]
        public async Task<IActionResult> Create(UserTaskMappingModel mapping)
            {
            //Console.WriteLine($"Received Mapping: TaskId={mapping.TaskId}, UserId={mapping.UserId}, AssignedAt={mapping.AssignedAt}");

            //if (!ModelState.IsValid)
            //   {
            // Repopulate ViewBag data in case of validation failure
            //ViewBag.Users = await _userService.GetAllUsersAsync();
            //ViewBag.Tasks = await _taskService.GetAllTasksAsync();
            //return View(mapping); // Return the same view with error messages
            //   }

            // Check for duplicate mapping to enforce UNIQUE(TaskId, UserId)
            var existingMapping = await _mappingService.GetAllMappingsAsync();
            if (existingMapping.Any(m => m.TaskId == mapping.TaskId && m.UserId == mapping.UserId))
                {
                ModelState.AddModelError(string.Empty, "This user is already assigned to this task.");
                ViewBag.Users = await _userService.GetAllUsersAsync();
                ViewBag.Tasks = await _taskService.GetAllTasksAsync();
                TempData["Notification"] = "Task is already assigned";
                return View(mapping);
                }

            // Add the mapping if it passes validation and doesn't already exist
            await _mappingService.AddMappingAsync(mapping);
            return RedirectToAction(nameof(Index)); // Redirect to the Index action
            }

        public async Task<IActionResult> Edit(int id)
            {

            var mapping = await _mappingService.GetMappingByIdAsync(id);
            if (mapping == null) return NotFound();
            ViewBag.Users = await _userService.GetAllUsersAsync();
            ViewBag.Tasks = await _taskService.GetAllTasksAsync();
            return View(mapping);
            }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, UserTaskMappingModel mapping)
            {
            if (id != mapping.Id)
                {
                return BadRequest();
                }

            //if (!ModelState.IsValid)
            //    {
            //    ViewBag.Users = await _userService.GetAllUsersAsync();
            //    ViewBag.Tasks = await _taskService.GetAllTasksAsync();
            //    return View(mapping);
            //    }

            // Check for duplicate mapping
            var existingMapping = await _mappingService.GetAllMappingsAsync();
            //if(existingMapping.Any(m => m.TaskId == mapping.TaskId && m.UserId == mapping.UserId))
            if (existingMapping.Any(m => m.TaskId == mapping.TaskId && m.UserId == mapping.UserId && m.Id != mapping.Id))
                {
                ModelState.AddModelError(string.Empty, "This user is already assigned to this task.");
                ViewBag.Users = await _userService.GetAllUsersAsync();
                ViewBag.Tasks = await _taskService.GetAllTasksAsync();
                TempData["Notification"] = "Task is already assigned";
                return View(mapping);
                }

            await _mappingService.UpdateMappingAsync(mapping);
            return RedirectToAction(nameof(Index));
            }


        //[HttpPost]
        //public async Task<IActionResult> Edit(UserTaskMappingModel mapping)
        //    {
        //    if (ModelState.IsValid)
        //        {
        //        // Check for duplicate mapping
        //        var existingMapping = await _mappingService.GetAllMappingsAsync();
        //        if (existingMapping.Any(m => m.TaskId == mapping.TaskId && m.UserId == mapping.UserId && m.Id != mapping.Id))
        //            {
        //            ModelState.AddModelError(string.Empty, "This user is already assigned to this task.");
        //            ViewBag.Users = await _userService.GetAllUsersAsync();
        //            ViewBag.Tasks = await _taskService.GetAllTasksAsync();
        //            TempData["Notification"] = "Task is already assigned";
        //            return View(mapping);
        //            }

        //        //await _mappingService.UpdateMappingAsync(mapping);
        //        //return RedirectToAction(nameof(Index));

        //        await _mappingService.UpdateMappingAsync(mapping);
        //        return RedirectToAction(nameof(Index));
        //        }
        //    return View(mapping);
        //    }

        public async Task<IActionResult> Delete(int id)
            {
            var mapping = await _mappingService.GetMappingByIdAsync(id);
            if (mapping == null) return NotFound();
            return View(mapping);
            }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
            {
            await _mappingService.DeleteMappingAsync(id);
            return RedirectToAction(nameof(Index));
            }
        }
    }


//using Microsoft.AspNetCore.Mvc;
//using TaskManagementSystem.Models;
//using TaskManagementSystem.Services.Interfaces;

//namespace TaskManagementSystem.Controllers
//    {
//    public class UserTaskMappingController : Controller
//        {
//        private readonly IUserTaskMappingService _mappingService;
//        private readonly IUserService _userService;
//        private readonly ITaskService _taskService;

//        public UserTaskMappingController(
//            IUserTaskMappingService mappingService,
//            IUserService userService,
//            ITaskService taskService)
//            {
//            _mappingService = mappingService;
//            _userService = userService;
//            _taskService = taskService;
//            }

//        public async Task<IActionResult> Index()
//            {
//            var mappings = await _mappingService.GetAllMappingsAsync();
//            return View(mappings);
//            }

//        public async Task<IActionResult> Create()
//            {
//            ViewBag.Users = await _userService.GetAllUsersAsync();
//            ViewBag.Tasks = await _taskService.GetAllTasksAsync();
//            return View();
//            }

//        [HttpPost]
//        public async Task<IActionResult> Create(UserTaskMappingModel mapping)
//            {
//            if (ModelState.IsValid)
//                {
//                try
//                    {
//                    await _mappingService.AddMappingAsync(mapping);
//                    return RedirectToAction(nameof(Index));
//                    }
//                catch (InvalidOperationException ex)
//                    {
//                    ModelState.AddModelError("", ex.Message);
//                    }
//                }

//            ViewBag.Users = await _userService.GetAllUsersAsync();
//            ViewBag.Tasks = await _taskService.GetAllTasksAsync();
//            return View(mapping);
//            }

//        public async Task<IActionResult> Delete(int id)
//            {
//            var mapping = await _mappingService.GetMappingByIdAsync(id);
//            if (mapping == null) return NotFound();
//            return View(mapping);
//            }

//        [HttpPost, ActionName("Delete")]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//            {
//            await _mappingService.DeleteMappingAsync(id);
//            return RedirectToAction(nameof(Index));
//            }
//        }
//    }
