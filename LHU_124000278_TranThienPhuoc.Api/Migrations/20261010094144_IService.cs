using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LHU_124000278_TranThienPhuoc.Api.Migrations
{
    public partial class IService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LopHocPhan",
                columns: new[] { "LopHocPhanID", "HocKy", "MaLopHP", "MonHocID", "NamHoc", "SiSoToiDa" },
                values: new object[] { 1, 1, "LHP001", 1, 2024, 40 });

            migrationBuilder.InsertData(
                table: "LopHocPhan",
                columns: new[] { "LopHocPhanID", "HocKy", "MaLopHP", "MonHocID", "NamHoc", "SiSoToiDa" },
                values: new object[] { 2, 1, "LHP002", 1, 2024, 45 });

            migrationBuilder.InsertData(
                table: "LopHocPhan",
                columns: new[] { "LopHocPhanID", "HocKy", "MaLopHP", "MonHocID", "NamHoc", "SiSoToiDa" },
                values: new object[] { 3, 2, "LHP003", 2, 2024, 40 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LopHocPhan",
                keyColumn: "LopHocPhanID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LopHocPhan",
                keyColumn: "LopHocPhanID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LopHocPhan",
                keyColumn: "LopHocPhanID",
                keyValue: 3);
        }
    }
}
