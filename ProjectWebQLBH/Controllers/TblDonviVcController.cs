using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectWebQLBH.ModelFromDB;

namespace ProjectWebQLBH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblDonviVcController : ControllerBase
    {
        private readonly DBContextBH _dbContext;
        public TblDonviVcController(DBContextBH dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("/TblDonviVc/Get")]
        public IActionResult GetList()
        {
            return Ok(new { data = _dbContext.TblDonviVcs.ToList() });
        }

        [HttpPost]
        [Route("/TblDonviVc/Insert")]
        public IActionResult Insert(string ma, string ten, string diachi, string sdt)
        {
            TblDonviVc dvvc = new TblDonviVc();
            dvvc.VcId = Guid.NewGuid(); // tự sing khóa
            dvvc.VcMa = ma;
            dvvc.VcTen = ten;
            dvvc.VcDiachilienlac = diachi;
            dvvc.VcSđt = sdt;


            _dbContext.TblDonviVcs.Add(dvvc);
            _dbContext.SaveChanges();

            return Ok(new { dvvc });
        }

        [HttpPost]
        [Route("/TblDonviVc/Update")]
        public IActionResult Update(Guid dvvcId, string ma, string ten, string diachi, string sdt)
        {
            var dvvc = _dbContext.TblDonviVcs.Find(dvvcId);
            if (dvvc == null)
            {
                return NotFound();
            }
            dvvc.VcMa = ma;
            dvvc.VcTen = ten;
            dvvc.VcDiachilienlac = diachi;
            dvvc.VcSđt = sdt;

            _dbContext.TblDonviVcs.Update(dvvc);
            _dbContext.SaveChanges();

            return Ok(new { dvvc });
        }

        [HttpDelete]
        [Route("/TblDonviVc/Delete")]
        public IActionResult Delete(Guid dvvcId)
        {
            var dvvc = _dbContext.TblDonviVcs.Find(dvvcId);
            if (dvvc == null)
            {
                return NotFound();
            }

            var donViVCsToDelete = _dbContext.TblDonviVcs.Where(h => h.VcId == dvvcId).ToList();
            _dbContext.TblDonviVcs.RemoveRange(donViVCsToDelete);
            _dbContext.SaveChanges();

            return Ok(new { dvvcId });
        }
    }
}
