using System;
using System.Collections;
using System.Linq;
using ApbdKolokwium2.DTOs.Requests;
using ApbdKolokwium2.DTOs.Responses;
using ApbdKolokwium2.Exceptions;
using ApbdKolokwium2.Models;
using Microsoft.EntityFrameworkCore;

namespace ApbdKolokwium2.Services
{
    public class SqlServerEventsDbService : IEventsDbService
    {
        private readonly EventDbContext _context;

        public SqlServerEventsDbService(EventDbContext context)
        {
            _context = context;
        }


        public GetArtistResponse GetArtist(int id)
        {
            var artist = _context.Artists.Include(e => e.ArtistEvents)
                .SingleOrDefault(e => e.IdArtist == id);

            if (artist == null)
            {
                throw new ArtistDoesNotExistsException($"Artist with an id {id} does not exists");
            }

            var events = artist.ArtistEvents.Join(_context.Events, artist_event => artist_event.IdEvent,
                e => e.IdEvent,
                (artistEvent, e) => new
                {
                    e.IdEvent,
                    e.Name,
                    e.StartDate,
                });
            
            GetArtistResponse getArtistResponse = new GetArtistResponse()
            {
                IdArtist = artist.IdArtist,
                Nickname = artist.Nickname,
                Events = events
            };
            return getArtistResponse;
        }

        public void UpdateArtistPerformanceTime(int idArtist, int idEvent, UpdateArtistPerformanceTimeRequest request)
        {
            var anEvent = _context.Events.Include(e => e.ArtistEvents)
                .SingleOrDefault(e => e.IdEvent == idEvent);

            if (anEvent == null)
            {
                throw new EventDoesNotExistsException($"Event with an id {idEvent} does not exists");
            }
            
            var artistEvent = anEvent.ArtistEvents.SingleOrDefault(e => e.IdArtist == idArtist);

            if (artistEvent == null)
            {
                throw new ArtistDoesNotParticipateInAnEventException($"Artist with an id {idArtist} does not participate in an event with an id {idEvent}");
            }

            if (DateTime.Compare(anEvent.StartDate,DateTime.Now) > 0)
            {
                throw new EventAlreadyBegunException("An event has already begun");
            }

            if (!(DateTime.Compare(anEvent.StartDate,request.PerformanceDate) < 0 && DateTime.Compare(request.PerformanceDate,anEvent.EndDate) < 0 ))
            {
                throw new IncorrectTimeException($"Performance date has to be between {anEvent.StartDate} and {anEvent.EndDate}");
            }
            
            artistEvent.PerformanceDate = request.PerformanceDate; 
            _context.SaveChanges();
            
        }
    }
}