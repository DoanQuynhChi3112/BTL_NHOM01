using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BTLNHOM01.Data;
using BTLNHOM01.Models;

namespace BTLNHOM01.Controllers
{
    public class phieuxuatController : Controller
    {
        private readonly ApplicationDbcontext _context;

        public phieuxuatController(ApplicationDbcontext context)
        {
            _context = context;
        }

        // GET: phieuxuat
        public async Task<IActionResult> Index()
        {
            var applicationDbcontext = _context.phieuxuat.Include(p => p.DonHangs);
            return View(await applicationDbcontext.ToListAsync());
        }

        // GET: phieuxuat/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieuxuat = await _context.phieuxuat
                .Include(p => p.DonHangs)
                .FirstOrDefaultAsync(m => m.MaNV == id);
            if (phieuxuat == null)
            {
                return NotFound();
            }

            return View(phieuxuat);
        }

        // GET: phieuxuat/Create
        public IActionResult Create()
        {
            ViewData["DonHangID"] = new SelectList(_context.DonHang, "DonHangID", "DonHangID");
            return View();
        }

        // POST: phieuxuat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaNV,TenNV,DonHangID,TenHang,Soluong,thanhtien,Ngaytao")] phieuxuat phieuxuat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phieuxuat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DonHangID"] = new SelectList(_context.DonHang, "DonHangID", "DonHangID", phieuxuat.DonHangID);
            return View(phieuxuat);
        }

        // GET: phieuxuat/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieuxuat = await _context.phieuxuat.FindAsync(id);
            if (phieuxuat == null)
            {
                return NotFound();
            }
            ViewData["DonHangID"] = new SelectList(_context.DonHang, "DonHangID", "DonHangID", phieuxuat.DonHangID);
            return View(phieuxuat);
        }

        // POST: phieuxuat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaNV,TenNV,DonHangID,TenHang,Soluong,thanhtien,Ngaytao")] phieuxuat phieuxuat)
        {
            if (id != phieuxuat.MaNV)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phieuxuat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!phieuxuatExists(phieuxuat.MaNV))
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
            ViewData["DonHangID"] = new SelectList(_context.DonHang, "DonHangID", "DonHangID", phieuxuat.DonHangID);
            return View(phieuxuat);
        }

        // GET: phieuxuat/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieuxuat = await _context.phieuxuat
                .Include(p => p.DonHangs)
                .FirstOrDefaultAsync(m => m.MaNV == id);
            if (phieuxuat == null)
            {
                return NotFound();
            }

            return View(phieuxuat);
        }

        // POST: phieuxuat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var phieuxuat = await _context.phieuxuat.FindAsync(id);
            if (phieuxuat != null)
            {
                _context.phieuxuat.Remove(phieuxuat);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool phieuxuatExists(string id)
        {
            return _context.phieuxuat.Any(e => e.MaNV == id);
        }
    }
}
