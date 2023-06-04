/*
Async invocation cannot happen everywhere, it can happen in the method but not constructor
With this limitation, it becomes a problem when you want to do an async initialization
*/

public class Foo
{
  //Below code is not allowed
  // public Foo()
  // {
  //   await Task.Delay(1000);
  // }
  
  
  /*
  This would do the job, but it increases the complexity of using it
  1. var foo = new Foo(); -- you need to initialize the constructor
  2. await foo.InitAsync(); -- then you need to init
  */
  public async Task<Foo> InitAsync()
  {
    await Task.Delay(1000);
    return this;
  }
}

public class FooFactory
{
  private FooFactory()
  {
    
  }
  
  private async Task<FooFactory> InitAsync()
  {
    await Task.Delay(1000);
    return this;
  }
  
  public static Task<FooFactory> CreateAsync()
  {
    var result = new FooFactory();
    return result.InitAsync();
  }
  
}

main()
{
  FooFactory foo = await Foo.CreateAsync(); //Easy to use
}