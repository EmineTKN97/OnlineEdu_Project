using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.AboutDTO;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController(IGenericService<About> _aboutService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var result = _aboutService.TGetList();
            return Ok(result);

        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _aboutService.TGetById(id);
            return Ok(result);

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            _aboutService.TDelete(id);
            return Ok("Hakkımızda Alanı Silindi");

        }
        [HttpPost]
        public IActionResult Create(CreateAboutDTO aboutDTO)
        {
            var newValue = _mapper.Map<About>(aboutDTO);
            _aboutService.TCreate(newValue);
            return Ok("Hakkımızda alanı oluşturuldu");

        }
        [HttpPut]
        public IActionResult Update(UpdateAboutDTO aboutDTO)
        {
            var newValue = _mapper.Map<About>(aboutDTO);
            _aboutService.TUpdate(newValue);
            return Ok("Hakkımızda alanı güncellendi");

        }


    }
}
