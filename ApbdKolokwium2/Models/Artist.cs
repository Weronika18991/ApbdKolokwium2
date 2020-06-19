using System.Collections.Generic;

namespace ApbdKolokwium2.Models
{
    public class Artist
    {
        public int IdArtist { get; set; }
        public string Nickname { get; set; }
        public virtual ICollection<ArtistEvent> ArtistEvents { get; set; }
    }
}