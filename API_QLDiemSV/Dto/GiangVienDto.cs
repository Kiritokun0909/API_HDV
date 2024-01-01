namespace API_QLDiemSV.Dto
{
    public class GiangVienDto
    {
        public int MaGv { get; set; }

        public string Ho { get; set; } = null!;

        public string Ten { get; set; } = null!;

        public string DiaChi { get; set; } = null!;

        public string Sdt { get; set; } = null!;

        public int MaKhoa { get; set; }

        public int MaQuyen { get; set; }
    }
}
