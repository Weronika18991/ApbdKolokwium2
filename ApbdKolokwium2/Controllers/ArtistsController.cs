using ApbdKolokwium2.DTOs.Requests;
using ApbdKolokwium2.Exceptions;
using ApbdKolokwium2.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApbdKolokwium2.Controllers
{
    [ApiController]
    [Route("api/artists")]
    public class ArtistsController : ControllerBase
    {
        private readonly IEventsDbService _service;

        public ArtistsController(IEventsDbService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public IActionResult GetArtists(int id)
        {
            try
            {
                var artist = _service.GetArtist(id);
                return Ok(artist);
            }
            catch (ArtistDoesNotExistsException exception)
            {
                return NotFound(exception.Message);
            }
            
        }
        
        [HttpPut("{idArtist}/events/{idEvent}")]
        public IActionResult UpdateArtistPerformanceTime(int idArtist,int idEvent, UpdateArtistPerformanceTimeRequest request)
        {
            try
            {
                _service.UpdateArtistPerformanceTime(idArtist, idEvent, request);
                return NoContent();
            }
            catch (EventDoesNotExistsException exception)
            {
                return NotFound(exception.Message);
            }
            catch (ArtistDoesNotParticipateInAnEventException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (EventAlreadyBegunException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (IncorrectTimeException exception)
            {
                return BadRequest(exception.Message);
            }
        }
        
    }
}