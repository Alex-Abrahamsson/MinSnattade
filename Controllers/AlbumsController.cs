using AutoMapper;
using Inlamningsuppgift_Marie.Data;
using Inlamningsuppgift_Marie.Models;
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
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;

        public AlbumsController(IAlbumService albumservice, IMapper mapper, DatabaseContext databaseContext)
        {
            _albumservice = albumservice;
            _mapper = mapper;
            _databaseContext = databaseContext;
        }

        [HttpPost]
        public async Task<ActionResult> CreateAlbum(CreateAlbumModel request)
        {
            var albumExists = await _albumservice.CreateAlbumAsync(request);
            if (albumExists != null)
            {
                return new OkObjectResult(albumExists);
            }

            return new BadRequestResult();
        }

        //<ActionResult<Album>>
        [HttpGet("{albumId:int}")]
        public async Task<ActionResult> GetAlbumById(int albumId)
        {
            var album = await _albumservice.GetAlbumByIdAsync(albumId);
            //var artist = await _databaseContext.Artists.FindAsync(album.ArtistId);
            //album.ArtistName = artist.ArtistName;
            return Ok(album);
        }


        [HttpPut("{albumId:int}")]
        public async Task<ActionResult> UpdateAlbum(int albumId, CreateAlbumModel request)
        {
            var item = await _albumservice.UpdateAlbumAsync(albumId, request);
            if (item != null)
            {
                return new OkObjectResult(item);
            }

            return new BadRequestResult();
        }

        [HttpDelete("{albumId:int}")]
        public async Task<ActionResult> DeleteAlbum(int albumId)
        {
            if (await _albumservice.DeleteAlbumAsync(albumId))
                return new OkResult();

            return new NotFoundResult();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAlbums()
        {
            return new OkObjectResult(await _albumservice.GetAllAlbumsAsync());
        }


    }
}
