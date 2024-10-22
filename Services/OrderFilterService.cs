using DeliveryOrderFilter.Models;

namespace DeliveryOrderFilter.Services;

public class OrderFilterService
{
    public List<Order> FilterOrders(List<Order> orders, string district, DateTime firstDeliveryTime)
    {
        try
        {
            DateTime filterTime = firstDeliveryTime.AddMinutes(30);
            
            List<Order> filteredOrders = orders.FindAll(order =>
                order.District.Equals(district, StringComparison.OrdinalIgnoreCase) &&
                    order.DeliveryTime >= firstDeliveryTime &&
                    order.DeliveryTime <= filterTime);

            if (filteredOrders.Count == 0)
            {
                LoggingService.Log("No orders found for the given time in OrderFilterService.cs, line 20.");
                return new List<Order>();
            }

            LoggingService.Log($"Filtered {filteredOrders.Count} orders in OrderFilterService.cs, line 23.");
            return filteredOrders;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error filtering orders: {ex.Message}. Program is terminated unsuccessfully in OrderFilterService.cs, line 26.\n--------------------------------");
        }
    }
}
