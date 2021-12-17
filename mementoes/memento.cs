/*
  Demonstration of Memento Pattern.

  Here we will create a memento which snapshot and store a moment and help to get back to that particular moment. We are going to
  use the classic bank account exaple over here.
*/

namespace DesignPatterns.Mementoes;

enum Dummy { }

public class Memento
{
  public decimal Balance { get; }
  public Memento(decimal balance)
  {
    Balance = balance;
  }
}

public class BankAccount
{
  private List<Memento> _mementoes;
  private int _index;
  public decimal Balance { get; private set; }
  public BankAccount(decimal initBalance)
  {
    Balance = initBalance;
    _mementoes = new List<Memento>();
    _mementoes.Add(new Memento(initBalance));
  }
  public void Deposit(decimal value)
  {
    Balance += value;
    _index += 1;
    _mementoes.Add(new Memento(Balance));
  }
  public void WithDraw(decimal value)
  {
    Balance -= value;
    _index += 1;
    _mementoes.Add(new Memento(Balance));
  }
  public void Undo()
  {
    if (_index >= 0)
      Balance = _mementoes[--_index].Balance;
  }
  public void Redo()
  {
    if (_index < _mementoes.Count)
      Balance = _mementoes[++_index].Balance;
  }
}