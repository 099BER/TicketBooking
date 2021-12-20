namespace TicketBookingServer.Models
{
    public class Theatre
    {
        public int TheatreId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public SeatingConfig SeatingConfig { get; set; }
        public int SeatingConfigId { get; set; }
    }
}
