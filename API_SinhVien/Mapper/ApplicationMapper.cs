using API_SinhVien.Entities;
using API_SinhVien.Dto;
using AutoMapper;

namespace API_SinhVien.Mapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<SinhVien, SinhVienDto>().ReverseMap();
            CreateMap<BangDiem, BangDiemDto>().ReverseMap();

            CreateMap<SinhVien, TaiKhoanDto>()
                .ForMember(dest => dest.MaSinhVien, opt => opt.MapFrom(src => src.MaSv))
                .ReverseMap();
        }
    }
}
