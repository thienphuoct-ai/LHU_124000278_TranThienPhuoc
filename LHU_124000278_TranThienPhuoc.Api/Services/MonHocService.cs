using LHU_124000278_TranThienPhuoc.Api.Database;
using LHU_124000278_TranThienPhuoc.Api.Database.Entities;
using LHU_124000278_TranThienPhuoc.Api.Dto;
using LHU_124000278_TranThienPhuoc.Api.IServices;
using Microsoft.EntityFrameworkCore;
using static LHU_124000278_TranThienPhuoc.Api.Services.MonHocService;

namespace LHU_124000278_TranThienPhuoc.Api.Services
{
    public class MonHocService : IMonHocService
    {
        DatabaseContext db;

        public MonHocService(DatabaseContext context)
        {
            db = context;
        }

        public async Task<bool> AddAsync(MonHocAddDto req)
        {
            bool tonTaiMonHoc = await db.MonHoc
                .Where(m => m.MaMon == req.MaMon)
                .AnyAsync();

            if (tonTaiMonHoc == true)
            {
                return false;
            }

            MonHocEntity newMonHoc = new MonHocEntity()
            {
                MaMon = req.MaMon,
                TenMon = req.TenMon,
                SoTinChi = req.SoTinChi,
                SoTietLyThuyet = req.SoTietLyThuyet
            };

            await db.AddAsync(newMonHoc);

            int affected = await db.SaveChangesAsync();

            if (affected > 0)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteAsync(int monHocId)
        {
            bool tonTaiLopHocPhan = await db.LopHocPhan
                .Where(l => l.MonHocID == monHocId)
                .AnyAsync();

            if (tonTaiLopHocPhan == true)
            {
                return false;
            }

            var monHoc = await db.MonHoc
                .Where(m => m.MonHocID == monHocId)
                .FirstOrDefaultAsync();

            if (monHoc == null)
            {
                return false;
            }

            db.MonHoc.Remove(monHoc);

            int affected = await db.SaveChangesAsync();

            return affected > 0;
        }

        public async Task<bool> EditAsync(MonHocEditDto req)
        {
            var monHoc = await db.MonHoc
                .Where(m => m.MonHocID == req.MonHocID)
                .FirstOrDefaultAsync();

            if (monHoc == null)
            {
                return false;
            }

            bool tonTaiMonHoc = await db.MonHoc
                .Where(m => m.MaMon == req.MaMon && m.MonHocID != req.MonHocID)
                .AnyAsync();

            if (tonTaiMonHoc == true)
            {
                return false;
            }

            monHoc.MaMon = req.MaMon;
            monHoc.TenMon = req.TenMon;
            monHoc.SoTinChi = req.SoTinChi;
            monHoc.SoTietLyThuyet = req.SoTietLyThuyet;

            await db.SaveChangesAsync();

            return true;
        }

        public async Task<List<MonHocDto>> GetAllAsync()
        {
            List<MonHocDto> danhSachMonHoc = await db.MonHoc
                .Select(m => new MonHocDto()
                {
                    MonHocID = m.MonHocID,
                    MaMon = m.MaMon,
                    TenMon = m.TenMon,
                    SoTinChi = m.SoTinChi,
                    SoTietLyThuyet = m.SoTietLyThuyet
                })
                .ToListAsync();

            return danhSachMonHoc;
        }
    }
}
