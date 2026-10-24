using LHU_124000278_TranThienPhuoc.Api.Database;
using LHU_124000278_TranThienPhuoc.Api.Database.Entities;
using LHU_124000278_TranThienPhuoc.Api.Dto;
using LHU_124000278_TranThienPhuoc.Api.IServices;
using Microsoft.EntityFrameworkCore;
namespace LHU_124000278_TranThienPhuoc.Api.Services
{
    public class LopHocPhan : ILopHocPhan
    {
        DatabaseContext db;

        public LopHocPhan(DatabaseContext context)
        {
            db = context;
        }

        public async Task<List<LopHocPhanDto>> GetAllAsync()
        {
            var danhSachLopHocPhan = await db.LopHocPhan
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

            return danhSachLopHocPhan;
        }

        public async Task<bool> AddAsync(LopHocPhanAddDto req)
        {
            bool tonTaiMaLopHP = await db.LopHocPhan
                .Where(l => l.MaLopHP == req.MaLopHP)
                .AnyAsync();

            if (tonTaiMaLopHP)
            {
                return false;
            }

            bool tonTaiMonHoc = await db.MonHoc
                .Where(m => m.MonHocID == req.MonHocID)
                .AnyAsync();

            if (!tonTaiMonHoc)
            {
                return false;
            }

            LopHocPhanEntity newLopHocPhan = new LopHocPhanEntity()
            {
                MonHocID = req.MonHocID,
                MaLopHP = req.MaLopHP,
                HocKy = req.HocKy,
                NamHoc = req.NamHoc,
                SiSoToiDa = req.SiSoToiDa,
                NgayBatDau = req.NgayBatDau,
                NgayKetThuc = req.NgayKetThuc
            };

            await db.AddAsync(newLopHocPhan);

            int affected = await db.SaveChangesAsync();

            return affected > 0;
        }

        public async Task<bool> EditAsync(LopHocPhanEditDto req)
        {
            var lopHocPhan = await db.LopHocPhan
                .Where(l => l.LopHocPhanID == req.LopHocPhanID)
                .FirstOrDefaultAsync();

            if (lopHocPhan == null)
            {
                return false;
            }

            bool tonTaiMaLopHP = await db.LopHocPhan
                .Where(l => l.MaLopHP == req.MaLopHP && l.LopHocPhanID != req.LopHocPhanID)
                .AnyAsync();

            if (tonTaiMaLopHP)
            {
                return false;
            }

            bool tonTaiMonHoc = await db.MonHoc
                .Where(m => m.MonHocID == req.MonHocID)
                .AnyAsync();

            if (!tonTaiMonHoc)
            {
                return false;
            }

            lopHocPhan.MonHocID = req.MonHocID;
            lopHocPhan.MaLopHP = req.MaLopHP;
            lopHocPhan.HocKy = req.HocKy;
            lopHocPhan.NamHoc = req.NamHoc;
            lopHocPhan.SiSoToiDa = req.SiSoToiDa;
            lopHocPhan.NgayBatDau = req.NgayBatDau;
            lopHocPhan.NgayKetThuc = req.NgayKetThuc;

            await db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int LopHocPhanID)
        {
            bool tonTaiDangKy = await db.dangKy
                .Where(d => d.LopHocPhanID == LopHocPhanID)
                .AnyAsync();

            if (tonTaiDangKy)
            {
                return false;
            }

            var lopHocPhan = await db.LopHocPhan
                .Where(l => l.LopHocPhanID == LopHocPhanID)
                .FirstOrDefaultAsync();

            if (lopHocPhan == null)
            {
                return false;
            }

            db.LopHocPhan.Remove(lopHocPhan);

            int affected = await db.SaveChangesAsync();

            return affected > 0;
        }
    }
}
