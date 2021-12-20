/*
  Demonstration of iterator pattern.

  Here we consider only the in-order binary tree traversal. We implement a object to Itarate through the binary tree and traverse
  all the nodes.
*/

namespace DesignPatterns.Iterators;

enum Dummy { }

interface IIterator
{
  bool MoveNext();
  void Reset();
}

class InorderIterator<T> : IIterator
{
  private readonly Node<T> root;
  public Node<T>? Current { get; set; }
  public InorderIterator(Node<T> root)
  {
    this.root = root;
  }
  public bool MoveNext()
  {
    if (Current == null)
    {
      Current = root;
      while (Current.Left != null)
        Current = Current.Left;
      return true;
    }
    if (Current.Right != null)
    {
      Current = Current.Right;
      while (Current.Left != null)
        Current = Current.Left;
      return true;
    }
    else
    {
      var currentParent = Current.Parent;
      while (currentParent != null && currentParent.Right == Current)
      {
        Current = currentParent;
        currentParent = Current.Parent;
      }
      Current = currentParent;
      return Current != null;
    }
  }
  public void Reset()
  {
    Current = null;
  }
}