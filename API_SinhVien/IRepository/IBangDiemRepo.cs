using API_SinhVien.Dto;

namespace API_SinhVien.IRepository
{
    public interface IBangDiemRepo
    {
        public IEnumerable<BangDiemDto> GetBangDiemByMaSinhVien(int id);
        public void Save();
    }
}
