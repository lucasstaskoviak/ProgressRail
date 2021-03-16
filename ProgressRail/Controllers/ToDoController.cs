using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<ToDoController> _logger;
        public ToDoController(Context context, ILogger<ToDoController> logger)
        {
            _context = context;
            _logger = logger;
        }
        public IActionResult Index()
        {
            _logger.LogInformation("Index page says hello");
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
            try {
                if (ModelState.IsValid)
                {
                    _context.ToDo.Add(todo);
                    _context.SaveChanges();

                    return RedirectToAction("Index");
                }

                return View(todo);
            }
            catch (Exception e) {
                _logger.LogError("Um erro ocorreu ao tentar criar uma atividade", e);
                return StatusCode(500);
            } 
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
            try
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
            catch (Exception e)
            {
                _logger.LogError("Um erro ocorreu ao tentar editar uma atividade", e);
                return StatusCode(500);
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
            try
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
            catch (Exception e)
            {
                _logger.LogError("Um erro ocorreu ao tentar deletar uma atividade", e);
                return StatusCode(500);
            }
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            var todo = _context.ToDo.Find(Id);
            return View(todo);
        }

    }
}
