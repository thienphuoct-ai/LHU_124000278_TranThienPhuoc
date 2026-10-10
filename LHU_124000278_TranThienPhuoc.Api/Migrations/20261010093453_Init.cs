using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LHU_124000278_TranThienPhuoc.Api.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MonHoc",
                columns: table => new
                {
                    MonHocID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaMon = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TenMon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoTinChi = table.Column<int>(type: "int", nullable: false),
                    SoTietLyThuyet = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonHoc", x => x.MonHocID);
                });

            migrationBuilder.CreateTable(
                name: "SinhVien",
                columns: table => new
                {
                    SinhVienID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSV = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LopSinhHoat = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinhVien", x => x.SinhVienID);
                });

            migrationBuilder.CreateTable(
                name: "LopHocPhan",
                columns: table => new
                {
                    LopHocPhanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MonHocID = table.Column<int>(type: "int", nullable: false),
                    MaLopHP = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    HocKy = table.Column<int>(type: "int", nullable: false),
                    NamHoc = table.Column<int>(type: "int", nullable: false),
                    SiSoToiDa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LopHocPhan", x => x.LopHocPhanID);
                    table.ForeignKey(
                        name: "FK_LopHocPhan_MonHoc_MonHocID",
                        column: x => x.MonHocID,
                        principalTable: "MonHoc",
                        principalColumn: "MonHocID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DangKy",
                columns: table => new
                {
                    DangKyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SinhVienId = table.Column<int>(type: "int", nullable: false),
                    LopHocPhanId = table.Column<int>(type: "int", nullable: false),
                    NgayDangKy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DangKy", x => x.DangKyId);
                    table.ForeignKey(
                        name: "FK_DangKy_LopHocPhan_LopHocPhanId",
                        column: x => x.LopHocPhanId,
                        principalTable: "LopHocPhan",
                        principalColumn: "LopHocPhanID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DangKy_SinhVien_SinhVienId",
                        column: x => x.SinhVienId,
                        principalTable: "SinhVien",
                        principalColumn: "SinhVienID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "MonHoc",
                columns: new[] { "MonHocID", "MaMon", "SoTietLyThuyet", "SoTinChi", "TenMon" },
                values: new object[,]
                {
                    { 1, "IT101", 30, 3, "Nhập môn lập trình" },
                    { 2, "IT102", 30, 3, "Kỹ thuật lập trình" }
                });

            migrationBuilder.InsertData(
                table: "SinhVien",
                columns: new[] { "SinhVienID", "Email", "HoTen", "LopSinhHoat", "MaSV", "NgaySinh" },
                values: new object[,]
                {
                    { 1, "nguyenvana@gmail.com", "Nguyễn Văn A", "22DTH1", "SV001", new DateTime(2004, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "tranthib@gmail.com", "Trần Thị B", "22DTH2", "SV002", new DateTime(2004, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_DangKy_LopHocPhanId",
                table: "DangKy",
                column: "LopHocPhanId");

            migrationBuilder.CreateIndex(
                name: "IX_DangKy_SinhVienId",
                table: "DangKy",
                column: "SinhVienId");

            migrationBuilder.CreateIndex(
                name: "IX_LopHocPhan_MonHocID",
                table: "LopHocPhan",
                column: "MonHocID");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_MaSV",
                table: "SinhVien",
                column: "MaSV",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DangKy");

            migrationBuilder.DropTable(
                name: "LopHocPhan");

            migrationBuilder.DropTable(
                name: "SinhVien");

            migrationBuilder.DropTable(
                name: "MonHoc");
        }
    }
}
