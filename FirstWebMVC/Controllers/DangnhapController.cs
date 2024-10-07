using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FirstWebMVC.Data;
using FirstWebMVC.Models;

namespace FirstWebMVC.Controllers
{
    public class DangnhapController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DangnhapController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Dangnhap
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dangnhap.ToListAsync());
        }

        // GET: Dangnhap/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dangnhap = await _context.Dangnhap
                .FirstOrDefaultAsync(m => m.CCCD == id);
            if (dangnhap == null)
            {
                return NotFound();
            }

            return View(dangnhap);
        }

        // GET: Dangnhap/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dangnhap/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CCCD,Hoten,Quequan")] Dangnhap dangnhap)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dangnhap);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dangnhap);
        }

        // GET: Dangnhap/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dangnhap = await _context.Dangnhap.FindAsync(id);
            if (dangnhap == null)
            {
                return NotFound();
            }
            return View(dangnhap);
        }

        // POST: Dangnhap/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CCCD,Hoten,Quequan")] Dangnhap dangnhap)
        {
            if (id != dangnhap.CCCD)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dangnhap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DangnhapExists(dangnhap.CCCD))
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
            return View(dangnhap);
        }

        // GET: Dangnhap/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dangnhap = await _context.Dangnhap
                .FirstOrDefaultAsync(m => m.CCCD == id);
            if (dangnhap == null)
            {
                return NotFound();
            }

            return View(dangnhap);
        }

        // POST: Dangnhap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var dangnhap = await _context.Dangnhap.FindAsync(id);
            if (dangnhap != null)
            {
                _context.Dangnhap.Remove(dangnhap);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DangnhapExists(string id)
        {
            return _context.Dangnhap.Any(e => e.CCCD == id);
        }
    }
}
