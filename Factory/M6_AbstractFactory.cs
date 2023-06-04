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
  public enum AvailableDrink 
  {
    Coffee, Tea
  }
  
  private Dictionary<AvailableDrink, IHotDrinkFactory> factories = new Dictionary<AvailableDrink, IHotDrinkFactory>();
  
  public HotDrinkMachine()
  {
    foreach (AvailableDrink drink in Enum.GetValue(typeof(AvailableDrink)))
    {
      //Similar doing a DI for different type of drink with different type of factory
      var factory = (IHotDrinkFactory)Activator.CreateInstance(Type.GetType("DesignPatterns." + Enum.GetName(typeof(AvailableDrink), drink) + "Factory"));
      factories.Add(drink, factory);
    }
  }
  
  public IHotDrink MakeDrink(AvailableDrink drink, int amount)
  {
    return factories[drink].Prepare(amount);
  }
}

static void Main()
{
  var machine = new HotDrinkMachine();
  var drink = machine.MakeDrine(HotDrinkMachine.AvailableDrink.Tea, 100);
  drink.Consume();
}