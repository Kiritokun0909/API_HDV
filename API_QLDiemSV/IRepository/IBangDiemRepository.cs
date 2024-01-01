using API_QLDiemSV.Dto;

namespace API_QLDiemSV.IRepository
{
    public interface IBangDiemRepository
    {
        public IEnumerable<BangDiemDto> GetBangDiems();
        public void InsertBangDiem(BangDiemDto bangDiem);
        public void UpdateBangDiem(BangDiemDto bangDiem);
        public void DeleteBangDiem(int id);
        public void DeleteBangDiem(int maLopTc, int maSv);
        public BangDiemDto GetBangDiemById(int id);
        public IEnumerable<BangDiemDto> GetBangDiemBySinhVienId(int id);
        public IEnumerable<BangDiemInfoDto> GetBangDiemInfoByMaLopTc(int id);
        public void Save();
    }
}

