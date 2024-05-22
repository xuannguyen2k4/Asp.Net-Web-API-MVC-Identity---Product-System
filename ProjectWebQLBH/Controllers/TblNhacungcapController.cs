using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectWebQLBH.ModelFromDB;

namespace ProjectWebQLBH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblNhacungcapController : ControllerBase
    {
        private readonly DBContextBH _dbContext;
        public TblNhacungcapController(DBContextBH dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("/TblNhacungcap/Get")]
        public IActionResult GetList()
        {
            return Ok(new { data = _dbContext.TblNhacungcaps.ToList() });
        }

        [HttpPost]
        [Route("/TblNhacungcap/Insert")]
        public IActionResult Insert(string ma, string ten, string diachi, string sdt)
        {
            TblNhacungcap ncc = new TblNhacungcap();
            ncc.CcId = Guid.NewGuid(); // tự sing khóa
            ncc.CcMa = ma;
            ncc.CcTenNcc = ten;
            ncc.CcDiachi = diachi;
            ncc.CcSđt = sdt;
            

            _dbContext.TblNhacungcaps.Add(ncc);
            _dbContext.SaveChanges();

            return Ok(new { ncc });
        }

        [HttpPost]
        [Route("/TblNhacungcap/Update")]
        public IActionResult Update(Guid nccId, string ma, string ten, string diachi, string sdt)
        {
            var ncc = _dbContext.TblNhacungcaps.Find(nccId);
            if (ncc == null)
            {
                return NotFound();
            }
            ncc.CcMa = ma;
            ncc.CcTenNcc = ten;
            ncc.CcDiachi = diachi;
            ncc.CcSđt = sdt;
            _dbContext.TblNhacungcaps.Update(ncc);
            _dbContext.SaveChanges();

            return Ok(new { ncc });
        }

        [HttpDelete]
        [Route("/TblNhacungcap/Delete")]
        public IActionResult Delete(Guid nccId)
        {
            var ncc = _dbContext.TblNhacungcaps.Find(nccId);
            if (ncc == null)
            {
                return NotFound();
            }

            var nhaCungCapsToDelete = _dbContext.TblNhacungcaps.Where(h => h.CcId == nccId).ToList();
            _dbContext.TblNhacungcaps.RemoveRange(nhaCungCapsToDelete);
            _dbContext.SaveChanges();

            return Ok(new { nccId });
        }
    }
}
