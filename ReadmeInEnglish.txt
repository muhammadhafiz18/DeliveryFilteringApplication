Delivery Order Filter

This application filters delivery orders based on user input for 
district and delivery time. It reads orders from a JSON file, 
filters them according to specified criteria, and writes 
the filtered results to another JSON file.

Features

- Validates user input for district and delivery time.
- Filters orders based on district and a specified delivery time range.
- Logs all actions and errors to a CSV file.
- Supports the Tashkent district list for validation.

Requirements

- .NET SDK (version 8.0 or higher)
- JSON file with orders in the format specified in orders.json.

How to Run

- Ensure you have the .NET SDK installed on your machine.
- Clone the repository or download the source code.
- Place the orders.json file in the application directory.
- Open a terminal and navigate to the project directory.
- Run the application using the command:

    dotnet run

- Follow the prompts to input the district and delivery time.

Example of Input

- District: yashnabad
- Delivery Time: 2024-10-22T15:00:00

Output

- Filtered orders will be saved to filtered_orders.json.