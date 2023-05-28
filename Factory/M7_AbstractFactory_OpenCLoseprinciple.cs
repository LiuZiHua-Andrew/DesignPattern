public interface IHotDrink 
{
  void Consume();
}

internal class Tea : IHotDrink
{
  public void Consume()
  {
    //xxx 
  }
}

internal class Coffee : IHotDrink
{
  public void Consume()
  {
    //xxx
  }
}

public interface IHotDrinkFactory
{
  IHotDrink Prepare(int amount);
}

internal class TeaFactory : IHotDrinkFactory
{
  public IHotDrink Prepare(int amount)
  {
    // amount
    return new Tea();
  }
}

internal class CoffeeFactory : IHotDrinkFactory
{
  public IHotDrink Prepare(int amount)
  {
    // amount
    return new Coffee();
  }
}

public class HotDrinkMachine
{
  //Why commented out? break of Open close principal, in order to extend it, we need to update the enum all the time.
  // public enum AvailableDrink 
  // {
  //   Coffee, Tea
  // }
  
  // private Dictionary<AvailableDrink, IHotDrinkFactory> factories = new Dictionary<AvailableDrink, IHotDrinkFactory>();
  
  // public HotDrinkMachine()
  // {
  //   foreach (AvailableDrink drink in Enum.GetValue(typeof(AvailableDrink)))
  //   {
  //     //Similar doing a DI for different type of drink with different type of factory
  //     var factory = (IHotDrinkFactory)Activator.CreateInstance(Type.GetType("DesignPatterns." + Enum.GetName(typeof(AvailableDrink), drink) + "Factory"));
  //     factories.Add(drink, factory);
  //   }
  // }
  
  // public IHotDrink MakeDrink(AvailableDrink drink, int amount)
  // {
  //   return factories[drink].Prepare(amount);
  // }
  
  private List<Tuple<string, IHotDrinkFactory>> factories = new List<Tuple<string, IHotDrinkFactory>>();
  
  public HotDrinkMachine()
  {
    foreach(var VARIABLE in typeof(HotDrinkMachine).Assembly.GetTypes())
    {
      if(typeof(IHotDrinkFactory).IsAssignableFrom(t) && !t.IsInterface)
      {
        factories.Add(Tuple.Create(
           t.Name.Replace("Factory", string.Empty),
           (IHotDrinkFactory)Activator.CreateInstance(t)
          ));
      }
    }
  }
  
  public IHotDrink MakeDrink()
  {
    //list available drinks
    for(var index = 0; index < factories.Count; index++)
    {
      var tulple = factories[index];
    }
    
    //Using user cmd input
    while(true)
    {
      string s;
      if((s = Console.ReadLine()) != null 
          && int.TryParse(s, out int i) 
          && i >= 0 
          && i< factories.Count)
      {
        //Get amount
        s = ReadLine();
        
        if(s != null && int.TryParse(s, out int amount) && amount > 0)
        {
          return factories[i].Item2.Prepare(amount);
        }
      }
    }
  }
}

static void Main()
{
  var machine = new HotDrinkMachine();
  var drink = machine.MakeDrine(HotDrinkMachine.AvailableDrink.Tea, 100);
  drink.Consume();
}