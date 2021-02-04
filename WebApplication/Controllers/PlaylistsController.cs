using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationModel.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.DataTransfer;
using WebApplication.Services;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistsController : ControllerBase
    {
        private readonly IPlaylistService _playlistService;
        private readonly IMapper _mapper;

        public PlaylistsController(IPlaylistService playlistService, IMapper mapper)
        {
            _playlistService = playlistService;
            _mapper = mapper;
        }

        // GET: api/Playlists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Playlist>>> GetPlaylists()
        {
            throw new NotImplementedException();
        }

        // GET: api/Playlists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlaylistDTO>> GetPlaylist(int id)
        {
            var playlist = await _playlistService.GetPlaylistByIdAsync(id);
            if (playlist == null)
            {
                return NotFound();
            }

            return _mapper.Map<Playlist, PlaylistDTO>(playlist);
        }

        // PUT: api/Playlists/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlaylist(int id, Playlist playlist)
        {
            throw new NotImplementedException();
        }

        // POST: api/Playlists
        [HttpPost]
        public async Task<ActionResult<Playlist>> PostPlaylist([FromBody] PlaylistInfoDTO playlistInfo)
        {
            try
            {
                var playlist = await _playlistService.CreatePlaylistAsync(
                    _mapper.Map<PlaylistInfoDTO, Playlist>(playlistInfo));

                return CreatedAtAction(nameof(GetPlaylist), new { id = playlist.Id },
                    _mapper.Map<Playlist, PlaylistDTO>(playlist));
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE: api/Playlists/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Playlist>> DeletePlaylist(int id)
        {
            throw new NotImplementedException();
        }
    }
}
