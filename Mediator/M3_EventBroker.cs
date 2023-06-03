
public class Actor
{
  
}

public class FootballPlayer : Actor
{
  
}

public class Footballcoatch : Actor
{
  
}

public class PlayerEvent
{
  public string Name {get;set;}
}

public class PlayerscoredEvent
{
  public int GoalsScored {get;set;}
}

public class PlayerSentOffEVent
{
  public string Reason {get;set;}
}

//Mediator
public class EventBroker : IObservable<PlayerEvent>
{
  
}

static class Program
{
  private static void Main()
  {
    
  }
}