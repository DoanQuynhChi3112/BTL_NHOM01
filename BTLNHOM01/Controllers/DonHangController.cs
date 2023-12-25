using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BTLNHOM01.Data;
using BTLNHOM01.Models;
using X.PagedList;

namespace BTLNHOM01.Controllers
{
    public class DonHangController : Controller
    {
        private readonly ApplicationDbcontext _context;

        public DonHangController(ApplicationDbcontext context)
        {
            _context = context;
        }

        // GET: DonHang
        public async Task<IActionResult> Index(int? page, int? PageSize)
        {
             ViewBag.PageSize = new List<SelectListItem>()
                {
                    new SelectListItem() { Value="3", Text="3"},
                    new SelectListItem() { Value="5", Text="5"},
                    new SelectListItem() { Value="10", Text="10"},
                    new SelectListItem() { Value="15", Text="15"},
                    new SelectListItem() { Value="25", Text="25"},

                };
                int pagesize = (PageSize ?? 3);
                ViewBag.psize = PageSize;
                var model = _context.DanhMucHang.ToList().ToPagedList(page ?? 1, pagesize);
                var applicationDbcontext = _context.DonHang.Include(d => d.DanhMucHang).Include(d => d.KhachHang).Include(d => d.NhanVien);
                return View(await applicationDbcontext.ToListAsync());
        }

        // GET: DonHang/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donHang = await _context.DonHang
                .Include(d => d.DanhMucHang)
                .Include(d => d.KhachHang)
                .Include(d => d.NhanVien)
                .FirstOrDefaultAsync(m => m.DonHangID == id);
            if (donHang == null)
            {
                return NotFound();
            }

            return View(donHang);
        }

        // GET: DonHang/Create
        public IActionResult Create()
        {
            ViewData["MaHang"] = new SelectList(_context.DanhMucHang, "MaHang", "MaHang");
            ViewData["MaKH"] = new SelectList(_context.KhachHang, "MaKH", "MaKH");
            ViewData["MaNV"] = new SelectList(_context.NhanVien, "MaNV", "MaNV");
            return View();
        }

        // POST: DonHang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DonHangID,MaHang,MaKH,CreateDate,MaNV")] DonHang donHang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(donHang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaHang"] = new SelectList(_context.DanhMucHang, "MaHang", "MaHang", donHang.MaHang);
            ViewData["MaKH"] = new SelectList(_context.KhachHang, "MaKH", "MaKH", donHang.MaKH);
            ViewData["MaNV"] = new SelectList(_context.NhanVien, "MaNV", "MaNV", donHang.MaNV);
            return View(donHang);
        }

        // GET: DonHang/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donHang = await _context.DonHang.FindAsync(id);
            if (donHang == null)
            {
                return NotFound();
            }
            ViewData["MaHang"] = new SelectList(_context.DanhMucHang, "MaHang", "MaHang", donHang.MaHang);
            ViewData["MaKH"] = new SelectList(_context.KhachHang, "MaKH", "MaKH", donHang.MaKH);
            ViewData["MaNV"] = new SelectList(_context.NhanVien, "MaNV", "MaNV", donHang.MaNV);
            return View(donHang);
        }

        // POST: DonHang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("DonHangID,MaHang,MaKH,CreateDate,MaNV")] DonHang donHang)
        {
            if (id != donHang.DonHangID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donHang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonHangExists(donHang.DonHangID))
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
            ViewData["MaHang"] = new SelectList(_context.DanhMucHang, "MaHang", "MaHang", donHang.MaHang);
            ViewData["MaKH"] = new SelectList(_context.KhachHang, "MaKH", "MaKH", donHang.MaKH);
            ViewData["MaNV"] = new SelectList(_context.NhanVien, "MaNV", "MaNV", donHang.MaNV);
            return View(donHang);
        }

        // GET: DonHang/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donHang = await _context.DonHang
                .Include(d => d.DanhMucHang)
                .Include(d => d.KhachHang)
                .Include(d => d.NhanVien)
                .FirstOrDefaultAsync(m => m.DonHangID == id);
            if (donHang == null)
            {
                return NotFound();
            }

            return View(donHang);
        }

        // POST: DonHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var donHang = await _context.DonHang.FindAsync(id);
            if (donHang != null)
            {
                _context.DonHang.Remove(donHang);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonHangExists(string id)
        {
            return _context.DonHang.Any(e => e.DonHangID == id);
        }
    }
}
