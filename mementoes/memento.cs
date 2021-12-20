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
  private List<Memento> mementoes;
  private int index;
  public decimal Balance { get; private set; }
  public BankAccount(decimal initBalance)
  {
    Balance = initBalance;
    mementoes = new List<Memento>();
    mementoes.Add(new Memento(initBalance));
  }
  public void Deposit(decimal value)
  {
    Balance += value;
    index += 1;
    mementoes.Add(new Memento(Balance));
  }
  public void WithDraw(decimal value)
  {
    Balance -= value;
    index += 1;
    mementoes.Add(new Memento(Balance));
  }
  public void Undo()
  {
    if (index >= 0)
      Balance = mementoes[--index].Balance;
  }
  public void Redo()
  {
    if (index < mementoes.Count)
      Balance = mementoes[++index].Balance;
  }
}