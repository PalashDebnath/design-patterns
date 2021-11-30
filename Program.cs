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

//Builder patterns
ClassBuilder codeBuilder = new ClassBuilder("Person");
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
Console.WriteLine(person);


