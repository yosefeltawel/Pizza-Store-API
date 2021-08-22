using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using PizzaStoreAPi.Models;

namespace PizzaStoreAPi.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private const string _jsonFilePath = @"./Data/orders.json";

        public OrderRepository()
        {
            OrderList = JsonManager.ReadJsonFile<List<Order>>(_jsonFilePath);
        }

        public List<Order> OrderList { get; set; }

        public Order GetOrderById(int id)
        {
            return OrderList.Where(o => o.Id == id).FirstOrDefault();
        }

        public void AddOrder(Order order)
        {
            order.Id = OrderList.Count + 1;
            OrderList.Add(order);
        }
        
        public void SaveOrders()
        {
            Console.WriteLine("Orders dispose");
            JsonManager.SaveJsonFile(OrderList, _jsonFilePath);
        }
    }
}