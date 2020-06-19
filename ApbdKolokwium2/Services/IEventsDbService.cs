using ApbdKolokwium2.DTOs.Requests;
using ApbdKolokwium2.DTOs.Responses;

namespace ApbdKolokwium2.Services
{
    public interface IEventsDbService
    {
        public GetArtistResponse GetArtist(int id);
        public void UpdateArtistPerformanceTime(int idArtist, int idEvent, UpdateArtistPerformanceTimeRequest request);

    }
}