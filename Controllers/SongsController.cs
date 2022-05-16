using AutoMapper;
using Inlamningsuppgift_Marie.Models.Song;
using Inlamningsuppgift_Marie.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inlamningsuppgift_Marie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly ISongService _service;
        private readonly IMapper _mapper;

        public SongsController(ISongService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> CreateSong(CreateSongModel request)
        {
            var songExists = await _service.CreateSongAsync(request);
            if (songExists != null)
            {
                return new OkObjectResult(songExists);
            }

            return new BadRequestResult();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSongs()
        {
            return new OkObjectResult(await _service.GetAllSongsAsync());
        }

        [HttpGet("{songId:int}")]
        public async Task<ActionResult> GetSongById(int songId)
        {
            var song = await _service.GetSongByIdAsync(songId);
            return Ok(song);

        }

        [HttpPut("{songId:int}")]
        public async Task<ActionResult> UpdateSong(int songId, CreateSongModel request)
        {
            var item = await _service.UpdateSongAsync(songId, request);
            if (item != null)
            {
                return new OkObjectResult(item);
            }

            return BadRequest("can't find albumId");
        }

        [HttpDelete("{songId:int}")]
        public async Task<ActionResult> DeleteSongById(int songId)
        {
            if (await _service.DeleteSongByIdAsync(songId))
                return new OkResult();

            return new NotFoundResult();
        }
    }
}
