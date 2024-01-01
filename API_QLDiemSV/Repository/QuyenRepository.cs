using API_QLDiemSV.DbContexts;
using API_QLDiemSV.Dto;
using API_QLDiemSV.Entities;
using API_QLDiemSV.IRepository;
using AutoMapper;

namespace API_QLDiemSV.Repository
{
    public class QuyenRepository : IQuyenRepository
    {
        private readonly QLDiemSVContext _dbContext;
        private readonly IMapper _mapper;

        public QuyenRepository(QLDiemSVContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<QuyenDto> GetQuyens()
        {
            IEnumerable<Quyen> listQuyen = _dbContext.Quyens.ToList();

            return _mapper.Map<IEnumerable<QuyenDto>>(listQuyen);
        }

        public QuyenDto GetQuyenById(int quyenId)
        {
            return _mapper.Map<QuyenDto>(_dbContext.Quyens.Find(quyenId));
        }
    }
}
