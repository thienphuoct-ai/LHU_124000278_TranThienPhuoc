using Dapper;
using LHU_124000278_TranThienPhuoc.Api.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace LHU_124000278_TranThienPhuoc.Api.Controllers
{
    [Route("api/dang-ky")]
    [ApiController]
    public class DangKyController : ControllerBase
    {
        SqlConnection cn;

        public DangKyController(SqlConnection connection)
        {
            cn = connection;
        }

        [HttpPost("them-moi")]
        public async Task<IActionResult> ThemMoi(DangKyAddDto req)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@SinhVienId", req.SinhVienID);
            param.Add("@LopHocPhanId", req.LopHocPhanID);
            param.Add("@KetQua", dbType: DbType.Int32, direction: ParameterDirection.Output);
            param.Add("@ThongBao", dbType: DbType.String, direction: ParameterDirection.Output, size: 255);

            await cn.ExecuteAsync("sp_DangKyHocPhan", param, commandType: CommandType.StoredProcedure);

            int ketQua = param.Get<int>("@KetQua");
            string thongBao = param.Get<string>("@ThongBao");

            if (ketQua == 0)
            {
                return BadRequest(thongBao);
            }

            return Ok(thongBao);
        }
    }
}
