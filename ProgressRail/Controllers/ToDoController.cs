using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProgressRail.Models.Context;
using ProgressRail.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgressRail.Controllers
{
    public class ToDoController : Controller
    {
        private readonly Context _context;
        public ToDoController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var lista = _context.ToDo.ToList();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var todo = new ToDo();
            return View(todo);
        }

        [HttpPost]
        public IActionResult Create(ToDo todo)
        {
            if (ModelState.IsValid)
            {
                _context.ToDo.Add(todo);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(todo);
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var todo = _context.ToDo.Find(Id);

            return View(todo);
        }

        [HttpPost]
        public IActionResult Edit(ToDo todo)
        {
            if (ModelState.IsValid)
            {
                _context.ToDo.Update(todo);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(todo);
            }
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var todo = _context.ToDo.Find(Id);
            return View(todo);
        }

        [HttpPost]
        public IActionResult Delete(ToDo _todo)
        {
            var todo = _context.ToDo.Find(_todo.Id);
            if (todo != null)
            {
                _context.ToDo.Remove(todo);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(todo);
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            var todo = _context.ToDo.Find(Id);
            return View(todo);
        }

    }
}
