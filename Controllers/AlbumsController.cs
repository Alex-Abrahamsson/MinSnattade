using AutoMapper;
using Inlamningsuppgift_Marie.Data;
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

        [HttpGet]
        public async Task<IActionResult> GetAllAlbums()
        {
            return new OkObjectResult(await _albumservice.GetAllAlbumsAsync());
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAlbum(int id)
        {
            if (await _albumservice.DeleteAlbumAsync(id))
                return new OkResult();

            return new NotFoundResult();
        }

    }
}
