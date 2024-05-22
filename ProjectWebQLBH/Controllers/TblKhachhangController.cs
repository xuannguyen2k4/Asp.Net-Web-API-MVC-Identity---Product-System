using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectWebQLBH.ModelFromDB;

namespace ProjectWebQLBH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblKhachhangController : ControllerBase
    {
        private readonly DBContextBH _dbContext;
        public TblKhachhangController(DBContextBH dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("/TblKhachhang/Get")]
        public IActionResult GetList()
        {
            return Ok(new { data = _dbContext.TblKhachhangs.ToList() });
        }

        [HttpPost]
        [Route("/TblKhachhang/Insert")]
        public IActionResult Insert(string ma, string ten, string diachi, string email, string sdt, DateTime? ngaysinh, string matkhau, string gioitinh)
        {
            TblKhachhang kh = new TblKhachhang();
            kh.KhId = Guid.NewGuid(); // tự sing khóa
            kh.KhMa = ma;
            kh.KhTen = ten;
            kh.KhDiachi = diachi;
            kh.KhEmail = email;
            kh.KhSđt = sdt;
            kh.KhNgaysinh = ngaysinh;
            kh.KhNgaythamgia = DateTime.Now;
            kh.KhMatkhau = matkhau;
            kh.KhGioitinh = gioitinh;

            _dbContext.TblKhachhangs.Add(kh);
            _dbContext.SaveChanges();

            return Ok(new { kh });
        }

        [HttpPost]
        [Route("/TblKhachhang/Update")]
        public IActionResult Update(Guid khId, string ma, string ten, string diachi, string email, string sdt, DateTime? ngaysinh, string matkhau, string gioitinh)
        {
            var kh = _dbContext.TblKhachhangs.Find(khId);
            if (kh == null)
            {
                return NotFound();
            }
            kh.KhMa = ma;
            kh.KhTen = ten;
            kh.KhDiachi = diachi;
            kh.KhEmail = email;
            kh.KhSđt = sdt;
            kh.KhNgaysinh = ngaysinh;
            kh.KhNgaythamgia = DateTime.Now;
            kh.KhMatkhau = matkhau;
            kh.KhGioitinh = gioitinh;

            _dbContext.TblKhachhangs.Update(kh);
            _dbContext.SaveChanges();

            return Ok(new { kh });
        }

        [HttpDelete]
        [Route("/TblKhachhang/Delete")]
        public IActionResult Delete(Guid khId)
        {
            var kh = _dbContext.TblKhachhangs.Find(khId);
            if (kh == null)
            {
                return NotFound();
            }

            var khachHangsToDelete = _dbContext.TblKhachhangs.Where(h => h.KhId == khId).ToList();
            _dbContext.TblKhachhangs.RemoveRange(khachHangsToDelete);
            _dbContext.SaveChanges();

            return Ok(new { khId });
        }
    }
}
