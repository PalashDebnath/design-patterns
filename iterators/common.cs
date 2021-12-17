/*
  Demonstration of iterator pattern.
*/

namespace DesignPatterns.Iterators;

enum DummyCommon { }

public class Node<T>
{
  public T Value { get; private set; }
  public Node<T>? Left { get; private set; }
  public Node<T>? Right { get; private set; }
  public Node<T>? Parent { get; private set; }
  public Node(T value)
  {
    Value = value;
  }
  public Node(T value, Node<T> left, Node<T> right)
  {
    Value = value;
    Left = left;
    Right = right;
    Left.Parent = Right.Parent = this;
  }

}