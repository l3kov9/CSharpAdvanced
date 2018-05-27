using LocalPub.Domain.Interfaces;
using LocalPub.Domain.SqlServer;
using LocalPub.Models;
using LocalPub.Models.BindingModels;
using LocalPub.Models.ViewModels;
using System;
using System.Collections.Generic;

namespace LocalPub.Domain.Managers
{
    public class OrderManager
    {
        private IMenuRepository menuRepository;
        private IOrdersRepository ordersRepository;

        public OrderManager()
            : this(new SqlMenuRepository(), new SqlOrdersRepository())
        {
        }

        public OrderManager(IMenuRepository menuRepository, IOrdersRepository ordersRepository)
        {
            this.menuRepository = menuRepository;
            this.ordersRepository = ordersRepository;
        }

        public MenuViewModel PrepareOrderMenu()
        {
            return this.menuRepository.GetMenu();
        }

        public ICollection<OrderViewModel> GetAllOrders(int clientId)
        {
            return this.ordersRepository.GetAllOrdersForClient(clientId);
        }

        public bool SaveOrder(OrderBindingModel order)
        {
            int currentOrdersCount = this.ordersRepository.GetNumberOfOrdersForClient(order.ClientId, order.OrderDate);
            if (currentOrdersCount != 0)
            {
                // We can't have multiple active orders for a given day
                return false;
            }

            return this.ordersRepository.SaveOrder(order);
        }

        public bool CancelOrder(int orderId, int clientId)
        {
            int orderClientId = this.ordersRepository.GetOrderClient(orderId);
            if (orderClientId != clientId)
            {
                return false;
            }

            return this.ordersRepository.CancelOrder(orderId);
        }
    }
}
