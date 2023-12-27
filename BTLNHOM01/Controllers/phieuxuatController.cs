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
            var applicationDbcontext = _context.phieuxuat.Include(p => p.DanhMucHang).Include(p => p.DonHang).Include(p => p.NhaCungCap);
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
                .Include(p => p.DanhMucHang)
                .Include(p => p.DonHang)
                .Include(p => p.NhaCungCap)
                .FirstOrDefaultAsync(m => m.MaPX == id);
            if (phieuxuat == null)
            {
                return NotFound();
            }

            return View(phieuxuat);
        }

        // GET: phieuxuat/Create
        public IActionResult Create()
        {
            ViewData["TenHang"] = new SelectList(_context.DanhMucHang, "MaHang", "MaHang");
            ViewData["DonHangID"] = new SelectList(_context.DonHang, "DonHangID", "DonHangID");
            ViewData["MaNCC"] = new SelectList(_context.NhaCungCap, "MaNCC", "MaNCC");
            return View();
        }

        // POST: phieuxuat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaPX,DonHangID,TenHang,MaNCC,Soluong,thanhtien,Ngaytao")] phieuxuat phieuxuat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phieuxuat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TenHang"] = new SelectList(_context.DanhMucHang, "MaHang", "MaHang", phieuxuat.TenHang);
            ViewData["DonHangID"] = new SelectList(_context.DonHang, "DonHangID", "DonHangID", phieuxuat.DonHangID);
            ViewData["MaNCC"] = new SelectList(_context.NhaCungCap, "MaNCC", "MaNCC", phieuxuat.MaNCC);
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
            ViewData["TenHang"] = new SelectList(_context.DanhMucHang, "MaHang", "MaHang", phieuxuat.TenHang);
            ViewData["DonHangID"] = new SelectList(_context.DonHang, "DonHangID", "DonHangID", phieuxuat.DonHangID);
            ViewData["MaNCC"] = new SelectList(_context.NhaCungCap, "MaNCC", "MaNCC", phieuxuat.MaNCC);
            return View(phieuxuat);
        }

        // POST: phieuxuat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaPX,DonHangID,TenHang,MaNCC,Soluong,thanhtien,Ngaytao")] phieuxuat phieuxuat)
        {
            if (id != phieuxuat.MaPX)
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
                    if (!phieuxuatExists(phieuxuat.MaPX))
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
            ViewData["TenHang"] = new SelectList(_context.DanhMucHang, "MaHang", "MaHang", phieuxuat.TenHang);
            ViewData["DonHangID"] = new SelectList(_context.DonHang, "DonHangID", "DonHangID", phieuxuat.DonHangID);
            ViewData["MaNCC"] = new SelectList(_context.NhaCungCap, "MaNCC", "MaNCC", phieuxuat.MaNCC);
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
                .Include(p => p.DanhMucHang)
                .Include(p => p.DonHang)
                .Include(p => p.NhaCungCap)
                .FirstOrDefaultAsync(m => m.MaPX == id);
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
            return _context.phieuxuat.Any(e => e.MaPX == id);
        }
    }
}
