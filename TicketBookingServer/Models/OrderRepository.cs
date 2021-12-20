using System;
using System.Collections.Generic;

namespace TicketBookingServer.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ShoppingCart _shoppingCart;

        public OrderRepository(AppDbContext appDbContext, ShoppingCart shoppingCart)
        {
            _appDbContext = appDbContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            var shoppingCartItems = _shoppingCart.ShoppingCartItems;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();
            order.OrderItems = new List<OrderItem>();
            foreach(var shoppingCartItem in shoppingCartItems)
            {
                var orderItem = new OrderItem()
                {
                    OrderId = order.OrderId,
                    ScreeningId = shoppingCartItem.Screening.ScreeningId,
                    Quantity = shoppingCartItem.Quantity,
                    ChosenSeats = shoppingCartItem.ChosenSeats,
                    ItemPrice = shoppingCartItem.Screening.Movie.Price * shoppingCartItem.Quantity,
                };
                order.OrderItems.Add(orderItem);
            }
            _appDbContext.Orders.Add(order);
            _appDbContext.SaveChanges();
        }
    }
}