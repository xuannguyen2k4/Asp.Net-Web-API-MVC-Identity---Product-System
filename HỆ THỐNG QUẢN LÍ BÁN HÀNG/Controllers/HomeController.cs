using HỆ_THỐNG_QUẢN_LÍ_BÁN_HÀNG.Areas.Identity.Data;
using HỆ_THỐNG_QUẢN_LÍ_BÁN_HÀNG.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HỆ_THỐNG_QUẢN_LÍ_BÁN_HÀNG.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
           ViewData["UserID"] = _userManager.GetUserId(this.User);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult TblDonviVc()
        {
            return View();
        }

        public IActionResult TblSanpham()
        {
            return View();
        }

        public IActionResult TblCtdonhang()
        {
            return View();
        }

        public IActionResult TblKhachhang()
        {
            return View();
        }

        public IActionResult TblDonhang()
        {
            return View();
        }

        public IActionResult TblNhacungcap()
        {
            return View();
        }

        public IActionResult TblNhanvien()
        {
            return View();
        }

        public IActionResult TblPhieunhap()
        {
            return View();
        }

        public IActionResult TblPhieunhapCt(string pnId)
        {
            ViewBag.PnId = pnId; // Truyền pnId tới view
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
