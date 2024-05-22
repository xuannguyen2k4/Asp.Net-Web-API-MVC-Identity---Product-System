using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectWebQLBH.ModelFromDB;

namespace ProjectWebQLBH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblNhanvienController : ControllerBase
    {
        private readonly DBContextBH _dbContext;
        public TblNhanvienController(DBContextBH dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("/TblNhanvien/Get")]
        public IActionResult GetList()
        {
            return Ok(new { data = _dbContext.TblNhanviens.ToList() });
        }

        [HttpPost]
        [Route("/TblNhanvien/Insert")]
        public IActionResult Insert(string ma, string ten, string diachi, string email, string sdt, DateTime? ngaysinh, string matkhau, string gioitinh)
        {
            TblNhanvien nv = new TblNhanvien();
            nv.NvId = Guid.NewGuid(); // Tự sinh khóa chính
            nv.NvMa = ma;
            nv.NvTen = ten;
            nv.NvDiachi = diachi;
            nv.NvEmail = email;
            nv.NvSđt = sdt;
            nv.NvNgaysinh = ngaysinh;
            nv.NvNgaythamgia = DateTime.Now;
            nv.NvMatkhau = matkhau;
            nv.NvGioitinh = gioitinh;


            _dbContext.TblNhanviens.Add(nv);
            _dbContext.SaveChanges();

            return Ok(new { nv });
        }

        [HttpPost]
        [Route("/TblNhanvien/Update")]
        public IActionResult Update(Guid nvId, string ma, string ten, string diachi, string email, string sdt, DateTime? ngaysinh, string matkhau, string gioitinh)
        {
            var nv = _dbContext.TblNhanviens.Find(nvId);
            if (nv == null)
            {
                return NotFound();
            }
            nv.NvMa = ma;
            nv.NvTen = ten;
            nv.NvDiachi = diachi;
            nv.NvEmail = email;
            nv.NvSđt = sdt;
            nv.NvNgaysinh = ngaysinh;
            nv.NvNgaythamgia = DateTime.Now;
            nv.NvMatkhau = matkhau;
            nv.NvGioitinh = gioitinh;

            _dbContext.TblNhanviens.Update(nv);
            _dbContext.SaveChanges();

            return Ok(new { nv });
        }

        [HttpDelete]
        [Route("/TblNhanvien/Delete")]
        public IActionResult Delete(Guid nvId)
        {
            var nv = _dbContext.TblNhanviens.Find(nvId);
            if (nv == null)
            {
                return NotFound();
            }

            var nhanViensToDelete = _dbContext.TblNhanviens.Where(h => h.NvId == nvId).ToList();
            _dbContext.TblNhanviens.RemoveRange(nhanViensToDelete);
            _dbContext.SaveChanges();

            return Ok(new { nvId });
        }
    }
}
