using System.Collections;

namespace ApbdKolokwium2.DTOs.Responses
{
    public class GetArtistResponse
    {
        public int IdArtist { get; set; }
        public string Nickname { get; set; }
        public IEnumerable Events { get; set; }
    }
}