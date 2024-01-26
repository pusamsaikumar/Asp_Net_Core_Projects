using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicRepository.Data.MusicRepository;
using MusicRepository.DTO;
using MusicRepository.Models;

namespace MusicRepository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly IMusicService _musicServiceUpdateMusic;
private readonly IMusicService _musicService;
        private readonly IMapper _mapper;

        public MusicController(IMusicService musicService, IMapper mapper)
        {
            _musicService = musicService;
            _mapper = mapper;
        }

        // get music list
        [HttpGet]
        public IActionResult Get()
        {
            var model = _musicService.GetMusicList();
            if (model.Any())
            {
                return StatusCode(StatusCodes.Status200OK, _mapper.Map<IEnumerable<MusicDTO>>(model));

            }
            return StatusCode(StatusCodes.Status204NoContent);


        }

        // get music by id
        [HttpGet("Details/{id}")]
        public IActionResult GetById(Guid id)
        {
            var model = _musicService.GetMusicById(id);
            if (model != null)
            {
                return StatusCode(StatusCodes.Status200OK, _mapper.Map<MusicDTO>(model));

            }
            return StatusCode(StatusCodes.Status404NotFound);

        }

        // post
        [HttpPost]
        public async Task<IActionResult> CreateMusic(MusicDTO musicDTO)
        {
            var mapModel = _mapper.Map<Music>(musicDTO);
            var result = await _musicService.AddMusic(mapModel);
            if (result is not null)
            {
                return StatusCode(StatusCodes.Status201Created, _mapper.Map<MusicDTO>(result));
            }
            return StatusCode(StatusCodes.Status400BadRequest);
        }

        // update
        [HttpPut]
        public async Task<IActionResult> Put(Guid id, MusicDTO musicDTO)
        {
            var mapModel = _mapper.Map<Music>(musicDTO);
            var result = await _musicService.UpdateMusic( id,mapModel);
            if(result is not null)
            {
                return StatusCode(StatusCodes.Status200OK,_mapper.Map<MusicDTO>(result));
            }
            return StatusCode(StatusCodes.Status400BadRequest);
        }
        // Deletee
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var model = _musicService.DeleteMusic(id);
            if(model is true)
            {
                return StatusCode(StatusCodes.Status200OK);

            }
            return StatusCode(StatusCodes.Status400BadRequest);

        }
    }
}