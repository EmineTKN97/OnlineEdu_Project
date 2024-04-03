using AutoMapper;
using OnlineEdu.DTO.DTOs.AboutDTO;
using OnlineEdu.DTO.DTOs.BannerDTO;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Mapping
{
    public class BannerMapping:Profile
    {
        public BannerMapping()
        {
            CreateMap<CreateBannerDTO, Banner>().ReverseMap();
            CreateMap<UpdateBannerDTO, About>().ReverseMap();
        }
    }
}
