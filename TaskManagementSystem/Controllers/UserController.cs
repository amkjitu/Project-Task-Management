﻿using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Models;
using TaskManagementSystem.Services.Interfaces;

namespace TaskManagementSystem.Controllers
    {
    public class UserController : Controller
        {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
            {
            _userService = userService;
            }

        public async Task<IActionResult> Index()
            {
            var users = await _userService.GetAllUsersAsync();
            return View(users);
            }

        public IActionResult Create()
            {
            return View();
            }

        [HttpPost]
        public async Task<IActionResult> Create(UserModel user)
            {
            if (ModelState.IsValid)
                {
                await _userService.AddUserAsync(user);
                return RedirectToAction(nameof(Index));
                }
            return View(user);
            }

        public async Task<IActionResult> Edit(int id)
            {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null) return NotFound();
            return View(user);
            }

        [HttpPost]
        public async Task<IActionResult> Edit(UserModel user)
            {
            if (ModelState.IsValid)
                {
                await _userService.UpdateUserAsync(user);
                return RedirectToAction(nameof(Index));
                }
            return View(user);
            }

        public async Task<IActionResult> Delete(int id)
            {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null) return NotFound();
            return View(user);
            }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
            {
            await _userService.DeleteUserAsync(id);
            return RedirectToAction(nameof(Index));
            }
        }
    }
