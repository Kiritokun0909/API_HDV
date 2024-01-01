using API_SinhVien.Dto;

namespace API_SinhVien.IRepository
{
    public interface ISinhVienRepo
    {
        public SinhVienDto GetById(int id);
        public bool Login(TaiKhoanDto user);
        public bool UpdateMatKhau(TaiKhoanDto user);
        public void Save();
    }
}
