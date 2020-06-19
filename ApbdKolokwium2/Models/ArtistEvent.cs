using System;

namespace ApbdKolokwium2.Models
{
    public class ArtistEvent
    {
        public int IdEvent { get; set; }
        public int IdArtist { get; set; }
        public DateTime PerformanceDate { get; set; }
        public virtual Artist Artist { get; set; }
        public virtual Event Event { get; set; }
    }
}