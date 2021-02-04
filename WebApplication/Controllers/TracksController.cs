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
    public class TracksController : ControllerBase
    {
        private readonly ITrackService _trackService;
        private readonly IMapper _mapper;

        public TracksController(ITrackService trackService, IMapper mapper)
        {
            _trackService = trackService;
            _mapper = mapper;
        }

        // GET: api/Tracks
        [HttpGet]
        public async Task<IEnumerable<TrackDTO>> GetTracks()
        {
            var tracks = await _trackService.GetAllTracksAsync();
            return _mapper.Map<IEnumerable<Track>, IEnumerable<TrackDTO>>(tracks);
        }

        // GET: api/Tracks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrackDTO>> GetTrack(int id)
        {
            var track = await _trackService.GetTrackByIdAsync(id);
            if (track == null)
            {
                return NotFound();
            }

            return _mapper.Map<Track, TrackDTO>(track);
        }

        // PUT: api/Tracks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrack(int id, TrackInfoDTO trackInfo)
        {
            var trackToUpdate = await _trackService.GetTrackByIdAsync(id);
            if (trackToUpdate == null)
            {
                return NotFound();
            }

            try
            {
                var track = _mapper.Map<TrackInfoDTO, Track>(trackInfo);
                await _trackService.UpdateTrackAsync(trackToUpdate, track);
                return NoContent();
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // POST: api/Tracks
        [HttpPost]
        public async Task<ActionResult<TrackDTO>> PostTrack([FromBody] TrackInfoDTO trackInfo)
        {
            try
            {
                var createdTrack = await _trackService.CreateTrackAsync(_mapper.Map<TrackInfoDTO, Track>(trackInfo));
                return CreatedAtAction(nameof(GetTrack), new { id = createdTrack.Id }, _mapper.Map<Track, TrackDTO>(createdTrack));
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE: api/Tracks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Track>> DeleteTrack(int id)
        {
            var track = await _trackService.GetTrackByIdAsync(id);
            if (track == null)
            {
                return NotFound();
            }

            try
            {
                await _trackService.DeleteTrackAsync(track);
                return NoContent();
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
