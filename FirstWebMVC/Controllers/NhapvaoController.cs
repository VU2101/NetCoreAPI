using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FirstWebMVC.Data;
using firstWebMVC.model;

namespace FirstWebMVC.Controllers
{
    public class NhapvaoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NhapvaoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Nhapvao
        public async Task<IActionResult> Index()
        {
            return View(await _context.Nhapvao.ToListAsync());
        }

        // GET: Nhapvao/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhapvao = await _context.Nhapvao
                .FirstOrDefaultAsync(m => m.CCCD == id);
            if (nhapvao == null)
            {
                return NotFound();
            }

            return View(nhapvao);
        }

        // GET: Nhapvao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nhapvao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Masinhvien,Email,CCCD,Hoten,Quequan")] Nhapvao nhapvao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhapvao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nhapvao);
        }

        // GET: Nhapvao/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhapvao = await _context.Nhapvao.FindAsync(id);
            if (nhapvao == null)
            {
                return NotFound();
            }
            return View(nhapvao);
        }

        // POST: Nhapvao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Masinhvien,Email,CCCD,Hoten,Quequan")] Nhapvao nhapvao)
        {
            if (id != nhapvao.CCCD)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhapvao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhapvaoExists(nhapvao.CCCD))
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
            return View(nhapvao);
        }

        // GET: Nhapvao/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhapvao = await _context.Nhapvao
                .FirstOrDefaultAsync(m => m.CCCD == id);
            if (nhapvao == null)
            {
                return NotFound();
            }

            return View(nhapvao);
        }

        // POST: Nhapvao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var nhapvao = await _context.Nhapvao.FindAsync(id);
            if (nhapvao != null)
            {
                _context.Nhapvao.Remove(nhapvao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhapvaoExists(string id)
        {
            return _context.Nhapvao.Any(e => e.CCCD == id);
        }
    }
}
