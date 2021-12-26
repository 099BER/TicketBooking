using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TicketBookingServer.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;

        public OrderRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Order> AllOrdersForUser(string userId)
        {
            return _appDbContext.Orders.Where(o => o.UserId == userId);
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            _appDbContext.Orders.Add(order);
            _appDbContext.SaveChanges();
        }
        public void DeleteOrderById(int id)
        {
            Order order = new Order() { OrderId = id };
            _appDbContext.Orders.Attach(order);
            _appDbContext.Orders.Remove(order);
            _appDbContext.SaveChanges();
        }
    }
}