using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationModel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Services;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TracksController : ControllerBase
    {
        private readonly ITrackService _trackService;

        public TracksController(ITrackService trackService)
        {
            _trackService = trackService;
        }

        // GET: api/Tracks
        [HttpGet]
        public async Task<IEnumerable<Track>> GetTracks()
        {
            return await _trackService.GetAllTracksAsync();
        }

        // GET: api/Tracks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Track>> GetTrack(int id)
        {
            var track = await _trackService.GetTrackByIdAsync(id);
            if (track == null)
            {
                return NotFound();
            }

            return track;
        }

        // PUT: api/Tracks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrack(int id, Track track)
        {
            var trackToUpdate = await _trackService.GetTrackByIdAsync(id);
            if (trackToUpdate == null)
            {
                return NotFound();
            }

            try
            {
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
        public async Task<ActionResult<Track>> PostTrack([FromBody] Track track)
        {
            try
            {
                var createdTrack = await _trackService.CreateTrackAsync(track);
                return CreatedAtAction(nameof(GetTrack), new { id = createdTrack.Id }, createdTrack);
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
