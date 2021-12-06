namespace DesignPatterns.Adapters;

enum Common { }

public interface IAdapter<T>
{
  void Adapt(T t);
}