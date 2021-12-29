using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClothingStoreProject.Data;
using ClothingStoreProject.Models;
using Microsoft.AspNetCore.Authorization;

namespace ClothingStoreProject.Controllers
{
    public class ClothesController : Controller
    {
        private readonly ClothingStoreProjectContext _context;

        public ClothesController(ClothingStoreProjectContext context)
        {
            _context = context;
        }

        // GET: Clothes
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Clothes.ToListAsync());
        //}



        public ActionResult Index(string sortOrder, string searchString, int page = 0)
        {
            var clothes = _context.Clothes.ToList();
            if (!String.IsNullOrEmpty(searchString))
            {
                clothes = clothes.Where(c => c.Title.Contains(searchString)).ToList();
            }
            const int PageSize = 9;

            var count = clothes.Count();

            clothes = clothes.Skip(page * PageSize).Take(PageSize).ToList();

            this.ViewBag.MaxPage = (count / PageSize) - (count % PageSize == 0 ? 1 : 0);

            this.ViewBag.Page = page;

            return this.View(clothes);
        }
        public ActionResult Category(string category)
        {
            var clothes = _context.Clothes.ToList();
            switch (category)
            {
                case "Top":
                    clothes = clothes.Where(c => c.Category.Contains(category)).ToList();
                    break;
                case "Leg Wear":
                    clothes = clothes.Where(c => c.Category.Contains(category)).ToList();
                    break;
                case "Shoes":
                    clothes = clothes.Where(c => c.Category.Contains(category)).ToList();
                    break;
                case "Accessories":
                    clothes = clothes.Where(c => c.Category.Contains(category)).ToList();
                    break;
            }
            return this.View(clothes);
        }

        // GET: Clothes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clothes = await _context.Clothes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clothes == null)
            {
                return NotFound();
            }

            return View(clothes);
        }

        // GET: Clothes/Create
        [Authorize(Roles = "Admin, Editor")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clothes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Editor")]
        public async Task<IActionResult> Create([Bind("Id,Title,Image,Price")] Clothes clothes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clothes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clothes);
        }

        // GET: Clothes/Edit/5
        [Authorize(Roles = "Admin, Editor")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clothes = await _context.Clothes.FindAsync(id);
            if (clothes == null)
            {
                return NotFound();
            }
            return View(clothes);
        }

        // POST: Clothes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Image,Price,Category,Description,Stock")] Clothes clothes)
        {
            if (id != clothes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clothes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClothesExists(clothes.Id))
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
            return View(clothes);
        }

        // GET: Clothes/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clothes = await _context.Clothes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clothes == null)
            {
                return NotFound();
            }

            return View(clothes);
        }

        // POST: Clothes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clothes = await _context.Clothes.FindAsync(id);
            _context.Clothes.Remove(clothes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClothesExists(int id)
        {
            return _context.Clothes.Any(e => e.Id == id);
        }
    }
}
