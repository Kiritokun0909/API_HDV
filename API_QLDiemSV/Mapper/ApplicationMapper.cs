using API_QLDiemSV.Dto;
using API_QLDiemSV.Entities;
using AutoMapper;

namespace API_QLDiemSV.Mapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Quyen, QuyenDto>().ReverseMap();
            CreateMap<Khoa, KhoaDto>().ReverseMap();
            CreateMap<GiangVien, GiangVienDto>().ReverseMap();
            CreateMap<LopSv, LopSvDto>().ReverseMap();
            CreateMap<MonHoc, MonHocDto>().ReverseMap();
            CreateMap<MonHoc, MonHoc1>().ReverseMap();
            CreateMap<LopTinChi, LopTinChiDto>().ReverseMap();
            CreateMap<LopTinChi, LopTinChi1>().ReverseMap();
            CreateMap<SinhVien, SinhVienDto>().ReverseMap();
            CreateMap<SinhVien, SinhVien1>().ReverseMap();
            CreateMap<BangDiem, BangDiemDto>().ReverseMap();
            CreateMap<BangDiem, BangDiem1>().ReverseMap();

            CreateMap<GiangVien, UserDto>()
            .ForMember(dest => dest.userId, opt => opt.MapFrom(src => src.MaGv))
            .ReverseMap();

            CreateMap<SinhVien, UserDto>()
                .ForMember(dest => dest.userId, opt => opt.MapFrom(src => src.MaSv))
                .ReverseMap();
        }
    }
}
