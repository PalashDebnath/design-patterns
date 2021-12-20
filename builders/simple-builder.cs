/*
  Implementation of a fluent builder pattern. it called fluent because the methods can be chained
*/

namespace DesignPatterns.Builders;

enum simple { }

public class Property
{
  public string name;
  public string type;
  public Property(string name, string type)
  {
    this.name = name;
    this.type = type.ToLower();
  }

  public override string ToString()
  {
    return $"public {type} {name};";
  }
}

public class Class
{
  public string name;
  public List<Property> properties;
  public Class? innerClass;
  private const int INDENTSIZE = 2;
  public Class(string name) { this.name = name; this.properties = new List<Property>(); }

  public override string ToString()
  {
    return Content(0);
  }
  private string Content(int indent)
  {
    StringBuilder sb = new StringBuilder();
    sb.AppendLine($"{new string(' ', INDENTSIZE * indent)}public class {name}");
    sb.AppendLine($"{new string(' ', INDENTSIZE * indent)}{{");
    foreach (Property property in properties)
    {
      sb.AppendLine($"{new string(' ', INDENTSIZE * (indent + 1))}{property.ToString()}");
    }
    if (innerClass != null) sb.Append(innerClass.Content(indent + 1));
    sb.AppendLine($"{new string(' ', INDENTSIZE * indent)}}}");
    return sb.ToString();
  }
}

public class ClassBuilder
{
  private string rootName;
  public Class root { get; private set; }
  public ClassBuilder(string rootName) { this.rootName = rootName; root = new Class(rootName); }
  public ClassBuilder AddField(string name, string type)
  {
    root.properties.Add(new Property(name, type));
    return this;
  }
  public ClassBuilder AddField(Class? parent, string name, string type)
  {
    if (parent == null) throw new ArgumentNullException($"No parent found to add filed: {name}");
    parent.properties.Add(new Property(name, type));
    return this;
  }
  public ClassBuilder AddInnerClass(Class? parent, string name)
  {
    if (parent == null) throw new ArgumentNullException($"No parent found to add inner class: {name}");
    parent.innerClass = new Class(name);
    return this;
  }
  public Class Build()
  {
    return root;
  }
  public void Clear()
  {
    root = new Class(rootName);
  }
}