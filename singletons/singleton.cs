/*
  Demonstration of singleton disign pattern. As per singleton a class can be instantiate only once.
*/

namespace DesignPatterns.singletons;

enum Dummy { }

public interface IConfigurationProvider
{
  Dictionary<string, string> Fetch();
}

// As configurations are static values, they will not change.
// Hence to read them from a file and service as a singleton obejct is logical.
public class Configuration : IConfigurationProvider
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
  public Dictionary<string, string> Fetch()
  {
    return configurations;
  }

  // The use of Lazy will help to hold the creation of configuration object until it has been request for.
  // When the Instance property will be call explicitly, it will call the _instance.Value property implicitly,
  // which internally gonna call the func delegate of lazy constructor and Configuration object will be instantiated
  // In addition it is also thread safe.
  private static Lazy<Configuration> _instance = new Lazy<Configuration>(() => new Configuration());
  public static Configuration Instance => _instance.Value;
}