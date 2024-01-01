using API_QLDiemSV.Dto;

namespace API_QLDiemSV.IRepository
{
    public interface ILopSvRepository
    {
        public IEnumerable<LopSvDto> GetLopSvs();
        public void InsertLopSv(LopSvDto lopSv);
        public void UpdateLopSv(LopSvDto lopSv);
        public void DeleteLopSv(int id);
        public LopSvDto GetLopSvById(int id);
        public IEnumerable<LopSvDto> GetLopSvByMaKhoa(int khoaId);
        public void Save();
    }
}
