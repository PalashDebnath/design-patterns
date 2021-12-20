/*
  Demonstration of singleton disign pattern. As per singleton a class can be instantiate only once.
*/

namespace DesignPatterns.Singletons;

enum Dummy { }

public interface ICommand
{
  Dictionary<string, string> Read();
}

// As configurations are static values, they will not change.
// Hence to read them from a file and service as a singleton obejct is logical.
public class Configuration : ICommand
{
  private Dictionary<string, string> configurations;
  // stop instantiation by making the constructor private
  private Configuration()
  {
    Console.WriteLine("Read the config file.");
    Console.WriteLine("Load all the configurations in the private field.");
    configurations = new Dictionary<string, string>();
    configurations.Add("dev", "development");
    configurations.Add("tst", "testing");
    configurations.Add("acc", "acceptance");
    configurations.Add("prod", "production");
  }
  public Dictionary<string, string> Read()
  {
    return configurations;
  }

  // The use of Lazy will help to hold the creation of configuration object until it has been request for.
  // When the Instance property will be call explicitly, it will call the instance.Value property implicitly,
  // which internally gonna call the func delegate of lazy constructor and Configuration object will be instantiated
  // In addition it is also thread safe.
  private static Lazy<Configuration> instance = new Lazy<Configuration>(() => new Configuration());
  public static Configuration Instance => instance.Value;
}