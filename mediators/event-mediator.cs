/*
  Demonstration of Mediator design pattern. using event driven approch

  Here we have a Mediator class which will Transmit a message to all other Participants when a participant write something.
*/

namespace DesignPatterns.Mediators;

enum Dummy { }

class Participant
{
  private Mediator mediator;
  public string Name { get; private set; }
  public Participant(Mediator mediator, string name)
  {
    Name = name;
    this.mediator = mediator;
    this.mediator.Message += Message;
  }
  public void Write(string message)
  {
    mediator.Transmit(this, message);
  }

  public override string ToString()
  {
    return Name;
  }
  private void Message(object? sender, string message)
  {
    if (sender != this)
      Console.WriteLine($"[{Name}'s session] {sender}'s message## {message}");
  }
}

public class Mediator
{
  public event EventHandler<string>? Message;
  public void Transmit(object sender, string message)
  {
    Message?.Invoke(sender, message);
  }
}
