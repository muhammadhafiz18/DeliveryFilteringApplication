using System.Text.Json;
using DeliveryOrderFilter.Models;
using DeliveryOrderFilter.Services;

namespace DeliveryOrderFilter.Data;

public static class GetSetDeliveryData
{
    public static List<Order> LoadOrdersFromFile(string filePath)
    {
    try
    {
        string jsonString = File.ReadAllText(filePath);
        var orders = JsonSerializer.Deserialize<List<Order>>(jsonString);
        LoggingService.Log($"Orders loaded from {filePath}");
        return orders ?? new List<Order>();
    }
    catch (Exception ex)
    {
            LoggingService.Log($"Error reading or deserializing the JSON file: {ex.Message}. Program is terminated unsuccessfully in GetSetDeliveryData.cs, line 21.\n--------------------------------");
            throw new Exception($"Error reading or deserializing the JSON file: {ex.Message}. Program is terminated unsuccessfully in GetSetDeliveryData.cs, line 21.\n--------------------------------");
        }
    }

    public static void WriteFilteredOrdersToJson(List<Order> filteredOrders, string outputFilePath)
    {
        try
        {
            if (filteredOrders.Count == 0)
            {
                LoggingService.Log("No orders found for the given time. Nothing was written to the file. Program is finished successfully in GetSetDeliveryData.cs, line 31.\n--------------------------------");
                return;
            }
            else        
            {
                string json = JsonSerializer.Serialize(filteredOrders, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(outputFilePath, json);
                LoggingService.Log($"Filtered orders successfully written to {outputFilePath}. Program is finished successfully.\n--------------------------------");
            }
        }
        catch (Exception ex)
        {
            LoggingService.Log($"Error writing filtered orders to JSON file: {ex.Message}. Program is terminated unsuccessfully in GetSetDeliveryData.cs, line 29.\n--------------------------------");
            throw new Exception($"Error writing filtered orders to JSON file: {ex.Message}. Program is terminated unsuccessfully in GetSetDeliveryData.cs, line 29.\n--------------------------------");
        }
    }

}
