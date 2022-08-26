// See https://aka.ms/new-console-template for more information
using SqlLiteInNET6.DbContexts;
using SqlLiteInNET6.Entities;

using (var db = new OrderSystemContext())
{
    // This test does not store the sqlite db file in sourcecontrol together with migration data.
    // Instead the database is created from scratch when the project is cleared and recompiled.
    Console.WriteLine("Create sqlite db file if not found...");
    db.Database.EnsureCreated();

    // Add a customer and display the database generated id
    Console.Write("Adding new customer (Justine)... ");
    Customer newJustCustomer = new Customer("Justine", "Sweet");
    db.Customers.Add(newJustCustomer);
    db.SaveChanges();
    Console.WriteLine($"Done. New customer id: {newJustCustomer.Id}");

    // Add a customer and display the database generated id
    Console.Write("Adding new customer (Benjamin)... ");
    Customer newBenCustomer = new Customer("Benjamin", "Fresh");
    db.Customers.Add(newBenCustomer);
    db.SaveChanges();
    Console.WriteLine($"Done. New customer id: {newBenCustomer.Id}");

    // Find the latest Justine customer added.
    Console.Write("Selecting latest Justine customer... ");
    var latestJustineCustomer = db.Customers.Where(c => c.Name == "Justine").OrderByDescending(c => c.Id).First();
    Console.WriteLine($"Done. Found Id: {latestJustineCustomer.Id}");

    // Find the latest Justine customer added.
    Console.Write("Creating new order with latest Justine customer... ");
    Order bicycleOrder = new Order()
    {
        Info = "Order for a new bicycle.",
        BoughtByCustomer = latestJustineCustomer
    };
    db.Orders.Add(bicycleOrder);
    db.SaveChanges();
    Console.WriteLine($"Done. New order Id: {bicycleOrder.Id}");
}
