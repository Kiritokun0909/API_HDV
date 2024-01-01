using API_QLDiemSV.Dto;
using API_QLDiemSV.Entities;

namespace API_QLDiemSV.IRepository
{
    public interface IQuyenRepository
    {
        public IEnumerable<QuyenDto> GetQuyens();
        public QuyenDto GetQuyenById(int quyenId);
    }
}
