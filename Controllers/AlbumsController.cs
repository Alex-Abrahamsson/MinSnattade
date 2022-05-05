using AutoMapper;
using Inlamningsuppgift_Marie.Models.Album;
using Inlamningsuppgift_Marie.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inlamningsuppgift_Marie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly IAlbumService _albumservice;
        private readonly IMapper _mapper;

        public AlbumsController(IAlbumService albumservice, IMapper mapper)
        {
            _albumservice = albumservice;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> CreateAlbumAsync(CreateAlbumModel request)
        {
            var artistExists = await _albumservice.CreateAlbumAsync(request);
            var newArtist = _mapper.Map<Album>(request);
            if (artistExists != null)
            {
                return new OkObjectResult(newArtist);
            }

            return new BadRequestResult();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAlbums()
        {
            return new OkObjectResult(await _albumservice.GetAllAlbumsAsync());
        }
    }
}
