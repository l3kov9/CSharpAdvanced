using LocalPub.Models;
using LocalPub.Models.BindingModels;
using LocalPub.Models.ViewModels;
using System;
using System.Collections.Generic;

namespace LocalPub.Domain.Interfaces
{
    public interface IOrdersRepository : IDbRepository
    {
        int GetNumberOfOrdersForClient(int clientId, DateTime date);

        ICollection<OrderViewModel> GetAllOrdersForClient(int clientId);

        int GetOrderClient(int orderId);

        bool SaveOrder(OrderBindingModel order);

        bool CancelOrder(int orderId);
    }
}
