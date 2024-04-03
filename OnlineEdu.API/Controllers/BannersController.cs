using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.AboutDTO;
using OnlineEdu.DTO.DTOs.BannerDTO;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController(IGenericService<Banner> _bannerService, IMapper _mapper): ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var result = _bannerService.TGetList();
            return Ok(result);

        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _bannerService.TGetById(id);
            return Ok(result);

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            _bannerService.TDelete(id);
            return Ok("Banner Alanı Silindi");

        }
        [HttpPost]
        public IActionResult Create(CreateBannerDTO bannerDTO)
        {
            var newValue = _mapper.Map<Banner>(bannerDTO);
            _bannerService.TCreate(newValue);
            return Ok("Banner alanı oluşturuldu");

        }
        [HttpPut]
        public IActionResult Update(UpdateBannerDTO bannerDTO)
        {
            var newValue = _mapper.Map<Banner>(bannerDTO);
            _bannerService.TUpdate(newValue);
            return Ok("Hakkımızda alanı güncellendi");

        }
    }
}
