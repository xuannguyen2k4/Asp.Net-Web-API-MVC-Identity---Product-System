using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectWebQLBH.ModelFromDB;

namespace ProjectWebQLBH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblPhieunhapController : ControllerBase
    {
        private readonly DBContextBH _dbContext;
        public TblPhieunhapController(DBContextBH dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("/TblPhieunhap/Get")]
        public IActionResult GetList()
        {
            return Ok(new { data = _dbContext.TblPhieunhaps.ToList() });
        }

        [HttpPost]
        [Route("/TblPhieunhap/Insert")]
        public IActionResult Insert(string ma, DateTime? ngaynhap, double? tien, string nccId, string nvId)
        {
            TblPhieunhap pn = new TblPhieunhap();
            pn.PnId = Guid.NewGuid();
            pn.PnNccId = new Guid(nccId);
            pn.PnNvId = new Guid(nvId);
            pn.PnMa = ma;
            pn.PnNgaynhap = ngaynhap;
            pn.PnTien = tien;


            _dbContext.TblPhieunhaps.Add(pn);
            _dbContext.SaveChanges();

            return Ok(new { pn });
        }

        [HttpPost]
        [Route("UpdateTotalAmount")]
        public IActionResult UpdateTotalAmount(Guid pnId, double totalAmount)
        {
            // Lấy phiếu nhập từ cơ sở dữ liệu
            var phieunhap = _dbContext.TblPhieunhaps.Find(pnId);

            // Cập nhật tổng số tiền
            if (phieunhap != null)
            {
                phieunhap.PnTien = totalAmount;
                _dbContext.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound("Không tìm thấy phiếu nhập.");
            }
        }

        //[HttpPost]
        //[Route("/TblPhieunhap/Update")]
        //public IActionResult Update(Guid pnId, string ma, DateTime? ngaynhap, double? tien, string nccId, string nvId)
        //{
        //    var pn = _dbContext.TblPhieunhaps.Find(pnId);
        //    if (pn == null)
        //    {
        //        return NotFound();
        //    }
        //    pn.PnNccId = new Guid(nccId);
        //    pn.PnNvId = new Guid(nvId);
        //    pn.PnMa = ma;
        //    pn.PnNgaynhap = ngaynhap;
        //    pn.PnTien = tien;


        //    _dbContext.TblPhieunhaps.Update(pn);
        //    _dbContext.SaveChanges();

        //    return Ok(new { pn });
        //}


        [HttpDelete]
        [Route("/TblPhieunhap/Delete")]
        public IActionResult Delete(Guid pnId, Guid nccId, Guid nvId)
        {
            var pn = _dbContext.TblPhieunhaps.Find(pnId);
            if (pn == null)
            {
                return NotFound();
            }

            var phieuNhapsToDelete = _dbContext.TblPhieunhaps.Where(h => h.PnId == pnId && h.PnNccId == nccId && h.PnNvId == nvId).ToList();
            _dbContext.TblPhieunhaps.RemoveRange(phieuNhapsToDelete);
            _dbContext.SaveChanges();

            return Ok(new { pnId,nccId,nvId });
        }
    }
}
