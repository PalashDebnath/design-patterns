/*
  Demonstration of dynamic strategy pattern. We can have several solution to a problem. Dynamic strategy pattern used when we have multiple solution to a problem at client
  has the flexibility to choose a solution at run time interchangeably. The importent concept of strategy pattern is all the
  solutions are encapsulated and interchangeable.

  Here we going to implement a strategy to print list of items in different format.
*/

namespace DesignPatterns.Strategies;

enum Format { Markdown, Html }

interface IListStrategy
{
  void Start(StringBuilder sb);
  void End(StringBuilder sb);
  void AddItem(StringBuilder sb, string item);
}

class MarkdownStrategy : IListStrategy
{
  public void AddItem(StringBuilder sb, string item)
  {
    sb.AppendLine($"  * {item}");
  }

  public void End(StringBuilder sb)
  {
    sb.AppendLine("}");
  }

  public void Start(StringBuilder sb)
  {
    sb.AppendLine("{");
  }
}

class HtmlStrategy : IListStrategy
{
  public void AddItem(StringBuilder sb, string item)
  {
    sb.AppendLine($"  <li>{item}</li>");
  }

  public void End(StringBuilder sb)
  {
    sb.AppendLine("</ui>");
  }

  public void Start(StringBuilder sb)
  {
    sb.AppendLine("<ui>");
  }
}

class ListProcesser
{
  private StringBuilder _sringBuilder = new StringBuilder();
  private IListStrategy? _listStrategy;
  public void SetFormat(Format format)
  {
    switch (format)
    {
      case Format.Markdown:
        _listStrategy = new MarkdownStrategy();
        break;
      case Format.Html:
        _listStrategy = new HtmlStrategy();
        break;
      default:
        throw new ArgumentNullException();
    }
  }
  public void AddItems(List<string> items)
  {
    _listStrategy?.Start(_sringBuilder);
    foreach (var item in items)
    {
      _listStrategy?.AddItem(_sringBuilder, item);
    }
    _listStrategy?.End(_sringBuilder);
  }
  public void Clear()
  {
    _sringBuilder.Clear();
  }

  public override string ToString()
  {
    return _sringBuilder.ToString();
  }
}
