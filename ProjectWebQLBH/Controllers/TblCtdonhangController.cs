using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectWebQLBH.ModelFromDB;

namespace ProjectWebQLBH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblCtdonhangController : ControllerBase
    {
        private readonly DBContextBH _dbContext;
        public TblCtdonhangController(DBContextBH dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("/TblCtdonhang/Get")]
        public IActionResult GetList()
        {
            var ctdonHangs = _dbContext.TblCtdonhangs.ToList();
            return Ok(new { data = ctdonHangs });
        }

        [HttpPost]
        [Route("/TblCtdonhang/Insert")]
        public IActionResult Insert(string ma, string dhId, string spId, double? giaSp, int? soluong)
        {
            TblCtdonhang ctdh = new TblCtdonhang();
            ctdh.CtId = Guid.NewGuid(); // tự sinh khóa
            ctdh.CtDhId = new Guid(dhId);
            ctdh.CtSpId = new Guid(spId);
            ctdh.CtMa = ma;
            ctdh.CtGiaSp = giaSp;
            ctdh.CtSoluong = soluong;

            _dbContext.TblCtdonhangs.Add(ctdh);
            _dbContext.SaveChanges();

            return Ok(new { ctdh });
        }

        [HttpPost]
        [Route("/TblCtdonhang/Update")]
        public IActionResult Update(Guid ctdhId, string ma, string dhId, string spId, double? giaSp, int? soluong)
        {
            var ctdh = _dbContext.TblCtdonhangs.Find(ctdhId);
            if (ctdh == null)
            {
                return NotFound();
            }
            //cập nhật các thông tin của hàng hóa
            ctdh.CtDhId = new Guid(dhId);
            ctdh.CtSpId = new Guid(spId);
            ctdh.CtMa = ma;
            ctdh.CtGiaSp = giaSp;
            ctdh.CtSoluong = soluong;

            _dbContext.TblCtdonhangs.Update(ctdh);
            _dbContext.SaveChanges();
            return Ok(new { ctdh });
        }

        [HttpDelete]
        [Route("/TblCtdonhang/Delete")]
        public IActionResult Delete(Guid ctdhId, Guid dhId, Guid spId)
        {
            var ctdh = _dbContext.TblCtdonhangs.Find(ctdhId);
            if (ctdh == null)
            {
                return NotFound();
            }

            var ctdonHangsToDelete = _dbContext.TblCtdonhangs.Where(h => h.CtId == ctdhId && h.CtSpId == spId && h.CtDhId == dhId).ToList();
            _dbContext.TblCtdonhangs.RemoveRange(ctdonHangsToDelete);
            _dbContext.SaveChanges();

            return Ok(new { ctdhId, dhId, spId });
        }

    }
}
