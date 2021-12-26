namespace TicketBookingServer.Models
{
    public class ChosenSeat
    {
        public int ChosenSeatId { get; set; }
        public int OrderId { get; set; }
        public int ScreeningId { get; set; }
        public int SeatNumber { get; set;}
    }
}
