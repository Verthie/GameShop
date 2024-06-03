using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Models;
using Shop.Models.ViewModels;

namespace GameShop.Services
{
    public interface IOrderService
    {
        OrderVM GetOrderDetails(int orderId);
        void UpdateOrder(OrderVM orderVM);
        void UpdateOrderStatus(int orderId, string status);
        void ShipOrder(OrderVM orderVM);
        void CancelOrder(OrderVM orderVM);
        void ConfirmPayment(int orderHeaderId);
        IEnumerable<OrderHeader> GetAllOrders(string userId, string status, bool isAdmin);
    }
}