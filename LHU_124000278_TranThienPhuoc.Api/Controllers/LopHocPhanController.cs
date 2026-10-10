using LHU_124000278_TranThienPhuoc.Api.Database;
using LHU_124000278_TranThienPhuoc.Api.Database.Entities;
using LHU_124000278_TranThienPhuoc.Api.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace LHU_124000278_TranThienPhuoc.Api.Controllers
{
    [Route("api/lop-hoc-phan")]
    [ApiController]
    public class LopHocPhanController : ControllerBase
    {
        DatabaseContext db;

        public LopHocPhanController(DatabaseContext context)
        {
            db = context;
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<List<LopHocPhanDto>>> GetAll()
        {
            List<LopHocPhanDto> danhSachLopHocPhan = await db.LopHocPhan
                .Select(l => new LopHocPhanDto()
                {
                    LopHocPhanID = l.LopHocPhanID,
                    MonHocID = l.MonHocID,
                    MaLopHP = l.MaLopHP,
                    HocKy = l.HocKy,
                    NamHoc = l.NamHoc,
                    SiSoToiDa = l.SiSoToiDa
                })
                .ToListAsync();

            return Ok(danhSachLopHocPhan);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(LopHocPhanAddDto req)
        {
            LopHocPhanEntity newLopHocPhan = new LopHocPhanEntity()
            {
                MonHocID = req.MonHocID,
                MaLopHP = req.MaLopHP,
                HocKy = req.HocKy,
                NamHoc = req.NamHoc,
                SiSoToiDa = req.SiSoToiDa
            };

            await db.LopHocPhan.AddAsync(newLopHocPhan);
            await db.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("edit")]
        public async Task<IActionResult> edit(LopHocPhanEditDto req)
        {
            var lopHocPhan = await db.LopHocPhan.Where(l => l.LopHocPhanID == req.LopHocPhanID).FirstOrDefaultAsync();
            if (lopHocPhan == null)
            {
                return NotFound();
            }

            lopHocPhan.MonHocID = req.MonHocID;
            lopHocPhan.MaLopHP = req.MaLopHP;
            lopHocPhan.HocKy = req.HocKy;
            lopHocPhan.NamHoc = req.NamHoc;
            lopHocPhan.SiSoToiDa = req.SiSoToiDa;

            await db.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> delete(int id)
        {
            var lopHocPhan = await db.LopHocPhan.Where(l => l.LopHocPhanID == id).FirstOrDefaultAsync();
            if (lopHocPhan == null)
            {
                return NotFound();
            }

            db.LopHocPhan.Remove(lopHocPhan);
            await db.SaveChangesAsync();
            return Ok();
        }
    }
}
