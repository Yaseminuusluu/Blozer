using BlazorVİdeo.Shared.DTO;

namespace BlazorVİdeo.Server.Services.Infrastruce
{
    public interface IOrderService
    {
         Task<OrderDTO> CreateOrder(OrderDTO Order);

         Task<OrderDTO> UpdateOrder(OrderDTO Order);

        Task DeleteOrder(Guid OrderId);

        Task<List<OrderDTO>> GetOrders(DateTime OrderDate);

        //public Task<List<OrderDTO>> GetOrdersByFilter(OrderListFilterModel Filter);

       Task<OrderDTO> GetOrderById(Guid Id);



         Task<OrderItemsDTO> CreateOrderItem(OrderItemsDTO OrderItem);

         Task<OrderItemsDTO> UpdateOrderItem(OrderItemsDTO OrderItem);

         Task<List<OrderItemsDTO>> GetOrderItems(Guid OrderId);

         Task<OrderItemsDTO> GetOrderItemsById(Guid Id);

         Task DeleteOrderItem(Guid OrderItemId);
    }
}
