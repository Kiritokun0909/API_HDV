namespace API_QLDiemSV.Entities
{
    public class LopTinChi1
    {
        public int MaLopTc { get; set; }

        public int MaMh { get; set; }

        public int Nam { get; set; }

        public int Ky { get; set; }

        public virtual ICollection<BangDiem1> BangDiems { get; set; } = new List<BangDiem1>();

        public virtual MonHoc1 MaMhNavigation { get; set; } = null!;
    }
}
