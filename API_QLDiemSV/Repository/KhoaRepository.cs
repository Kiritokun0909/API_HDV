using API_QLDiemSV.DbContexts;
using API_QLDiemSV.Dto;
using API_QLDiemSV.Entities;
using API_QLDiemSV.IRepository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace API_QLDiemSV.Repository
{
    public class KhoaRepository : IKhoaRepository
    {
        private readonly QLDiemSVContext _dbContext;
        private readonly IMapper _mapper;

        public KhoaRepository(QLDiemSVContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public IEnumerable<KhoaDto> GetKhoas()
        {
            IEnumerable<Khoa> listKhoa = _dbContext.Khoas.ToList();

            return _mapper.Map<IEnumerable<KhoaDto>>(listKhoa);
        }

        public void InsertKhoa(KhoaDto khoa)
        {
            var maxId = _dbContext.Khoas.Max(e => (int?)e.MaKhoa) ?? 0;
            khoa.MaKhoa = maxId + 1;
            _dbContext.Add(_mapper.Map<Khoa>(khoa));
            Save();
        }

        public void UpdateKhoa(KhoaDto khoa)
        {
            _dbContext.Entry(_mapper.Map<Khoa>(khoa)).State = EntityState.Modified;
            Save();
        }

        public void DeleteKhoa(int khoaId)
        {
            var khoa = _dbContext.Khoas.Find(khoaId);
            _ = _dbContext.Khoas.Remove(khoa);
            Save();
        }
        public KhoaDto GetKhoaById(int khoaId)
        {
            return _mapper.Map<KhoaDto>(_dbContext.Khoas.Find(khoaId));
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
