using API_QLDiemSV.Dto;

namespace API_QLDiemSV.IRepository
{
    public interface IGiangVienRepository
    {
        public IEnumerable<GiangVienDto> GetGiangViens();
        public void InsertGiangVien(GiangVienDto giangVien);
        public void UpdateGiangVien(GiangVienDto giangVien);
        public bool Login(UserDto user);
        public void UpdateMatKhauGiangVien(UserDto user);
        public void DeleteGiangVien(int id);
        public GiangVienDto GetGiangVienById(int id);
        public IEnumerable<GiangVienDto> GetGiangvienByMaKhoa(int khoaId);
        public void Save();
    }
}
