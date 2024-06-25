using System;
using FoodDeliveryModels;
using FoodDeliveryServices;

namespace FoodDeliveryClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FoodDeliveryServices deliveryServices = new FoodDeliveryServices();

            // Example: Get available foods
            var availableFoods = deliveryServices.GetAvailableFoods();
            foreach (var food in availableFoods)
            {
                Console.WriteLine($"Food: {food.Name}, Price: {food.Price}");
            }

            // Example: Place an order
            Order newOrder = new Order
            {
                CustomerName = "John Doe",
                Foods = new List<Food> { new Food { Name = "Pizza", Price = 15.99m }, new Food { Name = "Salad", Price = 8.99m } },
                TotalAmount = 24.98m
            };
            bool orderPlaced = deliveryServices.PlaceOrder(newOrder);
            Console.WriteLine($"Order placed: {orderPlaced}");

            // Example: Get orders by customer
            var customerOrders = deliveryServices.GetOrdersByCustomer("John Doe");
            foreach (var order in customerOrders)
            {
                Console.WriteLine($"Order ID: {order.Id}, Total Amount: {order.TotalAmount}");
            }

            // Example: Update an order (mark as completed)
            if (customerOrders.Count > 0)
            {
                var orderToUpdate = customerOrders[0];
                orderToUpdate.IsCompleted = true;
                bool orderUpdated = deliveryServices.UpdateOrder(orderToUpdate);
                Console.WriteLine($"Order updated: {orderUpdated}");
            }

            // Example: Cancel an order
            if (customerOrders.Count > 1)
            {
                int orderIdToCancel = customerOrders[1].Id;
                bool orderCancelled = deliveryServices.CancelOrder(orderIdToCancel);
                Console.WriteLine($"Order cancelled: {orderCancelled}");
            }
        }
    }

