using API_QLDiemSV.DbContexts;
using API_QLDiemSV.Dto;
using API_QLDiemSV.Entities;
using API_QLDiemSV.IRepository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API_QLDiemSV.Repository
{
    public class LopSvRepository : ILopSvRepository
    {
        private readonly QLDiemSVContext _dbContext;
        private readonly IMapper _mapper;

        public LopSvRepository(QLDiemSVContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public IEnumerable<LopSvDto> GetLopSvs()
        {
            IEnumerable<LopSv> listLopSv = _dbContext.LopSvs.ToList();

            return _mapper.Map<IEnumerable<LopSvDto>>(listLopSv);
        }

        public void InsertLopSv(LopSvDto lopSv)
        {
            var maxId = _dbContext.LopSvs.Max(e => (int?)e.MaLopSv) ?? 0;
            lopSv.MaLopSv = maxId + 1;
            _dbContext.Add(_mapper.Map<LopSv>(lopSv));
            Save();
        }

        public void UpdateLopSv(LopSvDto lopSv)
        {
            _dbContext.Entry(_mapper.Map<LopSv>(lopSv)).State = EntityState.Modified;
            Save();
        }

        public void DeleteLopSv(int LopSvId)
        {
            var lopSv = _dbContext.LopSvs.Find(LopSvId);
            _ = _dbContext.LopSvs.Remove(lopSv);
            Save();
        }
        public LopSvDto GetLopSvById(int LopSvId)
        {
            return _mapper.Map<LopSvDto>(_dbContext.LopSvs.Find(LopSvId));
        }

        public IEnumerable<LopSvDto> GetLopSvByMaKhoa(int khoaId)
        {
            return _mapper.Map<IEnumerable<LopSvDto>>(_dbContext.LopSvs.Where(e => e.MaKhoa == khoaId));
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
