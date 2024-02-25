using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.DTOs;
using PlatformService.Models;

namespace PlatformService.Controllers
{
    [ApiController]
    [Route("api/platforms")]
    public class PlatformsController : Controller
    {
        private IPlatformRepository _platformRepository;
        private IMapper _mapper;

        public PlatformsController(IPlatformRepository platformRepository, IMapper mapper)
        {
            _platformRepository = platformRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDTO>> GetAllPlatforms()
        {
            var platforms = _platformRepository.GetAllPlarforms();
            var mappedPlatforms = _mapper.Map<IEnumerable<PlatformReadDTO>>(platforms);
            return Ok(mappedPlatforms);
        }

        [HttpGet("{id}")]
        public ActionResult<PlatformReadDTO> GetPlatformById(int id)
        {
            var platform = _platformRepository.GetPlatformById(id);
            if(platform == null) return NotFound();
            var mappedPlatform = _mapper.Map<PlatformReadDTO>(platform);
            return Ok(mappedPlatform);
        }

        [HttpPost]
        public ActionResult<PlatformReadDTO> CreatePlatform(PlatformCreateDTO platformCreateDTO)
        {
            var platformModel = _mapper.Map<Platform>(platformCreateDTO);
            _platformRepository.CreatePlatform(platformModel);

            var mappedPlatform = _mapper.Map<PlatformReadDTO>(platformModel);
            return CreatedAtRoute(new { id = mappedPlatform.Id }, mappedPlatform);
        }
    }
}
