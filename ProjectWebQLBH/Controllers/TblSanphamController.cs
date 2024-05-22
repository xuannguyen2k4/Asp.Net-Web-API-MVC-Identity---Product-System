using CsvHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectWebQLBH.ModelFromDB;
using System.Formats.Asn1;

namespace ProjectWebQLBH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblSanphamController : ControllerBase
    {
        private readonly DBContextBH _dbContext;
        public TblSanphamController(DBContextBH dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("/TblSanpham/Get")]
        public IActionResult GetList()
        {
            var sanPhams = _dbContext.TblSanphams.ToList();
            return Ok(new { data = sanPhams });
        }

        [HttpPost]
        [Route("/TblSanpham/Insert")]
        public IActionResult Insert(string ma, string ten, string mota, string donvi, double? giaban, DateTime? nsx, DateTime? hsd, string ccId)
        {
            TblSanpham sp = new TblSanpham();
            sp.SpId = Guid.NewGuid(); // Tự sinh khóa chính
            sp.SpCcId = new Guid(ccId);
            sp.SpMa = ma;
            sp.SpTenSp = ten;
            sp.SpMota = mota;
            sp.SpDonvi = donvi;
            sp.SpGiaban = giaban;
            sp.SpNsx = nsx;
            sp.SpHsd = hsd;

            _dbContext.TblSanphams.Add(sp);
            _dbContext.SaveChanges();

            return Ok(new { sp });
        }

        [HttpPost]
        [Route("/TblSanpham/Update")]
        public IActionResult Update(Guid spId, string ccId, string ma, string ten, string mota, string donvi, double? giaban, DateTime? nsx, DateTime? hsd)
        {
            var sp = _dbContext.TblSanphams.Find(spId);
            if (sp == null)
            {
                return NotFound();
            }
            //cập nhật các thông tin của hàng hóa
            sp.SpCcId = new Guid(ccId);
            sp.SpMa = ma;
            sp.SpTenSp = ten;
            sp.SpMota = mota;
            sp.SpDonvi = donvi;
            sp.SpGiaban = giaban;
            sp.SpNsx = nsx;
            sp.SpHsd = hsd;

            _dbContext.TblSanphams.Update(sp);
            _dbContext.SaveChanges();
            return Ok(new { sp });
        }

        [HttpDelete]
        [Route("/TblSanpham/Delete")]
        public IActionResult Delete(Guid spId, Guid ccId)
        {
            var sp = _dbContext.TblSanphams.Find(spId);
            if (sp == null)
            {
                return NotFound();
            }

            var sanPhamsToDelete = _dbContext.TblSanphams.Where(h => h.SpId == spId && h.SpCcId == ccId).ToList();
            _dbContext.TblSanphams.RemoveRange(sanPhamsToDelete);
            _dbContext.SaveChanges();

            return Ok(new { spId, ccId });
        }
    }
}
