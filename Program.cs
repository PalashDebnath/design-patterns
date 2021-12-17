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
advancePrinter.Print().Lookup().Fax().Mail(); */

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
/* var origin = Configuration.Instance;
var configurations = origin.Read();
foreach (var config in configurations)
{
  Console.WriteLine($"Key: {config.Key}, Value: {config.Value}");
}
var clone = Configuration.Instance;
Console.WriteLine($"origin object hash code: {origin.GetHashCode()}, clone object hash code: {clone.GetHashCode()}"); */

// Adapter Patterns
/* Line line = new Line(new Point(1, 6), new Point(6, 10));
var pointPrinterAdapter = new PointPrinterAdapter();
Console.WriteLine(line);
pointPrinterAdapter.Adapt(line);
Console.WriteLine();

List<Tuple<int, string, string, int>> employees = new List<Tuple<int, string, string, int>>();
employees.Add(Tuple.Create(101, "John", "SE", 10000));
employees.Add(Tuple.Create(102, "Smith", "SE", 20000));
employees.Add(Tuple.Create(103, "Dev", "SSE", 30000));
employees.Add(Tuple.Create(104, "Pam", "SE", 40000));
EmployeeBillingAdapter employeeBillingAdapter = new EmployeeBillingAdapter();
employeeBillingAdapter.Adapt(employees); */

// Bridge Patterns
/* Shape rectangle = new Rectangle(new VectorPainter());
Shape tringle = new Tringle(new RasterPainter());
rectangle.Draw();
tringle.Draw(); */

// Composite Patterns
/* var products = new List<Product>();
products.Add(new Product("Apple", Size.SMALL, Color.GREEN));
products.Add(new Product("Tree", Size.EXTRALARGE, Color.GREEN));
products.Add(new Product("Pumkin", Size.LARGE, Color.RED));
products.Add(new Product("Cucumber", Size.MEDIUM, Color.GREEN));

var filter = new ProductFilter();
var compositeSpecification = new CompositeSpecification();
compositeSpecification.Specifications.Add(new ColorSpecification(Color.GREEN));
compositeSpecification.Specifications.Add(new SizeSpecification(Size.MEDIUM));
var filteredProducts = filter.Filter(products, compositeSpecification);

foreach (Product product in filteredProducts)
{
  Console.WriteLine(product.ToString());
} */

// Decorator Patterns
/* Beverage expresso = new Expresso(2);
IAdjunct<Beverage> adjunct = new Sugar();
adjunct.AddWith(expresso);
adjunct = new Caramel();
adjunct.AddWith(expresso);
Console.WriteLine(expresso); */

// Facade Patterns
/* Order order = new Order();
order.PlaceOrder(); */

// Flyweight Patterns
/* ShapeCache shapeCache = new ShapeCache();
var shape = shapeCache.Lookup(ShapeType.Circle);
shape.SetColor("Red");
shape.Draw();
shape = shapeCache.Lookup(ShapeType.Circle);
shape.SetColor("Green");
shape.Draw();
shape = shapeCache.Lookup(ShapeType.Circle);
shape.SetColor("Orange");
shape.Draw();
shape = shapeCache.Lookup(ShapeType.Square);
shape.SetColor("Red");
shape.Draw();
shape = shapeCache.Lookup(ShapeType.Square);
shape.SetColor("Green");
shape.Draw();
shape = shapeCache.Lookup(ShapeType.Square);
shape.SetColor("Orange");
shape.Draw(); */

// Proxy Patterns
/* var palash = new Employee("palashdebnath", "test@1234", "Palash Debnath", Designation.Developer);
var subrata = new Employee("subratasarkar", "test@1234", "Subrata Sarkar", Designation.Manager);
var operationProxy = new OpeartionProxy(palash);
operationProxy.Read();
operationProxy.Write();
operationProxy = new OpeartionProxy(subrata);
operationProxy.Read();
operationProxy.Write(); */

// Chain Of Responsibility Patterns
/* Dispatcher twoThousandRupeeNoteDispatcher = new TwoThousandRupeeNote();
Dispatcher fiveHundredRupeeNoteDispatcher = new FiveHundredRupeeNote();
Dispatcher twoHundredRupeeNoteDispatcher = new TwoHundredRupeeNote();
Dispatcher oneHundredRupeeNoteDispatcher = new OneHundredRupeeNote();
twoThousandRupeeNoteDispatcher.NextDispatcher(fiveHundredRupeeNoteDispatcher);
fiveHundredRupeeNoteDispatcher.NextDispatcher(twoHundredRupeeNoteDispatcher);
twoHundredRupeeNoteDispatcher.NextDispatcher(oneHundredRupeeNoteDispatcher);
ATM atm = new ATM(twoThousandRupeeNoteDispatcher);
atm.WithDraw(4600);
atm.WithDraw(4800); */

// Command Patterns
/* var account = new Account();
var commands = new List<AccountCommand>();
commands.Add(new AccountCommand(account, Command.Deposit, 100));
commands.Add(new AccountCommand(account, Command.Withdraw, 150));

foreach (var command in commands)
{
  command.Call();
}

foreach (var command in Enumerable.Reverse(commands))
{
  command.Undo();
} */

// Iterator Patterns
/* var tree = new Node<int>(1, new Node<int>(2, new Node<int>(4), new Node<int>(5)), new Node<int>(3, new Node<int>(6), new Node<int>(7)));
var inOrderIterator = new InorderIterator<int>(tree);
while (inOrderIterator.MoveNext())
  Console.Write($"{inOrderIterator.Current?.Value} ");
Console.WriteLine();
foreach (var node in tree.InorderIterator<int>())
{
  Console.Write($"{node.Value} ");
}
Console.WriteLine();
foreach (var node in tree.PreorderIterator<int>())
{
  Console.Write($"{node.Value} ");
}
Console.WriteLine();
foreach (var node in tree.PostorderIterator<int>())
{
  Console.Write($"{node.Value} ");
} */

// Interpreter Patterns
/* var interpreter = new Interpreter();
var value = interpreter.Evaluate("1 + 2 * 5 / 10 % 2 * 20");
Console.WriteLine(value);
value = interpreter.Evaluate("(13+4)-(12+1)");
Console.WriteLine(value); */

// Memento Patterns
/* var ba = new BankAccount(100);
Console.WriteLine($"Balance: ${ba.Balance}");
ba.Deposit(100);
Console.WriteLine($"Balance: ${ba.Balance}");
ba.WithDraw(25);
Console.WriteLine($"Balance: ${ba.Balance}");
ba.Undo();
Console.WriteLine($"Balance: ${ba.Balance}");
ba.Redo();
Console.WriteLine($"Balance: ${ba.Balance}"); */

// Null-Object Patterns
/* var ba = new BankAccount(new CLog());
ba.Deposit(100);
ba.Deposit(200);
ba.Withdraw(50);
var ba2 = new BankAccount(SNLog.Instance);
ba2.Deposit(100);
ba2.Deposit(100);
ba2.Withdraw(75);
Console.WriteLine(ba2.Balance); */

// Strategy Patterns
/* var lp = new ListProcesser();
lp.SetFormat(Format.Markdown);
lp.AddItems(new List<string>() { "foo", "bar", "baz" });
Console.WriteLine(lp);
lp.Clear();
lp.SetFormat(Format.Html);
lp.AddItems(new List<string>() { "foo", "bar", "baz" });
Console.WriteLine(lp);

var payment = new Payment<CreditCardStrategy>();
payment.Pay(700); */

// Template Method Patterns
/* House house = new ConcreteHouse();
house.Build();
house = new WoodenHouse();
house.Build(); */




