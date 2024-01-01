namespace API_QLDiemSV.Entities
{
    public class SinhVien1
    {
        public int MaSv { get; set; }

        public string Ho { get; set; } = null!;

        public string Ten { get; set; } = null!;

        public string DiaChi { get; set; } = null!;

        public string Sdt { get; set; } = null!;

        public string MatKhau { get; set; } = null!;

        public virtual ICollection<BangDiem1> BangDiems { get; set; } = new List<BangDiem1>();
    }
}
