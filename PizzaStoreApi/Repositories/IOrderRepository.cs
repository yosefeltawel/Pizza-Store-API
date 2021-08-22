using System.Collections.Generic;
using PizzaStoreAPi.Models;

namespace PizzaStoreAPi.Repositories
{
    public interface IOrderRepository
    {
        public List<Order> OrderList { get; set; }
        public Order GetOrderById(int id);
        public void AddOrder(Order order);
        public void SaveOrders();
    }
}