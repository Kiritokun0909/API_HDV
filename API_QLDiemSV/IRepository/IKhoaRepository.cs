using API_QLDiemSV.Dto;
using Microsoft.EntityFrameworkCore;

namespace API_QLDiemSV.IRepository
{
    public interface IKhoaRepository
    {
        public IEnumerable<KhoaDto> GetKhoas();
        public void InsertKhoa(KhoaDto khoa);
        public void UpdateKhoa(KhoaDto khoa);
        public void DeleteKhoa(int khoaId);
        public KhoaDto GetKhoaById(int khoaId);
        
        
        public void Save();
    }
}
