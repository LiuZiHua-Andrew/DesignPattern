
public class Actor
{
  protected EventBroker broker;
  
  pblic Actor(EventBroker broker)
  {
    this broker = broker;
  }
}

public class FootballPlayer : Actor
{
  public FootballPlayer(EventBroker broker) : base(broker)
  {
    
  }
}

public class Footballcoatch : Actor
{
  public Footballcoatch(EventBroker broker) : base(broker)
  {
    //Filter out PlayerscoredEvent from all IObservable event then pipe into some actions
    broker.OfType<PlayerscoredEvent>().Subscribe(pe => 
    {
      if(pe.GoalsScored < 3)
      {
        WriteLine($"Coach: well done, {pe.Name}");
      }
    });
  }
}

public class PlayerEvent
{
  public string Name {get;set;}
}

public class PlayerscoredEvent : PlayerEvent
{
  public int GoalsScored {get;set;}
}

public class PlayerSentOffEVent : PlayerEvent
{
  public string Reason {get;set;}
}

//Mediator
public class EventBroker : IObservable<PlayerEvent>
{
  private Subject<PlayerEvent> subscriptions = new Subject<PlayerEvent>();
  
  public IDisposable Subscribe(IObservable<PlayerEvent> observer)
  {
    return subscriptions.Subscribe(observer);
  }
  
  public void Publish(PlayerEvent pe)
  {
    subscriptions.OnNext(pe);
  }
}

static class Program
{
  private static void Main()
  {
    
  }
}