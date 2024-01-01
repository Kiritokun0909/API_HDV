using API_SinhVien.DbContexts;
using API_SinhVien.Dto;
using API_SinhVien.Entities;
using API_SinhVien.IRepository;
using AutoMapper;

namespace API_SinhVien.Repository
{
    public class SinhVienRepo : ISinhVienRepo
    {
        private readonly SVContext _dbContext;
        private readonly IMapper _mapper;

        public SinhVienRepo(SVContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public SinhVienDto GetById(int id)
        {
            SinhVien sv = _dbContext.SinhViens.Find(id);
            if (sv == null) return null;

            SinhVienDto svDto = new SinhVienDto();
            _mapper.Map(sv, svDto);
            return svDto;
        }

        public bool Login(TaiKhoanDto tk)
        {
            SinhVien sv = _dbContext.SinhViens.Find(tk.MaSinhVien);
            if (sv == null || !BCrypt.Net.BCrypt.Verify(tk.MatKhau, sv.MatKhau)) return false;
            return true;
        }

        public bool UpdateMatKhau(TaiKhoanDto tk)
        {
            SinhVien sv = _dbContext.SinhViens.Find(tk.MaSinhVien);
            if(sv != null)
            {
                tk.MatKhau = BCrypt.Net.BCrypt.HashPassword(tk.MatKhau);
                _mapper.Map(tk, sv);
                _dbContext.SinhViens.Update(sv);
                Save();
                return true;
            }
            return false;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
