using AutoMapper;
using OnlineEdu.DTO.DTOs.AboutDTO;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Mapping
{
    public class AboutMapping:Profile
    {
        public AboutMapping()
        {
            CreateMap<CreateAboutDTO,About>().ReverseMap();
            CreateMap<UpdateAboutDTO, About>().ReverseMap();

        }
    }
}
