using System.Collections.Generic;

namespace ApbdKolokwium2.Models
{
    public class Organiser
    {
        public int IdOrganiser { get; set; }
        public string Name { get; set; }
        public virtual ICollection<EventOrganiser> EventOrganizers { get; set; }
    }
}