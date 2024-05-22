using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectWebQLBH.ModelFromDB;

namespace ProjectWebQLBH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblPhieunhapCtController : ControllerBase
    {
        private readonly DBContextBH _dbContext;
        public TblPhieunhapCtController(DBContextBH dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("/TblPhieunhapCt/Get")]
        public IActionResult GetList()
        {
            var phieuNhapCTs = _dbContext.TblPhieunhapCts.ToList();
            return Ok(new { data = phieuNhapCTs });
        }

        [HttpPost]
        [Route("/TblPhieunhapCt/Insert")]
        public IActionResult Insert(string ma, double? gianhap, int? soluong, string spId, string nccId, string pnId)
        {
            if (string.IsNullOrEmpty(ma) || !gianhap.HasValue || !soluong.HasValue ||
        string.IsNullOrEmpty(spId) || string.IsNullOrEmpty(nccId) || string.IsNullOrEmpty(pnId))
            {
                return BadRequest("Invalid input data.");
            }

            TblPhieunhapCt pnct = new TblPhieunhapCt
            {
                CtnId = Guid.NewGuid(),
                CtnMa = ma,
                CtnGianhap = gianhap,
                CtnSoluong = soluong,
                //CtnTongtien = gianhap * soluong, // Cần để trigger cập nhật chính xác `PN_Tien`
                CtnSpId = new Guid(spId),
                CtnNccId = new Guid(nccId),
                CtnPnId = new Guid(pnId)
            };

            pnct.UpdateTongtien(); //Calculate total amount before saving


            _dbContext.TblPhieunhapCts.Add(pnct);
            _dbContext.SaveChanges();

            return Ok(new { pnct });
        }

        [HttpGet]
        [Route("/TblPhieunhapCt/GetById")]
        public IActionResult GetById(string pnId)
        {
            if (Guid.TryParse(pnId, out var guidPnId))
            {
                var phieuNhapCt = _dbContext.TblPhieunhapCts.Where(p => p.CtnPnId == guidPnId).ToList();
                if (phieuNhapCt != null)
                {
                    return Ok(new { data = phieuNhapCt });
                }
                else
                {
                    return NotFound("Không tìm thấy chi tiết cho pnId được cung cấp.");
                }
            }
            else
            {
                return BadRequest("pnId không hợp lệ.");
            }
        }


        [HttpPost]
        [Route("/TblPhieunhapCt/Update")]
        public IActionResult Update(Guid pnctId, string ma, double? gianhap, int? soluong, string spId, string nccId, string pnId)
        {
            var pnct = _dbContext.TblPhieunhapCts.Find(pnctId);
            if (pnct == null)
            {
                return NotFound();
            }

            if (string.IsNullOrEmpty(ma) || !gianhap.HasValue || !soluong.HasValue ||
        string.IsNullOrEmpty(spId) || string.IsNullOrEmpty(nccId) || string.IsNullOrEmpty(pnId))
            {
                return BadRequest("Invalid input data.");
            }
            //cập nhật các thông tin của hàng hóa
            pnct.CtnMa = ma;
            pnct.CtnGianhap = gianhap;
            pnct.CtnSoluong = soluong;
           // pnct.CtnTongtien = gianhap * soluong; // Cần để trigger cập nhật chính xác `PN_Tien`
            pnct.CtnSpId = new Guid(spId);
            pnct.CtnNccId = new Guid(nccId);
            pnct.CtnPnId = new Guid(pnId);

            _dbContext.TblPhieunhapCts.Update(pnct);
            _dbContext.SaveChanges();
            return Ok(new { pnct });
        }

        [HttpDelete]
        [Route("/TblPhieunhapCt/Delete")]
        public IActionResult Delete(Guid pnctId, Guid nccId, Guid spId, Guid pnId)
        {
            var pnct = _dbContext.TblPhieunhapCts.Find(pnctId);
            if (pnct == null)
            {
                return NotFound();
            }

            var phieuNhapCTsToDelete = _dbContext.TblPhieunhapCts.Where(h => h.CtnId == pnctId && h.CtnNccId == nccId && h.CtnSpId == spId && h.CtnPnId == pnId).ToList();
            _dbContext.TblPhieunhapCts.RemoveRange(phieuNhapCTsToDelete);
            _dbContext.SaveChanges();

            return Ok(new { pnctId, nccId, spId, pnId });
        }

    }
}
