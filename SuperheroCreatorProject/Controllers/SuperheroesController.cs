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
        public IActionResult Index()
        {

            return View(_context.Superheroes);
        }

        public IActionResult Create()
        {
            
            return View();
        }

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

        [HttpGet]
        public IActionResult Details(int primaryKey)
        {
            var result = _context.Superheroes.FirstOrDefault(x => x.Id == primaryKey);

            if (result is null)
            {
                return View();
            }

            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int primaryKey)
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Superhero superhero)
        {
            return View();
        }
    }
}