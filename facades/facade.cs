/*
  Demonstration of Facade Design Pattern. Facade work as an wrapper which hides all the complexity of the sub subsystems and open
  up an easy interface to outer world.

  Here we have a Order class which has a simple method PlaceOrder. The Order class work as a facade for the Product, Payment &
  Invoice sub systems.
*/

namespace DesignPatterns.Facades;

enum Facades { }

class Product
{
  public void GetProductDetail()
  {
    Console.WriteLine("Fetching the product details.");
  }
}

class Payment
{
  public void MakePayment()
  {
    Console.WriteLine("Payment done successfully.");
  }
}

class Invoice
{
  public void SendInvoice()
  {
    Console.WriteLine("Invoice send successfully.");
  }
}

class Order
{
  public void PlaceOrder()
  {
    var product = new Product();
    var payment = new Payment();
    var invoice = new Invoice();

    product.GetProductDetail();
    payment.MakePayment();
    invoice.SendInvoice();
  }
}