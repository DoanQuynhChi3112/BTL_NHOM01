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
    public class DanhMucHangController : Controller
    {
        private readonly ApplicationDbcontext _context;

        public DanhMucHangController(ApplicationDbcontext context)
        {
            _context = context;
        }
        //Phan trang
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
                return View(model);
                         
        }
       

        // GET: DanhMucHang/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danhMucHang = await _context.DanhMucHang
                .FirstOrDefaultAsync(m => m.MaHang == id);
            if (danhMucHang == null)
            {
                return NotFound();
            }

            return View(danhMucHang);
        }

        // GET: DanhMucHang/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DanhMucHang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaHang,TenHang,DonViTinh,SoLuong,GiaSP")] DanhMucHang danhMucHang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(danhMucHang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(danhMucHang);
        }

        // GET: DanhMucHang/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danhMucHang = await _context.DanhMucHang.FindAsync(id);
            if (danhMucHang == null)
            {
                return NotFound();
            }
            return View(danhMucHang);
        }

        // POST: DanhMucHang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaHang,TenHang,DonViTinh,SoLuong,GiaSP")] DanhMucHang danhMucHang)
        {
            if (id != danhMucHang.MaHang)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(danhMucHang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DanhMucHangExists(danhMucHang.MaHang))
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
            return View(danhMucHang);
        }

        // GET: DanhMucHang/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danhMucHang = await _context.DanhMucHang
                .FirstOrDefaultAsync(m => m.MaHang == id);
            if (danhMucHang == null)
            {
                return NotFound();
            }

            return View(danhMucHang);
        }

        // POST: DanhMucHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var danhMucHang = await _context.DanhMucHang.FindAsync(id);
            if (danhMucHang != null)
            {
                _context.DanhMucHang.Remove(danhMucHang);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DanhMucHangExists(string id)
        {
            return _context.DanhMucHang.Any(e => e.MaHang == id);
        }
    }
}
