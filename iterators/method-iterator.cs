/*
  Demonstration of iterator pattern.

  Here we have created couple of extension methods, which will traserve a complete tree, iterating through all the nodes.
*/

namespace DesignPatterns.Iterators;

enum DummyMethod { }

static class Extensions
{
  public static IEnumerable<Node<T>> InorderIterator<T>(this Node<T> current)
  {
    if (current.Left != null)
    {
      foreach (var left in InorderIterator<T>(current.Left))
        yield return left;
    }
    yield return current;
    if (current.Right != null)
    {
      foreach (var right in InorderIterator<T>(current.Right))
        yield return right;
    }
  }

  public static IEnumerable<Node<T>> PreorderIterator<T>(this Node<T> current)
  {
    yield return current;
    if (current.Left != null)
    {
      foreach (var left in PreorderIterator<T>(current.Left))
        yield return left;
    }
    if (current.Right != null)
    {
      foreach (var right in PreorderIterator<T>(current.Right))
        yield return right;
    }
  }

  public static IEnumerable<Node<T>> PostorderIterator<T>(this Node<T> current)
  {
    if (current.Left != null)
    {
      foreach (var left in PostorderIterator<T>(current.Left))
        yield return left;
    }
    if (current.Right != null)
    {
      foreach (var right in PostorderIterator<T>(current.Right))
        yield return right;
    }
    yield return current;
  }
}