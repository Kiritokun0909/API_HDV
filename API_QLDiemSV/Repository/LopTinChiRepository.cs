using API_QLDiemSV.DbContexts;
using API_QLDiemSV.Dto;
using API_QLDiemSV.Entities;
using API_QLDiemSV.IRepository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API_QLDiemSV.Repository
{
    public class LopTinChiRepository : ILopTinChiRepository
    {
        private readonly QLDiemSVContext _dbContext;
        private readonly SVContext _svContext;
        private readonly IMapper _mapper;

        public LopTinChiRepository(QLDiemSVContext dbContext, SVContext svContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _svContext = svContext;
            _mapper = mapper;
        }
        public IEnumerable<LopTinChiDto> GetLopTinChis()
        {
            IEnumerable<LopTinChi> listLopTinChi = _dbContext.LopTinChis.ToList();

            return _mapper.Map<IEnumerable<LopTinChiDto>>(listLopTinChi);
        }

        public void InsertLopTinChi(LopTinChiDto lopTinChi)
        {
            var maxId = _dbContext.LopTinChis.Max(e => (int?)e.MaLopTc) ?? 0;
            lopTinChi.MaLopTc = maxId + 1;
            LopTinChi inserted = _mapper.Map<LopTinChi>(lopTinChi);
            _dbContext.Add(inserted);
            _svContext.Add(_mapper.Map<LopTinChi1>(inserted));
            Save();
        }

        public void UpdateLopTinChi(LopTinChiDto lopTinChi)
        {
            LopTinChi updated = _mapper.Map<LopTinChi>(lopTinChi);
            _dbContext.Entry(updated).State = EntityState.Modified;
            _svContext.Entry(_mapper.Map<LopTinChi1>(updated)).State = EntityState.Modified;
            Save();
        }

        public void DeleteLopTinChi(int LopTinChiId)
        {
            var lopTinChi = _dbContext.LopTinChis.Find(LopTinChiId);
            _ = _dbContext.LopTinChis.Remove(lopTinChi);
            _ = _svContext.LopTinChis.Remove(_mapper.Map<LopTinChi1>(lopTinChi));
            Save();
        }
        public LopTinChiDto GetLopTinChiById(int LopTinChiId)
        {
            return _mapper.Map<LopTinChiDto>(_dbContext.LopTinChis.Find(LopTinChiId));
        }

        public IEnumerable<LopTinChiDto> GetLopTcByMaMonHoc(int monHocId)
        {
            return _mapper.Map<IEnumerable<LopTinChiDto>>(_dbContext.LopTinChis.Where(e => e.MaMh == monHocId));
        }

        public IEnumerable<LopTinChiDto> GetLopTcByNamHoc(int namHoc)
        {
            return _mapper.Map<IEnumerable<LopTinChiDto>>(_dbContext.LopTinChis.Where(e => e.Nam == namHoc));
        }
        public void Save()
        {
            _dbContext.SaveChanges();
            _svContext.SaveChanges();
        }
    }
}
