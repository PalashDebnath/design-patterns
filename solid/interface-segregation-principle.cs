/*
  Demonstration of interface segregation principle(ISP). it is also known as YAGNI(You Aren't Going to Need It) priciple.
  As per ISP an inteface should not contain lot of contract, means if interface has lot of function definition, a class
  implement the inteface might not need all the fuctions, but still it has to implement all the function defined in the inteface

  Here the IMachine is violating interface segregation principle. It has too many contracts. VNormalPrinter do not need to implement
  Scan and Fax methods as they are not supported. Now VNormalPrinter do not know what to do with Scan and Fax methods. Should they
  be implemented or throw error. same follows for PhotoPrinter

  On the other hand IPrinter, IScanner, ISender interfaces follows interface segregation principle.
*/

namespace DesignPatterns.InterfaceSegregationPrinciple;

public enum Dummy { }

public class Document
{
  public Document() { }
}

public interface IMachine
{
  void Print(Document document);
  void Scan(Document document);
  void Fax(Document document);
}

public class VNormalPrinter : IMachine
{
  public void Fax(Document document)
  {
    throw new NotImplementedException();
  }

  public void Print(Document document)
  {
    Console.WriteLine("Normal printer only can print");
  }

  public void Scan(Document document)
  {
    throw new NotImplementedException();
  }
}

public class VPhotoPrinter : IMachine
{
  public void Fax(Document document)
  {
    throw new NotImplementedException();
  }

  public void Print(Document document)
  {
    Console.WriteLine("Photo printer can print");
  }

  public void Scan(Document document)
  {
    Console.WriteLine("Photo printer can scan");
  }
}

public interface IPrinter<T>
{
  T Print();
}

public interface IScanner<T>
{
  T Scan();
}

public interface ISender<T>
{
  T Fax();
  T Mail();
}

public class NormalPrinter : IPrinter<NormalPrinter>
{
  private readonly Document document;
  public NormalPrinter(Document document) { this.document = document; }
  public NormalPrinter Print()
  {
    Console.WriteLine("Normal printer only can print");
    return this;
  }
}

public class PhotoPrinter : IPrinter<PhotoPrinter>, IScanner<PhotoPrinter>
{
  private readonly Document document;
  public PhotoPrinter(Document document) { this.document = document; }
  public PhotoPrinter Print()
  {
    Console.WriteLine("Photo printer can print");
    return this;
  }

  public PhotoPrinter Scan()
  {
    Console.WriteLine("Photo printer can Scan");
    return this;
  }
}

public class AdvancePrinter : IPrinter<AdvancePrinter>, IScanner<AdvancePrinter>, ISender<AdvancePrinter>
{
  private readonly Document document;
  public AdvancePrinter(Document document) { this.document = document; }
  public AdvancePrinter Fax()
  {
    Console.WriteLine("Advance printer can fax");
    return this;
  }

  public AdvancePrinter Mail()
  {
    Console.WriteLine("Advance printer can mail");
    return this;
  }

  public AdvancePrinter Print()
  {
    Console.WriteLine("Advance printer can print");
    return this;
  }

  public AdvancePrinter Scan()
  {
    Console.WriteLine("Advance printer can scan");
    return this;
  }
}

