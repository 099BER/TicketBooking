using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TicketBookingServer.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int ScreeningId { get; set; }
        public int MovieId { get; set; }
        public string UserId { get; set; }
        public List<ChosenSeat> ChosenSeats { get; set; }
        public decimal OrderTotal { get; set; }
        public DateTime OrderPlaced { get; set; }
    }
}
