using API_QLDiemSV.DbContexts;
using API_QLDiemSV.Dto;
using API_QLDiemSV.Entities;
using API_QLDiemSV.IRepository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API_QLDiemSV.Repository
{
    public class SinhVienRepository : ISinhVienRepository
    {
        private readonly QLDiemSVContext _dbContext;
        private readonly SVContext _svContext;
        private readonly IMapper _mapper;

        public SinhVienRepository(QLDiemSVContext dbContext, SVContext svContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _svContext = svContext;
            _mapper = mapper;
        }
        public IEnumerable<SinhVienDto> GetSinhViens()
        {
            IEnumerable<SinhVien> listSinhVien = _dbContext.SinhViens.ToList();

            return _mapper.Map<IEnumerable<SinhVienDto>>(listSinhVien);
        }

        public void InsertSinhVien(SinhVienDto sinhVien)
        {
            var maxId = _dbContext.SinhViens.Max(e => (int?)e.MaSv) ?? 0;
            sinhVien.MaSv = maxId + 1;
            SinhVien inserted = _mapper.Map<SinhVien>(sinhVien);
            inserted.MatKhau = BCrypt.Net.BCrypt.HashPassword("123456");
            _dbContext.Add(inserted);
            _svContext.Add(_mapper.Map<SinhVien1>(inserted));
            Save();
        }

        public void UpdateSinhVien(SinhVienDto sinhVien)
        {
            SinhVien sv = _dbContext.SinhViens.Find(sinhVien.MaSv);
            _mapper.Map(sinhVien, sv);

            _dbContext.SinhViens.Update(sv);
            _svContext.SinhViens.Update(_mapper.Map<SinhVien1>(sv));
            Save();
        }

        public bool Login(UserDto user)
        {
            SinhVien sv = _dbContext.SinhViens.Find(user.userId);
            if (sv == null || !BCrypt.Net.BCrypt.Verify(user.MatKhau, sv.MatKhau)) return false;
            return true;
        }

        public void UpdateMatKhauSinhVien(UserDto user)
        {
            SinhVien sv = _dbContext.SinhViens.Find(user.userId);
            user.MatKhau = BCrypt.Net.BCrypt.HashPassword(user.MatKhau);
            _mapper.Map(user, sv);
            _dbContext.SinhViens.Update(sv);
            _svContext.SinhViens.Update(_mapper.Map<SinhVien1>(sv));
            Save();
        }

        public void DeleteSinhVien(int SinhVienId)
        {
            var sinhVien = _dbContext.SinhViens.Find(SinhVienId);
            _ = _dbContext.SinhViens.Remove(sinhVien);
            _ = _svContext.SinhViens.Remove(_mapper.Map<SinhVien1>(sinhVien));
            Save();
        }
        public SinhVienDto GetSinhVienById(int SinhVienId)
        {
            return _mapper.Map<SinhVienDto>(_dbContext.SinhViens.Find(SinhVienId));
        }

        public IEnumerable<SinhVienDto> GetSinhVienByMaLopSv(int lopSvId)
        {
            return _mapper.Map<IEnumerable<SinhVienDto>>(_dbContext.SinhViens.Where(e => e.MaLopSv == lopSvId));
        }
        public IEnumerable<SinhVienDto> GetSinhVienByMaLopTinChi(int lopTcId)
        {
            IEnumerable<SinhVien> sinhVienList = _dbContext.BangDiems
           .Where(bangDiem => bangDiem.MaLopTc == lopTcId)
           .Join(
               _dbContext.SinhViens,
               bangDiem => bangDiem.MaSv,
               sinhVien => sinhVien.MaSv,
               (bangDiem, sinhVien) => sinhVien
           );
            return _mapper.Map<IEnumerable<SinhVienDto>>(sinhVienList);
        }
        public void Save()
        {
            _dbContext.SaveChanges();
            _svContext.SaveChanges();
        }
    }
}
