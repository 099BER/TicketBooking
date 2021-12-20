namespace TicketBookingServer.Models
{
    public interface IOrderRepository
    {
        public void CreateOrder(Order order);
    }
}
