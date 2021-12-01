// See https://aka.ms/new-console-template for more information

// Single Responsibility Principle
/* Journal journal = new Journal();
journal.AddEntry("This is single responsibility principle.");
journal.AddEntry("It's also known as separation of concern.");
Disk.Save(journal.ToString()); */

// Open Close Priciple
/* List<Product> products = new List<Product>();
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
} */

// Liskov Substitution Principle
/* Shape shape = new Shape(10, 20);
Console.WriteLine(shape.ToString());
Shape square = new Square(5);
Console.WriteLine(square.ToString());
Fruit fruit = new Apple(2);
Console.WriteLine(fruit.GetDetails());
fruit = new Orange(3);
Console.WriteLine(fruit.GetDetails()); */

// Interface Segregation Principle
/* AdvancePrinter advancePrinter = new AdvancePrinter(new Document());
advancePrinter.Print().Scan().Fax().Mail(); */

// Dependency Inversion Principle
/* EmployeeBusiness employeeBusiness = new EmployeeBusiness();
Employee employee = employeeBusiness.GetEmployeeDetails(1);
Console.WriteLine(employee.ToString()); */

// Builder Patterns
/* ClassBuilder codeBuilder = new ClassBuilder("Person");
var code = codeBuilder
                .AddField("Name", "string")
                .AddField("Age", "int")
                .AddInnerClass(codeBuilder.root, "Address")
                .AddField(codeBuilder.root.innerClass, "Street", "string")
                .Build();
Console.WriteLine(code);

CarBuilder carBuilder = new CarBuilder();
Car car = carBuilder.SetCar().OfType(CarType.SEDAN).HasWeelSize(16).Build();
Console.WriteLine(car);

DrinkBuilder drinkBuilder = new DrinkBuilder();
var drink = drinkBuilder.Start("coco-cola").Type(DrinkType.COLD).Size(DrinkSize.MEDIUM).Prepare();
Console.WriteLine(drink);

PersonBuilder personBuilder = new PersonBuilder();
Person person = personBuilder
                  .Lives
                    .At("Masidhati Road")
                    .In("Barasat")
                    .WithPostCode("700124")
                  .Works
                    .At("Tata Consultancy Services")
                    .AsA("Engineer")
                    .OfPackage(900000);
Console.WriteLine(person); */

// Factory Patterns
// Point cartesian = Point.Factory.Cartesian(3.4, 5.3);
// Point polar = Point.Factory.Polar(3, 5);
// Console.WriteLine(cartesian);
// Console.WriteLine(polar);

// HotDrinkMachine machine = new HotDrinkMachine();
// machine.MakeDrink();

// Prototype Patterns
/* Employee john = new Employee("John Doe", new Address("London Lane 24", "London", "England"));
Employee jane = new Employee(john);
jane.FullName = "Jane Doe";
jane.Address.Street = "New York Lane 25";
jane.Address.City = "New York";
jane.Address.Country = "USA";
Console.WriteLine(jane);
Console.WriteLine(john);

Line line = new Line(new Point(2, 3), new Point(6, 7));
Line newLine = line.DeepClone();
newLine.Start.X = 3;
newLine.Start.Y = 2;
newLine.End.X = 7;
newLine.End.Y = 6;
Console.WriteLine(newLine);
Console.WriteLine(line);

Person palash = new Person("Palash Debnath", new Residence("London Lane 24", "London", "England"));
Person subrata = palash.DeepClone();
subrata.FullName = "Subrata Sarkar";
subrata.Residence.Street = "New York Lane 25";
subrata.Residence.City = "New York";
subrata.Residence.Country = "USA";
Console.WriteLine(subrata);
Console.WriteLine(palash); */

//Singleton Patterns
var origin = Configuration.Instance;
var configurations = origin.Fetch();
foreach (var config in configurations)
{
  Console.WriteLine($"Key: {config.Key}, Value: {config.Value}");
}
var clone = Configuration.Instance;
Console.WriteLine($"origin object hash code: {origin.GetHashCode()}, clone object hash code: {clone.GetHashCode()}");


