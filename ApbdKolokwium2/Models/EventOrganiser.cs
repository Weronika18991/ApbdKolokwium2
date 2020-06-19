namespace ApbdKolokwium2.Models
{
    public class EventOrganiser
    {
        public int IdEvent { get; set; }
        public int IdOrganiser { get; set; }
        public virtual Organiser Organiser { get; set; }
        public virtual Event Event { get; set; }
    }
}