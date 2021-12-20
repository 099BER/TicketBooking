
using System.Collections.Generic;

namespace TicketBookingServer.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; } 
        public string ShoppingCartId { get; set; } 
        public Screening Screening { get; set; }
        public int ScreeningId { get; set; }
        public int Quantity { get; set; }
        public List<ChosenSeat> ChosenSeats { get; set; }
    }
}
