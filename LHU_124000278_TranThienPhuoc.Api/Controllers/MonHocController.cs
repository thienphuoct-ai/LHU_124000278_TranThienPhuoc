using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LHU_124000278_TranThienPhuoc.Api.Database;
using LHU_124000278_TranThienPhuoc.Api.Dto;
using LHU_124000278_TranThienPhuoc.Api.IServices;
using Microsoft.EntityFrameworkCore;
using LHU_124000278_TranThienPhuoc.Api.Database.Entities;

namespace LHU_124000278_TranThienPhuoc.Api.Controllers
{
    [Route("api/mon-hoc")]
    [ApiController]
    public class MonHocController : ControllerBase
    {
        IMonHocService monHocService;

        public MonHocController(IMonHocService monHocService)
        {
            this.monHocService = monHocService;
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<List<MonHocDto>>> GetAll()
        {
            var danhSachMonHoc = await monHocService.GetAllAsync();

            return Ok(danhSachMonHoc);
        }
        [HttpPost("add")]
        public async Task<IActionResult> Add(MonHocAddDto req)
        {
            bool isSuccess = await monHocService.AddAsync(req);

            if (isSuccess == false) return BadRequest();

            return Ok();
        }
        [HttpPut("edit")]
        public async Task<IActionResult> edit(MonHocEditDto req)
        {
            bool isSuccess = await monHocService.EditAsync(req);

            if (isSuccess == false) return BadRequest();

            return Ok();

        }
        [HttpDelete("delete")]
        public async Task<IActionResult> delete(int id)
        {
            bool isSuccess = await monHocService.DeleteAsync(id);

            if (!isSuccess) return BadRequest();

            return Ok();
        }
    }
}
