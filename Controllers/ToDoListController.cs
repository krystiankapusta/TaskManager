using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_ToDoList.Areas.Identity.Data;
using Project_ToDoList.Models;

namespace Project_ToDoList.Controllers
{
    [Authorize]
    public class ToDoListController : Controller
    {
        private readonly DBContextSample _context;

        public ToDoListController(DBContextSample context)
        {
            _context = context;
        }

        // GET: ToDoList
        public async Task<IActionResult> Index()
        {
            var todos = await _context.ToDoLists.ToListAsync();
            return View(todos);
        }

        // GET: ToDoList/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ToDoList/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Title, Description, Performer, EndDate")] ToDoList toDoList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(toDoList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(toDoList);
        }

        // GET: ToDoList/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var toDoList = await _context.ToDoLists.FindAsync(id);
            if (toDoList == null)
            {
                return NotFound();
            }
            return View(toDoList);
        }

        // POST: ToDoList/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Title, Description, Performer, EndDate, CreatedAt")] ToDoList toDoList)
        {
            if (id != toDoList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(toDoList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToDoListExists(toDoList.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(toDoList);
        }

        // GET: ToDoList/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var toDoList = await _context.ToDoLists
                .FirstOrDefaultAsync(m => m.Id == id);
            if (toDoList == null)
            {
                return NotFound();
            }

            return View(toDoList);
        }

        // POST: ToDoList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var toDoList = await _context.ToDoLists.FindAsync(id);
            if (toDoList != null)
            {
                _context.ToDoLists.Remove(toDoList);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ToDoListExists(int id)
        {
            return _context.ToDoLists.Any(e => e.Id == id);
        }
    }
}
