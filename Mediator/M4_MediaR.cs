using MediatR;

//Generic type here is just the response of the command
public class Pingcommand : IRequest<PongResponse>
{
  
}

public class PongResponse
{
  public DateTime Timestamp;
  public PongResponse(DateTime timestamp)
  {
    Timestamp = timestamp;
  }
}
/*
The handler is not instantiated anywhere and will not be done. The actual work will be handled by the library in DI
*/
[Usedimplicitly] //just to avoid the warning about not instantiating the class anywhere
public PingCommandHandler : IRequestHandler<PingCommand, PongResponse>
{
  public async Task<PongResponse> Handle(PingCommand request, CancellationToken cancellationToken)
  {
    return await Task.FromResult(new PongResponse(DateTime.UtcNow)).ConfigureAwait(false);
  }
}

internal class Program
{
  public static async Task Main(string[] args)
  {
    var builder = new ContainerBuilder();
    builder.RegisterType<Mediator>()
      .As<IMediator>()
      .InstanceperlifetimeScope(); //Singleton
      
    builder.Register<ServiceFactory>(ctx => 
    {
      var c = ctx.Resolve<IComponentContext>(); //From autofact
      return t => c.Resolve(t); //Return a lambda that resolve any type it passed
    });
    
    builder.RegisterassemblyTypes(typeof(Program).Assembly)
      .AsImplementedInterfaces(); //For all interfaces, register their implementation
      
    var container = builder.Build();
    var mediator = container.Resolve<IMediator>();
    
    var response = await mediator.Send(new PingCommand());
    Console.WriteLine($"We got a response at {reponse.Timestamp}");
  }
}