using System;
using System.ComponentModel.DataAnnotations;

namespace ApbdKolokwium2.DTOs.Requests
{
    public class UpdateArtistPerformanceTimeRequest
    {
        [Required]
        public int IdEvent { get; set; }
        [Required]
        public int IdArtist { get; set; }
        [Required]
        public DateTime PerformanceDate { get; set; }
    }
}