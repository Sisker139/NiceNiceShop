using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NNShop.Data;
using NNShop.ViewComponents;
using NNShop.ViewModels;

namespace NNShop.Controllers
{
    public class HangHoaController : Controller
    {
        private readonly NnshopContext db;

        public HangHoaController(NnshopContext context)
        {
            db = context;
        }
        public IActionResult Index(int? loai)
        {
            var hangHoas = db.HangHoas.AsQueryable();
            if (loai.HasValue)
            {
                hangHoas = hangHoas.Where(p => p.MaLoaiHh == loai.Value);
            }
            var result = hangHoas.Select(p => new HangHoaVM
            {
                MaHh = p.MaHh,
                TenHH = p.TenHh,
                DonGia = p.DonGia ?? 0,
                Hinh = p.Hinh ?? "",
                MoTa = p.MoTa ?? "",
                TenLoai = p.MaLoaiHhNavigation.TenLoaiHh


            });
            return View(result);
        }

        public IActionResult Search(string query)
        {
            var hangHoas = db.HangHoas.AsQueryable();
            if (query != null)
            {
                hangHoas = hangHoas.Where(p => p.TenHh.Contains(query));
            }
            var result = hangHoas.Select(p => new HangHoaVM
            {
                MaHh = p.MaHh,
                TenHH = p.TenHh,
                DonGia = p.DonGia ?? 0,
                Hinh = p.Hinh ?? "",
                MoTa = p.MoTa ?? "",
                TenLoai = p.MaLoaiHhNavigation.TenLoaiHh


            });
            return View(result);
        }
        public IActionResult Detail(string id)
        {
            var data = db.HangHoas
                .Include(p => p.MaLoaiHhNavigation)
                .SingleOrDefault(p => p.MaHh == id);
            if (data == null)
            {
                TempData["Message"] = $"Không tìm thấy sản phẩm có mã {id}";
                return Redirect("/404");
            }
            var result = new ChiTietHangHoaVM
            {
                MaHh = data.MaHh,
                TenHH = data.TenHh,
                DonGia = data.DonGia ?? 0,
                MoTa = data.MoTa ?? String.Empty,
                Hinh = data.Hinh ?? String.Empty,
                TenLoai = data.MaLoaiHhNavigation.TenLoaiHh,
                SoLuong = data.SoLuong,
                GiamGia = data.GiamGia,
                ChiTiet = data.ChiTietHh ?? String.Empty

            };
            return View(result);

        }
    }
}
