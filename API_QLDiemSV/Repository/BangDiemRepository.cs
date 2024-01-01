using API_QLDiemSV.DbContexts;
using API_QLDiemSV.Dto;
using API_QLDiemSV.Entities;
using API_QLDiemSV.IRepository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API_QLDiemSV.Repository
{
    public class BangDiemRepository : IBangDiemRepository
    {
        private readonly QLDiemSVContext _dbContext;
        private readonly SVContext _svContext;
        private readonly IMapper _mapper;

        public BangDiemRepository(QLDiemSVContext dbContext, SVContext svContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _svContext = svContext;
            _mapper = mapper;
        }
        public IEnumerable<BangDiemDto> GetBangDiems()
        {
            IEnumerable<BangDiem> listBangDiem = _dbContext.BangDiems.ToList();

            return _mapper.Map<IEnumerable<BangDiemDto>>(listBangDiem);
        }

        public void InsertBangDiem(BangDiemDto bangDiem)
        {
            var maxId = _dbContext.BangDiems.Max(e => (int?)e.MaBangDiem) ?? 0;
            bangDiem.MaBangDiem = maxId + 1;

            BangDiem inserted = _mapper.Map<BangDiem>(bangDiem);
            _dbContext.Add(inserted);
            _svContext.Add(_mapper.Map<BangDiem1>(inserted));
            Save();
        }

        public void UpdateBangDiem(BangDiemDto bangDiem)
        {
            LopTinChi loptc = _dbContext.LopTinChis.Find(bangDiem.MaLopTc);
            if (loptc == null) return;
            MonHoc monHoc = _dbContext.MonHocs.Find(loptc.MaMh);
            bangDiem.TongKet = Math.Round(
                ((bangDiem.ChuyenCan * monHoc.TschuyenCan
                + bangDiem.BaiTap * monHoc.TsbaiTap
                + bangDiem.KiemTra * monHoc.TskiemTra
                + bangDiem.ThucHanh * monHoc.TsthucHanh
                + bangDiem.Thi * monHoc.Tsthi) / 100.0), 1);

            BangDiem updated = _mapper.Map<BangDiem>(bangDiem);
            _dbContext.Entry(updated).State = EntityState.Modified;
            _svContext.Entry(_mapper.Map<BangDiem1>(updated)).State = EntityState.Modified;
            Save();
        }

        public void DeleteBangDiem(int id)
        {
            var bangDiem = _dbContext.BangDiems.Find(id);
            _ = _dbContext.BangDiems.Remove(bangDiem);
            _ = _svContext.BangDiems.Remove(_mapper.Map<BangDiem1>(bangDiem));
            Save();
        }

        public void DeleteBangDiem(int maLopTc, int maSv)
        {
            var bangDiem = _dbContext.BangDiems.Where(b => b.MaLopTc == maLopTc && b.MaSv == maSv).FirstOrDefault();
            DeleteBangDiem(bangDiem.MaBangDiem);
        }
        public BangDiemDto GetBangDiemById(int id)
        {
            return _mapper.Map<BangDiemDto>(_dbContext.BangDiems.Find(id));
        }

        public IEnumerable<BangDiemDto> GetBangDiemBySinhVienId(int id)
        {
            return _mapper.Map<IEnumerable<BangDiemDto>>(_dbContext.BangDiems.Where(e => e.MaSv == id));
        }

        public IEnumerable<BangDiemInfoDto> GetBangDiemInfoByMaLopTc(int id)
        {
            var result = _dbContext.BangDiems
            .Where(b => b.MaLopTc == id)
            .Include(b => b.MaSvNavigation)
            .ThenInclude(s => s.MaLopSvNavigation)
            .Include(b => b.MaLopTcNavigation)
            .Select(b => new BangDiemInfoDto
            {
                MaBangDiem = b.MaBangDiem,
                MaLopTc = b.MaLopTc,
                MaSv = b.MaSvNavigation.MaSv,
                TenSv = $"{b.MaSvNavigation.Ho} {b.MaSvNavigation.Ten}",
                TenLopSv = b.MaSvNavigation.MaLopSvNavigation.TenLopSv,
                ChuyenCan = b.ChuyenCan,
                BaiTap = b.BaiTap,
                ThucHanh = b.ThucHanh,
                KiemTra = b.KiemTra,
                Thi = b.Thi,
                TongKet = b.TongKet
            })
            .ToList();

            return result;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
            _svContext.SaveChanges();
        }
    }
}
