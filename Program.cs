// See https://aka.ms/new-console-template for more information

//Single Responsibility principle
Journal journal = new Journal();
journal.AddEntry("This is single responsibility principle.");
journal.AddEntry("It's also known as separation of concern.");
Disk.Save(journal.ToString());

//Open Close Pricipal
List<Product> products = new List<Product>();
products.Add(new Product("Apple", Size.SMALL, Color.GREEN));
products.Add(new Product("Tree", Size.EXTRALARGE, Color.GREEN));
products.Add(new Product("Pumkin", Size.LARGE, Color.RED));
products.Add(new Product("Cucumber", Size.MEDIUM, Color.GREEN));

ProductFilter filter = new ProductFilter();
ColorSpecification colorSpec = new ColorSpecification(Color.GREEN);
IEnumerable<Product> filteredProducts = filter.Filter(products, colorSpec);

foreach (Product product in filteredProducts)
{
  Console.WriteLine(product.ToString());
}

//liskov substitution principle
Shape shape = new Shape(10, 20);
Console.WriteLine(shape.ToString());
Shape square = new Square(5);
Console.WriteLine(square.ToString());
Fruit fruit = new Apple(2);
Console.WriteLine(fruit.GetDetails());
fruit = new Orange(3);
Console.WriteLine(fruit.GetDetails());

//interface segregation principle
AdvancePrinter advancePrinter = new AdvancePrinter(new Document());
advancePrinter.Print().Scan().Fax().Mail();

//dependency inversion principle
EmployeeBusiness employeeBusiness = new EmployeeBusiness();
Employee employee = employeeBusiness.GetEmployeeDetails(1);
Console.WriteLine(employee.ToString());
