using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectWebQLBH.ModelFromDB;

namespace ProjectWebQLBH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblDonhangController : ControllerBase
    {
        private readonly DBContextBH _dbContext;
        public TblDonhangController(DBContextBH dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("/TblDonhang/Get")]
        public IActionResult GetList()
        {
            var donHangs = _dbContext.TblDonhangs.ToList();
            return Ok(new { data = donHangs });
        }

        [HttpPost]
        [Route("/TblDonhang/Insert")]
        public IActionResult Insert(string ma, string khId, string dvccId, DateTime? ngayDatHang, string trangThai, DateTime? ngayDuKien, DateTime? ngayThuc, string nvId)
        {
            TblDonhang dh = new TblDonhang();
            dh.DhId = Guid.NewGuid(); //tự sinh khóa
            dh.DhKhId = new Guid(khId);
            dh.DhDvccId = new Guid(dvccId);
            dh.DhNvId = new Guid(nvId);
            dh.DhMa = ma;
            dh.DhNgayDatHang = ngayDatHang;
            dh.DhTrangThai = trangThai;
            dh.DhNgayDuKien = ngayDuKien;
            dh.DhNgayThuc = ngayThuc;

            _dbContext.TblDonhangs.Add(dh);
            _dbContext.SaveChanges();

            return Ok(new { dh });
        }

        [HttpPost]
        [Route("/TblDonhang/Update")]
        public IActionResult Update(Guid dhId, string ma, string khId, string dvccId, DateTime? ngayDatHang, string trangThai, DateTime? ngayDuKien, DateTime? ngayThuc, string nvId)
        {
            var dh = _dbContext.TblDonhangs.Find(dhId);
            if (dh == null)
            {
                return NotFound();
            }
            //cập nhật các thông tin của hàng hóa
            dh.DhKhId = new Guid(khId);
            dh.DhDvccId = new Guid(dvccId);
            dh.DhNvId = new Guid(nvId);
            dh.DhMa = ma;
            dh.DhNgayDatHang = ngayDatHang;
            dh.DhTrangThai = trangThai;
            dh.DhNgayDuKien = ngayDuKien;
            dh.DhNgayThuc = ngayThuc;

            _dbContext.TblDonhangs.Update(dh);
            _dbContext.SaveChanges();
            return Ok(new { dh });
        }

        [HttpDelete]
        [Route("/TblDonhang/Delete")]
        public IActionResult Delete(Guid dhId, Guid nvId, Guid dvvcId, Guid khId )
        {
            var dh = _dbContext.TblDonhangs.Find(dhId);
            if (dh == null)
            {
                return NotFound();
            }

            var donHangsToDelete = _dbContext.TblDonhangs.Where(h => h.DhId == dhId && h.DhKhId == khId && h.DhDvccId == dvvcId).ToList();
            _dbContext.TblDonhangs.RemoveRange(donHangsToDelete);
            _dbContext.SaveChanges();

            return Ok(new { dhId, khId, dvvcId });
        }
    }
}
