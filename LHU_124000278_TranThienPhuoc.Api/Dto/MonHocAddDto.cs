using System.ComponentModel.DataAnnotations;

namespace LHU_124000278_TranThienPhuoc.Api.Dto
{
    public class MonHocAddDto
    {
        [Required(ErrorMessage = "Vui lòng nhập mã môn học")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Mã môn học phải từ 6 đến 20 ký tự")]
        public string? MaMon { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên môn học")]
        [MaxLength(100, ErrorMessage = "Tên môn học tối đa 100 ký tự")]
        public string? TenMon { get; set; }
        [Range(1, 10, ErrorMessage = "Số tín chỉ phải từ 1 đến 10")]
        public int SoTinChi { get; set; }
        [Range(0, 100, ErrorMessage = "Số tiết lý thuyết phải từ 0 đến 100")]
        public int SoTietLyThuyet { get; set; }
    }
}
