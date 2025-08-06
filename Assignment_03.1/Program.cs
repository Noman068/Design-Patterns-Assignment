using System;
using System.Collections.Generic;

// Entry point
class Program
{
    static void Main()
    {
        var productRepo = new InMemoryProductRepository();
        var orderRepo = new InMemoryOrderRepository();
        var logger = Logger.Instance;
        var config = ConfigurationManager.Instance;

        var productService = new ProductService(productRepo);
        var orderService = new OrderService(orderRepo, logger);
        var paymentContext = new PaymentContext();
        var paymentService = new PaymentService(paymentContext, logger);

        // Seed with some products
        productService.AddProduct(ProductFactory.CreateProduct(ProductCategory.Books, "C# Fundamentals", 49.99m));
        productService.AddProduct(ProductFactory.CreateProduct(ProductCategory.Electronics, "Mechanical Keyboard", 89.99m));
        productService.AddProduct(ProductFactory.CreateProduct(ProductCategory.Clothing, "Denim Jacket", 59.99m));
        productService.AddProduct(ProductFactory.CreateProduct(ProductCategory.HomeGarden, "LED Lamp", 25.99m));

        while (true)
        {
            Console.WriteLine("\n=== E-Commerce Order Management System ===");
            Console.WriteLine("1. View Products");
            Console.WriteLine("2. Add New Product");
            Console.WriteLine("3. Create Order");
            Console.WriteLine("4. Process Payment");
            Console.WriteLine("5. View Orders");
            Console.WriteLine("6. Check Inventory");
            Console.WriteLine("7. System Logs");
            Console.WriteLine("8. Configuration");
            Console.WriteLine("9. Exit");
            Console.Write("Please select an option: ");

            string input = Console.ReadLine();
            Console.WriteLine();

            if (input == "1")
            {
                productService.ShowAllProducts();
            }
            else if (input == "2")
            {
                Console.Write("Enter product name: ");
                string name = Console.ReadLine();

                Console.Write("Enter price: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal price))
                {
                    Console.WriteLine("Invalid price.");
                    continue;
                }

                Console.WriteLine("Select category (0: Electronics, 1: Clothing, 2: Books, 3: HomeGarden): ");
                if (!int.TryParse(Console.ReadLine(), out int category) || category < 0 || category > 3)
                {
                    Console.WriteLine("Invalid category.");
                    continue;
                }

                var product = ProductFactory.CreateProduct((ProductCategory)category, name, price);
                productService.AddProduct(product);
                logger.LogInfo("Product added: " + name);
            }
            else if (input == "3")
            {
                Console.Write("Enter Customer Name: ");
                string custName = Console.ReadLine();
                var customer = new Customer(custName);

                List<Product> selected = new List<Product>();
                var allProducts = productService.GetAllProducts();
                for (int i = 0; i < allProducts.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {allProducts[i].GetProductDetails()}");
                }

                Console.WriteLine("Enter product numbers to add to order (comma separated):");
                var choices = Console.ReadLine().Split(',');

                foreach (var ch in choices)
                {
                    if (int.TryParse(ch.Trim(), out int index))
                    {
                        index -= 1;
                        if (index >= 0 && index < allProducts.Count)
                        {
                            selected.Add(allProducts[index]);
                        }
                    }
                }

                if (selected.Count == 0)
                {
                    Console.WriteLine("No valid products selected.");
                    continue;
                }

                var order = orderService.CreateOrder(customer.CustomerId, selected);
                Console.WriteLine("Order created successfully.");
                order.DisplayOrder();
            }
            else if (input == "4")
            {
                Console.WriteLine("Choose payment method:");
                Console.WriteLine("1 - Credit Card");
                Console.WriteLine("2 - PayPal");
                Console.WriteLine("3 - Bank Transfer");
                Console.WriteLine("4 - Crypto");
                string pType = Console.ReadLine();

                if (pType == "1") paymentContext.SetStrategy(new CreditCardPayment());
                else if (pType == "2") paymentContext.SetStrategy(new PayPalPayment());
                else if (pType == "3") paymentContext.SetStrategy(new BankTransferPayment());
                else if (pType == "4") paymentContext.SetStrategy(new CryptoPayment());
                else
                {
                    Console.WriteLine("Invalid payment option.");
                    continue;
                }

                Console.Write("Enter payment amount: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal amt))
                {
                    Console.WriteLine("Invalid amount.");
                    continue;
                }

                paymentService.ProcessPayment(amt);
            }
            else if (input == "5")
            {
                orderService.ShowOrders();
            }
            else if (input == "6")
            {
                var lowStock = productRepo.GetLowStockProducts(5);
                Console.WriteLine("Low Stock Products:");
                foreach (var p in lowStock)
                {
                    Console.WriteLine(p.GetProductDetails());
                }
            }
            else if (input == "7")
            {
                Console.WriteLine("System Logs Placeholder (Logs are printed in real-time above).");
                logger.LogInfo("System Logs Viewed.");
            }
            else if (input == "8")
            {
                Console.Write("Enter config key: ");
                string key = Console.ReadLine();
                Console.Write("Enter config value: ");
                string value = Console.ReadLine();
                config.SetSetting(key, value);
                Console.WriteLine($"Value for '{key}': {config.GetSetting(key)}");
            }
            else if (input == "9")
            {
                Console.WriteLine("Exiting application...");
                break;
            }
            else
            {
                Console.WriteLine("Invalid option. Try again.");
            }
        }
    }
}
