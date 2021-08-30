using Microsoft.AspNetCore.Mvc;
using practica01.Models;
using practica01.Data;
using System.Linq;

namespace practica01.Controllers
{
    public class ProductoController:Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            
            return View(_context.Dataproducto.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Producto objproducto)
        {
            _context.Add(objproducto);
            _context.SaveChanges();
            ViewData["Message"] = "El producto ya esta registrado";
            //return RedirectToAction(nameof(Index));
            return View();
        }

        
        public IActionResult Edit(int id)
        {
            Producto objproducto = _context.Dataproducto.Find(id);
            if(objproducto == null){
                return NotFound();
            }
            return View(objproducto);
        }

        [HttpPost]
        public IActionResult Edit(int id,[Bind("id,nombre, categoria, precio, descuento")] Producto objproducto)
        {
             _context.Update(objproducto);
             _context.SaveChanges();
              ViewData["Message"] = "El producto ya esta actualizado";
             return View(objproducto);
        }

        public IActionResult Delete(int id)
        {
            Producto objproducto = _context.Dataproducto.Find(id);
            _context.Dataproducto.Remove(objproducto);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
