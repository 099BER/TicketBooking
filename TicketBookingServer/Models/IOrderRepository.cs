using System.Collections;
using System.Collections.Generic;

namespace TicketBookingServer.Models
{
    public interface IOrderRepository
    {
        public void CreateOrder(Order order);
        public IEnumerable<Order> AllOrdersForUser(string userId);
    }
}
