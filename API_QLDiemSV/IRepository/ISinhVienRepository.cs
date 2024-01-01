using API_QLDiemSV.Dto;

namespace API_QLDiemSV.IRepository
{
    public interface ISinhVienRepository
    {
        public IEnumerable<SinhVienDto> GetSinhViens();
        public void InsertSinhVien(SinhVienDto sinhVien);
        public void UpdateSinhVien(SinhVienDto sinhVien);
        public bool Login(UserDto user);
        public void UpdateMatKhauSinhVien(UserDto user);
        public void DeleteSinhVien(int id);
        public SinhVienDto GetSinhVienById(int id);
        public IEnumerable<SinhVienDto> GetSinhVienByMaLopSv(int lopSvId);
        public IEnumerable<SinhVienDto> GetSinhVienByMaLopTinChi(int lopTcId);
        public void Save();
    }
}
