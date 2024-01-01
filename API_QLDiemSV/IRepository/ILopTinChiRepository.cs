using API_QLDiemSV.Dto;

namespace API_QLDiemSV.IRepository
{
    public interface ILopTinChiRepository
    {
        public IEnumerable<LopTinChiDto> GetLopTinChis();
        public void InsertLopTinChi(LopTinChiDto lopTinChi);
        public void UpdateLopTinChi(LopTinChiDto lopTinChi);
        public void DeleteLopTinChi(int id);
        public LopTinChiDto GetLopTinChiById(int id);
        public IEnumerable<LopTinChiDto> GetLopTcByMaMonHoc(int monHocId);
        public IEnumerable<LopTinChiDto> GetLopTcByNamHoc(int namHoc);
        public void Save();
    }
}
