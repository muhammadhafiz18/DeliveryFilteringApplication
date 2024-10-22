using DeliveryOrderFilter.Services;
using DeliveryOrderFilter.Models;   
using DeliveryOrderFilter.Data;
using System.Globalization;

string errorForCityOrDistrict = "City or district is required. Program is terminated unsuccessfully in Program.cs, line 27.\n--------------------------------";
string errorForMessageForFirstDeliveryTime = "Invalid date/time format. Please use 'yyyy-MM-ddTHH:mm:ss'. Program is terminated unsuccessfully in Program.cs, line 36.\n--------------------------------";

string ordersFilePath = "orders.json";
string outputFilePath = "filtered_orders.json";

string formatOfDeliveryTime = "yyyy-MM-ddTHH:mm:ss";

string[] tashkentDistricts =
[
    "bektemir", "chilanzar", "mirabad",
    "mirzo-ulugbek", "olmazar", "sergeli",
    "shaykhantakhur", "uchtepa", "yakkasaray",
    "yashnabad", "yunusabad", "yangihayot"
];

Console.WriteLine("Enter the district:");
string? cityDistrict = Console.ReadLine()?.Trim().Replace(" ", "").ToLower();
if (cityDistrict == null || !tashkentDistricts.Contains(cityDistrict))
{
    LoggingService.Log(errorForCityOrDistrict);
    throw new Exception(errorForCityOrDistrict);
}

Console.WriteLine("Enter the first delivery time:");
string? firstDeliveryTime = Console.ReadLine()?.Trim().Replace(" ", "");
if (!DateTime.TryParseExact(firstDeliveryTime, formatOfDeliveryTime, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime firstDeliveryDateTime))
{
    // If parsing fails, throw an exception
    LoggingService.Log(errorForMessageForFirstDeliveryTime);
    throw new FormatException(errorForMessageForFirstDeliveryTime);
}

OrderFilterService orderService = new();

List<Order> orders = GetSetDeliveryData.LoadOrdersFromFile(ordersFilePath);

List<Order> filteredOrders = orderService.FilterOrders(orders, cityDistrict, firstDeliveryDateTime);

LoggingService.Log($"Filtered {filteredOrders.Count} orders");

GetSetDeliveryData.WriteFilteredOrdersToJson(filteredOrders, outputFilePath);
