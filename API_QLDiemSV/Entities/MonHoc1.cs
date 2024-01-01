namespace API_QLDiemSV.Entities
{
    public class MonHoc1
    {
        public int MaMh { get; set; }

        public string TenMh { get; set; } = null!;

        public int TsChuyenCan { get; set; }

        public int TsBaiTap { get; set; }

        public int TsKiemTra { get; set; }

        public int TsThucHanh { get; set; }

        public int TsThi { get; set; }

        public int SoTc { get; set; }

        public virtual ICollection<LopTinChi1> LopTinChis { get; set; } = new List<LopTinChi1>();
    }
}
