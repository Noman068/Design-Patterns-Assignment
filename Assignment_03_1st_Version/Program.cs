using System;
using System.Collections.Generic;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        var productRepo = new InMemoryProductRepository();
        var orderRepo = new InMemoryOrderRepository();
        var logger = Logger.Instance;
        var config = ConfigurationManager.Instance;

        var productService = new ProductService(productRepo);
        var orderService = new OrderService(orderRepo, logger);
        var paymentContext = new PaymentContext();
        var paymentService = new PaymentService(paymentContext, logger);

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

            switch (input)
            {
                case "1":
                    var products = await productService.GetAllProductsAsync();
                    foreach (var p in products)
                    {
                        Console.WriteLine(p.GetProductDetails());
                    }
                    break;

                case "2":
                    Console.Write("Enter product name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter price: ");
                    if (!decimal.TryParse(Console.ReadLine(), out decimal price))
                    {
                        Console.WriteLine("Invalid price.");
                        break;
                    }

                    Console.WriteLine("Select category (0: Electronics, 1: Clothing, 2: Books, 3: HomeGarden): ");
                    if (!int.TryParse(Console.ReadLine(), out int category) || category < 0 || category > 3)
                    {
                        Console.WriteLine("Invalid category.");
                        break;
                    }

                    var product = ProductFactory.CreateProduct((ProductCategory)category, name, price);
                    await productService.AddProductAsync(product);
                    logger.LogInfo("Product added: " + name);
                    break;

                case "3":
                    Console.Write("Enter Customer Name: ");
                    string custName = Console.ReadLine();
                    var customer = new Customer(custName);

                    List<Product> selected = new List<Product>();
                    var allProducts = await productService.GetAllProductsAsync();
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
                        break;
                    }

                    var order = orderService.CreateOrder(customer.CustomerId, selected);
                    Console.WriteLine("Order created successfully.");
                    order.DisplayOrder();
                    break;

                case "4":
                    Console.WriteLine("Choose payment method:");
                    Console.WriteLine("1 - Credit Card");
                    Console.WriteLine("2 - PayPal");
                    Console.WriteLine("3 - Bank Transfer");
                    Console.WriteLine("4 - Crypto");
                    string pType = Console.ReadLine();

                    switch (pType)
                    {
                        case "1": paymentContext.SetStrategy(new CreditCardPayment()); break;
                        case "2": paymentContext.SetStrategy(new PayPalPayment()); break;
                        case "3": paymentContext.SetStrategy(new BankTransferPayment()); break;
                        case "4": paymentContext.SetStrategy(new CryptoPayment()); break;
                        default:
                            Console.WriteLine("Invalid payment option.");
                            continue;
                    }

                    Console.Write("Enter payment amount: ");
                    if (!decimal.TryParse(Console.ReadLine(), out decimal amt))
                    {
                        Console.WriteLine("Invalid amount.");
                        break;
                    }

                    paymentService.ProcessPayment(amt);
                    break;

                case "5":
                    orderService.ShowOrders();
                    break;

                case "6":
                    var lowStock = await productRepo.GetLowStockProductsAsync(5);
                    Console.WriteLine("Low Stock Products:");
                    foreach (var p in lowStock)
                    {
                        Console.WriteLine(p.GetProductDetails());
                    }
                    break;

                case "7":
                    Console.WriteLine("System Logs Placeholder (Logs are printed in real-time above).");
                    logger.LogInfo("System Logs Viewed.");
                    break;

                case "8":
                    Console.Write("Enter config key: ");
                    string key = Console.ReadLine();
                    Console.Write("Enter config value: ");
                    string value = Console.ReadLine();
                    config.SetSetting(key, value);
                    Console.WriteLine($"Value for '{key}': {config.GetSetting(key)}");
                    break;

                case "9":
                    Console.WriteLine("Exiting application...");
                    return;

                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }
}
