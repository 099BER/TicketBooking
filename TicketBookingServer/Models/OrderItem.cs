using System.Collections.Generic;

namespace TicketBookingServer.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public Screening Screening { get; set; }
        public int ScreeningId { get; set; }
        public int Quantity { get; set; }
        public List<ChosenSeat> ChosenSeats { get; set; }
        public decimal ItemPrice { get; set; }
    }
}
