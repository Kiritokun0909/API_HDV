namespace API_QLDiemSV.Dto
{
    public class SinhVienDto
    {
        public int MaSv { get; set; }

        public string Ho { get; set; } = null!;

        public string Ten { get; set; } = null!;

        public string DiaChi { get; set; } = null!;

        public string Sdt { get; set; } = null!;

        public int MaLopSv { get; set; }
    }
}
