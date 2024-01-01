using API_SinhVien.DbContexts;
using API_SinhVien.Dto;
using API_SinhVien.IRepository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API_SinhVien.Repository
{
    public class BangDiemRepo : IBangDiemRepo
    {
        private readonly SVContext _dbContext;
        private readonly IMapper _mapper;

        public BangDiemRepo(SVContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public IEnumerable<BangDiemDto> GetBangDiemByMaSinhVien(int id)
        {   
            var result = _dbContext.BangDiems
                .Where(e => e.MaSv == id)
                .Include(e => e.MaLopTcNavigation)
                .ThenInclude(s => s.MaMhNavigation)
                .Include(e => e.MaSvNavigation)
                .Select(e => new BangDiemDto
                {
                    MaMonHoc = e.MaLopTcNavigation.MaMh,
                    TenMonHoc = $"{e.MaLopTcNavigation.MaMhNavigation.TenMh}",
                    SoTinChi = e.MaLopTcNavigation.MaMhNavigation.SoTc,
                    ChuyenCan = e.ChuyenCan,
                    BaiTap = e.BaiTap,
                    ThucHanh = e.ThucHanh,
                    Thi = e.Thi,
                    TongKet = e.TongKet,
                    Nam = e.MaLopTcNavigation.Nam,
                    Ky = e.MaLopTcNavigation.Ky
                })
                .ToList();

            return result;
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
