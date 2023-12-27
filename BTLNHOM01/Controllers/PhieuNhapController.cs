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
    public class PhieuNhapController : Controller
    {
        private readonly ApplicationDbcontext _context;

        public PhieuNhapController(ApplicationDbcontext context)
        {
            _context = context;
        }

        // GET: PhieuNhap
        public async Task<IActionResult> Index()
        {
            var applicationDbcontext = _context.PhieuNhap.Include(p => p.DanhMucHang).Include(p => p.NhaCungCap);
            return View(await applicationDbcontext.ToListAsync());
        }

        // GET: PhieuNhap/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieuNhap = await _context.PhieuNhap
                .Include(p => p.DanhMucHang)
                .Include(p => p.NhaCungCap)
                .FirstOrDefaultAsync(m => m.MaPN == id);
            if (phieuNhap == null)
            {
                return NotFound();
            }

            return View(phieuNhap);
        }

        // GET: PhieuNhap/Create
        public IActionResult Create()
        {
            ViewData["TenHang"] = new SelectList(_context.DanhMucHang, "MaHang", "MaHang");
            ViewData["MaNCC"] = new SelectList(_context.NhaCungCap, "MaNCC", "MaNCC");
            return View();
        }

        // POST: PhieuNhap/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaPN,TenHang,MaNCC,Soluong,thanhtien,Ngaytao")] PhieuNhap phieuNhap)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phieuNhap);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TenHang"] = new SelectList(_context.DanhMucHang, "MaHang", "MaHang", phieuNhap.TenHang);
            ViewData["MaNCC"] = new SelectList(_context.NhaCungCap, "MaNCC", "MaNCC", phieuNhap.MaNCC);
            return View(phieuNhap);
        }

        // GET: PhieuNhap/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieuNhap = await _context.PhieuNhap.FindAsync(id);
            if (phieuNhap == null)
            {
                return NotFound();
            }
            ViewData["TenHang"] = new SelectList(_context.DanhMucHang, "MaHang", "MaHang", phieuNhap.TenHang);
            ViewData["MaNCC"] = new SelectList(_context.NhaCungCap, "MaNCC", "MaNCC", phieuNhap.MaNCC);
            return View(phieuNhap);
        }

        // POST: PhieuNhap/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaPN,TenHang,MaNCC,Soluong,thanhtien,Ngaytao")] PhieuNhap phieuNhap)
        {
            if (id != phieuNhap.MaPN)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phieuNhap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhieuNhapExists(phieuNhap.MaPN))
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
            ViewData["TenHang"] = new SelectList(_context.DanhMucHang, "MaHang", "MaHang", phieuNhap.TenHang);
            ViewData["MaNCC"] = new SelectList(_context.NhaCungCap, "MaNCC", "MaNCC", phieuNhap.MaNCC);
            return View(phieuNhap);
        }

        // GET: PhieuNhap/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieuNhap = await _context.PhieuNhap
                .Include(p => p.DanhMucHang)
                .Include(p => p.NhaCungCap)
                .FirstOrDefaultAsync(m => m.MaPN == id);
            if (phieuNhap == null)
            {
                return NotFound();
            }

            return View(phieuNhap);
        }

        // POST: PhieuNhap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var phieuNhap = await _context.PhieuNhap.FindAsync(id);
            if (phieuNhap != null)
            {
                _context.PhieuNhap.Remove(phieuNhap);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhieuNhapExists(string id)
        {
            return _context.PhieuNhap.Any(e => e.MaPN == id);
        }
    }
}
