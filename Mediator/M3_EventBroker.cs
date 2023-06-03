
public class Actor
{
  protected EventBroker broker;
  
  pblic Actor(EventBroker broker)
  {
    this broker = broker;
  }
}

/*
FootballPlayer has no dependency with other FootballPlayer and Footballcoatch,
All communication is via Mediator/IObservable here
*/
public class FootballPlayer : Actor
{
  public string Name {get; set;}
  public int GoalsScored {get; set;} = 0;
  
  public FootballPlayer(EventBroker broker, string name) : base(broker)
  {
    Name = name;
    
    broker.OfType<PlayerscoredEvent>()
      .Where(ps => !ps.Name.Equals(name))
      .Subscribe(
        ps => WriteLine($"{name}: Nicely done, {ps.Name}! It's your {ps.GoalsScored}.")
      );
      
    broker.OfType<PlayerSentOffEVent>()
      .Where(ps => !ps.Name.Equals(name))
      .Subscribe(
        ps => WriteLine($"${name}: see you in the lockers, {ps.Name}");  
      )
  }
  
  //Becuase all of them have the broker reference, so defining what event to send and what postaction to do will be located in its own class
  public void Score()
  {
    GoalsScored ++;
    
    broker.Publish(new PlayerscoredEvent
    {
      Name = name,
      GoalsScored = GoalsScored,
    });
  }
  
  public void AssultReferee()
  {
    broker.Publish(new PlayerSentOffEVent
    {
      Name = name,
      Reason = "violence"
    });
  }
}

/*
Footballcoatch has no dependency with other FootballPlayer and Footballcoatch,
All communication is via Mediator/IObservable here
*/
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
    
    broker.OfType<PlayerSentOffEVent>().Subscribe(pe =>
    {
      if(pe.Reason == 'violence')
      {
        WriteLine($"Coach: how could you, {pe.Name}.");
      }
    })
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

//Mediator, a small demo to setup event bus/event broker
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
    var cb = new ContainerBuilder();
    cb.RegisterType<EventBroker>().SingleInstance();
    cb.RegisterType<Footballcoatch>();
    
    //https://autofac.readthedocs.io/en/latest/register/registration.html#selection-of-an-implementation-by-parameter-value
    //The concrete will be decided when name is provided, but the EventBroker has been fixed here
    cb.Register((c, p) => new FootballPlayer(c.Resolve<EventBroker>(), p.Name<string>("name")));
    
    using(var c = cb.Build())
    {
      var coach = c.Resolve<Footballcoatch>();
      var player1 = c.Resolve<FootballPlayer>(new NamedParameter("name", "John"));
      var player2 = c.Resolve<FootballPlayer>(new NamedParameter("name", "Chris"));
      
      player1.Score();
      player1.Score();
      player1.Score();
      
      player1.AssultReferee();
      player2.Score();
    }
  }
}