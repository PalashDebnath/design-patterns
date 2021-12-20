/*
  Demonstration of Observer Pattern.

  Here we implemented the observer pattern using event. When ever a creature get into play all the existing creature Attach will
  increase by one. And when a creature die/exit the all exiting creature Attack will decrease by 1. 
*/

namespace DesignPatterns.Observers;

enum DummyEnum { }

class Game
{
  public event EventHandler? EnterCreature;
  public event EventHandler? ExitCreature;
  public event EventHandler<Creature>? NotifyCreature;
  public void CallEnterCreater(object sender)
  {
    EnterCreature?.Invoke(sender, EventArgs.Empty);
  }
  public void CallExitCreature(object sender)
  {
    ExitCreature?.Invoke(sender, EventArgs.Empty);
  }
  public void CallNotifyCreature(object sender, Creature creature)
  {
    NotifyCreature?.Invoke(sender, creature);
  }
}

class Creature : IDisposable
{
  public int Attack { get; private set; } = 1;
  private readonly Game game;
  public Creature(Game game)
  {
    this.game = game;
    this.game.EnterCreature += Enter;
    this.game.ExitCreature += Exit;
    this.game.NotifyCreature += Notify;
    this.game.CallEnterCreater(this);
  }
  private void Enter(object? sender, EventArgs eventArgs)
  {
    if (sender != null && sender != this)
    {
      Attack += 1;
      game.CallNotifyCreature(this, (Creature)sender);
    }
  }
  private void Exit(object? sender, EventArgs eventArgs)
  {
    Attack -= 1;
  }
  private void Notify(object? sender, Creature creature)
  {
    if (creature == this)
      Attack += 1;
  }

  public void Dispose()
  {
    game.EnterCreature -= Enter;
    game.ExitCreature -= Exit;
    game.NotifyCreature -= Notify;
    game.CallExitCreature(this);
  }
}