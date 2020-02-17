using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuperheroCreatorProject.Data;
using SuperheroCreatorProject.Models;


namespace SuperheroCreatorProject.Controllers
{
    public class SuperheroesController : Controller
    {

        private readonly ApplicationDbContext _context;
        public SuperheroesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index() => View(_context.Superheroes);

        public IActionResult Create() => View();


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Superhero superHero)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Superheroes.Add(superHero);
                    _context.SaveChanges();
                    return Redirect("Index");
                }
            }
            catch
            {
                return View(superHero);
            }
            return View(superHero);
        }

        //public IActionResult Details(int primaryKey) => _context.Superheroes.FirstOrDefault(x => x.Id == primaryKey) is null ?  View() : View();
        public IActionResult Details(int primaryKey)
        {
            var result = _context.Superheroes.FirstOrDefault(x => x.Id == primaryKey);
            if(result is null)
            {
                return View();
            }
            return View(result);
        }

        [HttpGet]
        public IActionResult Delete(int primaryKey)
        {
            try
            {
                _context.Superheroes.Remove(_context.Superheroes.First(x => x.Id == primaryKey));
                _context.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }


        [Route("Superhereos/Edit/{primaryKey:int}")]
        public IActionResult Edit(int primaryKey)
        {
            var result = _context.Superheroes.FirstOrDefault(x => x.Id == primaryKey);
            if(result is null)
            {
                return RedirectToAction("Index");
            }
            return View(result);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Superhero superhero)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Update(superhero);
                    _context.SaveChanges();
                }
            }
            catch
            {
                return View(superhero);

            }
            return Redirect("index");
        }
    }
}