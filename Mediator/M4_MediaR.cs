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
[Usedimplicitly]
public PingCommandHandler : IRequestHandler<PingCommand, PongResponse>
{
  public async Task<PongResponse> Handle(PingCommand request, CancellationToken cancellationToken)
  {
    return await Task.FromResult(new PongResponse(DateTime.UtcNow)).ConfigureAwait(false);
  }
}