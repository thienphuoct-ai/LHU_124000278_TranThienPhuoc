using LHU_124000278_TranThienPhuoc.Api.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LHU_124000278_TranThienPhuoc.Api.Database.Seed
{
    public class LopHocPhanSeed : IEntityTypeConfiguration<LopHocPhanEntity>
    {
        public void Configure(EntityTypeBuilder<LopHocPhanEntity> builder)
        {
            builder.HasData(Data);
        }

        public static readonly LopHocPhanEntity[] Data = new[]
        {
            new LopHocPhanEntity
            {
                LopHocPhanID = 1,
                MonHocID = 1,
                MaLopHP = "24DTH01_IT101",
                HocKy = 1,
                NamHoc = 2024,
                SiSoToiDa = 45
            },
            new LopHocPhanEntity
            {
                LopHocPhanID = 2,
                MonHocID = 1,
                MaLopHP = "24DTH02_IT101",
                HocKy = 1,
                NamHoc = 2024,
                SiSoToiDa = 45
            },
            new LopHocPhanEntity
            {
                LopHocPhanID = 3,
                MonHocID = 2,
                MaLopHP = "24DTH01_IT102",
                HocKy = 2,
                NamHoc = 2024,
                SiSoToiDa = 40
            },
            new LopHocPhanEntity
            {
                LopHocPhanID = 4,
                MonHocID = 2,
                MaLopHP = "24DTH02_IT102",
                HocKy = 2,
                NamHoc = 2024,
                SiSoToiDa = 40
            },
            new LopHocPhanEntity
            {
                LopHocPhanID = 5,
                MonHocID = 3,
                MaLopHP = "24DTH01_IT103",
                HocKy = 1,
                NamHoc = 2025,
                SiSoToiDa = 35
            },
            new LopHocPhanEntity
            {
                LopHocPhanID = 6,
                MonHocID = 3,
                MaLopHP = "24DTH02_IT103",
                HocKy = 1,
                NamHoc = 2025,
                SiSoToiDa = 35
            },
            new LopHocPhanEntity
            {
                LopHocPhanID = 7,
                MonHocID = 4,
                MaLopHP = "24DTH01_IT104",
                HocKy = 1,
                NamHoc = 2025,
                SiSoToiDa = 50
            },
            new LopHocPhanEntity
            {
                LopHocPhanID = 8,
                MonHocID = 5,
                MaLopHP = "24DTH01_IT105",
                HocKy = 2,
                NamHoc = 2025,
                SiSoToiDa = 40
            },
            new LopHocPhanEntity
            {
                LopHocPhanID = 9,
                MonHocID = 6,
                MaLopHP = "24DTH01_IT106",
                HocKy = 1,
                NamHoc = 2025,
                SiSoToiDa = 45
            },
            new LopHocPhanEntity
            {
                LopHocPhanID = 10,
                MonHocID = 7,
                MaLopHP = "24DTH01_IT107",
                HocKy = 1,
                NamHoc = 2025,
                SiSoToiDa = 50
            },
            new LopHocPhanEntity
            {
                LopHocPhanID = 11,
                MonHocID = 7,
                MaLopHP = "24DTH02_IT107",
                HocKy = 2,
                NamHoc = 2025,
                SiSoToiDa = 50
            },
            new LopHocPhanEntity
            {
                LopHocPhanID = 12,
                MonHocID = 8,
                MaLopHP = "24DTH01_IT108",
                HocKy = 2,
                NamHoc = 2025,
                SiSoToiDa = 40
            },
            new LopHocPhanEntity
            {
                LopHocPhanID = 13,
                MonHocID = 8,
                MaLopHP = "24DTH02_IT108",
                HocKy = 2,
                NamHoc = 2025,
                SiSoToiDa = 40
            },
            new LopHocPhanEntity
            {
                LopHocPhanID = 14,
                MonHocID = 9,
                MaLopHP = "24DTH01_IT109",
                HocKy = 1,
                NamHoc = 2026,
                SiSoToiDa = 45
            },
            new LopHocPhanEntity
            {
                LopHocPhanID = 15,
                MonHocID = 10,
                MaLopHP = "24DTH01_IT110",
                HocKy = 2,
                NamHoc = 2026,
                SiSoToiDa = 40
            }
        };
    }
}
