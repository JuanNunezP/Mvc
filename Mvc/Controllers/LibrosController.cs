using Microsoft.AspNetCore.Mvc;
using Mvc.Data;
using Mvc.Models;
using System.Collections.Generic;

namespace Mvc.Controllers
{
    public class LibrosController : Controller
    {

        private readonly ApplicationDbContext _context;

        public LibrosController(ApplicationDbContext context)
        {
            _context = context;
        }

          //HTTP GET  INDEX
        public IActionResult Index()
        {

            IEnumerable<Libro> listLibros = _context.Libro;
            return View(listLibros);
        }

        //HTTP Get Create
        public IActionResult Create()
        {

            return View();
        }
        //HTTP Post Create
        [HttpPost]
        public IActionResult Create(Libro libro)

        {
            if (ModelState.IsValid)
            {
                _context.Libro.Add(libro);
                _context.SaveChanges();


                TempData["mensaje"] = "El se ha creado correctamente";
                return RedirectToAction("Index");    
            }

            return View();
        }

        //Http Get Edit

        public IActionResult Edit(int? id) {

            if (id == null || id == 0) 
            {
                return NotFound();
                
            }
            //Obtener el libro
            var libro = _context.Libro.Find(id);

            if (libro == null)
            {
                return NotFound();
            }


              return View(libro);
        }

        //HTTP Post Edit
        [HttpPost]
        public IActionResult Edit(Libro libro)

        {
            if (ModelState.IsValid)
            {
                _context.Libro.Update(libro);
                _context.SaveChanges();


                TempData["mensaje"] = "El libro se ha editado correctamente";
                return RedirectToAction("Index");
            }

            return View();
        }

        //HTTP GET delete

        public IActionResult Delete(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();

            }
            //Obtener el libro
            var libro = _context.Libro.Find(id);

            if (libro == null)
            {
                return NotFound();
            }


            return View(libro);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]  
        public IActionResult DeleteLibro(int? id) {
            var libro = _context.Libro.Find(id);    
            if (libro == null) 
            {
                return NotFound();
            }


            _context.Libro.Remove(libro);
            _context.SaveChanges();


            TempData["mensaje"] = "El libro se ha Eliminado correctamente";

            return View("Index");
        }
         
    }
}
