using API_QLDiemSV.DbContexts;
using API_QLDiemSV.Dto;
using API_QLDiemSV.Entities;
using API_QLDiemSV.IRepository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API_QLDiemSV.Repository
{
    public class MonHocRepository : IMonHocRepository
    {
        private readonly QLDiemSVContext _dbContext;
        private readonly SVContext _svContext;
        private readonly IMapper _mapper;

        public MonHocRepository(QLDiemSVContext dbContext, SVContext svContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _svContext = svContext;
            _mapper = mapper;
        }
        public IEnumerable<MonHocDto> GetMonHocs()
        {
            IEnumerable<MonHoc> listMonHoc = _dbContext.MonHocs.ToList();

            return _mapper.Map<IEnumerable<MonHocDto>>(listMonHoc);
        }

        private bool valid(MonHocDto monHoc)
        {
            int total = monHoc.Tsthi + monHoc.TsthucHanh + monHoc.TschuyenCan + monHoc.TsbaiTap + monHoc.TskiemTra;
            if (total != 100) return false;
            return true;
        }

        public bool InsertMonHoc(MonHocDto monHoc)
        {
            if (!valid(monHoc)) return false;
            var maxId = _dbContext.MonHocs.Max(e => (int?)e.MaMh) ?? 0;
            monHoc.MaMh = maxId + 1;
            MonHoc inserted = _mapper.Map<MonHoc>(monHoc);
            _dbContext.Add(inserted);
            _svContext.Add(_mapper.Map<MonHoc1>(inserted));
            Save();
            return true;
        }

        public bool UpdateMonHoc( MonHocDto monHoc)
        {
            if (!valid(monHoc)) return false;

            MonHoc updated = _mapper.Map<MonHoc>(monHoc);
            _dbContext.Entry(updated).State = EntityState.Modified;
            _svContext.Entry(_mapper.Map<MonHoc1>(updated)).State = EntityState.Modified;
            Save();
            return true;
        }

        public void DeleteMonHoc(int MonHocId)
        {
            var monHoc = _dbContext.MonHocs.Find(MonHocId);
            _ = _dbContext.MonHocs.Remove(monHoc);
            _ = _svContext.MonHocs.Remove(_mapper.Map<MonHoc1>(monHoc));
            Save();
        }
        public MonHocDto GetMonHocById(int MonHocId)
        {
            return _mapper.Map<MonHocDto>(_dbContext.MonHocs.Find(MonHocId));
        }
        public void Save()
        {
            _dbContext.SaveChanges();
            _svContext.SaveChanges();
        }
    }
}
