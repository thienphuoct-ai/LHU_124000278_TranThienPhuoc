using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LHU_124000278_TranThienPhuoc.Api.Database.Entities
{
    [Table("MonHoc")]
    public class MonHocEntity
    {
        [Key]
        public int MonHocID { get; set; }
        [Required]
        [MaxLength(20)]
        public string? MaMon { get; set; }
        public string? TenMon { get; set; }
        public int SoTinChi { get; set; }
        public int SoTietLyThuyet { get; set; }
        public ICollection<LopHocPhanEntity> LopHocPhans { get; set; } = new List<LopHocPhanEntity>();
    }
}
