using API_QLDiemSV.Dto;

namespace API_QLDiemSV.IRepository
{
    public interface IMonHocRepository
    {
        public IEnumerable<MonHocDto> GetMonHocs();
        public bool InsertMonHoc(MonHocDto monHoc);
        public bool UpdateMonHoc(MonHocDto monHoc);
        public void DeleteMonHoc(int id);
        public MonHocDto GetMonHocById(int id);
        public void Save();
    }
}
