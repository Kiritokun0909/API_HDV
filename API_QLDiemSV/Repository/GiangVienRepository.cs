using API_QLDiemSV.DbContexts;
using API_QLDiemSV.Dto;
using API_QLDiemSV.Entities;
using API_QLDiemSV.IRepository;
using AutoMapper;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;

namespace API_QLDiemSV.Repository
{
    public class GiangVienRepository : IGiangVienRepository
    {
        private readonly QLDiemSVContext _dbContext;
        private readonly IMapper _mapper;

        public GiangVienRepository(QLDiemSVContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public IEnumerable<GiangVienDto> GetGiangViens()
        {
            IEnumerable<GiangVien> listGiangVien = _dbContext.GiangViens.ToList();

            return _mapper.Map<IEnumerable<GiangVienDto>>(listGiangVien);
        }

        public void InsertGiangVien(GiangVienDto giangVien)
        {
            var maxId = _dbContext.GiangViens.Max(e => (int?)e.MaGv) ?? 0;
            giangVien.MaGv = maxId + 1;
            GiangVien insertedGV = _mapper.Map<GiangVien>(giangVien);
            insertedGV.MatKhau = BCrypt.Net.BCrypt.HashPassword("123456");
            _dbContext.Add(insertedGV);
            Save();
        }

        public void UpdateGiangVien(GiangVienDto giangVien)
        {
            GiangVien gv = _dbContext.GiangViens.Find(giangVien.MaGv);
            _mapper.Map(giangVien, gv);
            _dbContext.GiangViens.Update(gv);
            Save();
        }

        public bool Login(UserDto user) 
        {
            GiangVien gv = _dbContext.GiangViens.Find(user.userId);
            if(gv == null || !BCrypt.Net.BCrypt.Verify(user.MatKhau, gv.MatKhau)) return false;
            return true;
        }

        public void UpdateMatKhauGiangVien(UserDto user)
        {
            GiangVien gv = _dbContext.GiangViens.Find(user.userId);
            user.MatKhau = BCrypt.Net.BCrypt.HashPassword(user.MatKhau);
            _mapper.Map(user, gv);
            _dbContext.GiangViens.Update(gv);
            Save();
        }

        public void DeleteGiangVien(int id)
        {
            var giangVien = _dbContext.GiangViens.Find(id);
            _ = _dbContext.GiangViens.Remove(giangVien);
            Save();
        }
        public GiangVienDto GetGiangVienById(int id)
        {
            return _mapper.Map<GiangVienDto>(_dbContext.GiangViens.Find(id));
        }

        public IEnumerable<GiangVienDto> GetGiangvienByMaKhoa(int khoaId)
        {
            return _mapper.Map<IEnumerable<GiangVienDto>>(_dbContext.GiangViens.Where(e => e.MaKhoa == khoaId));
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
