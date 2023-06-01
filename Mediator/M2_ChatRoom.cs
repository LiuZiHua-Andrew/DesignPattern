public class Person
{
  public string Name;
  public ChatRoom Room;
  
  private List<string> chatLog = new List<string>();
  
  public Person(string name)
  {
    Name = name;
  }
  
  public void Say(string msg)
  {
    Room.Broadcast(Name, msg);
  }
  
  public void PrivateMessage(string who, string message)
  {
    Room.Message(Name, who, message);
  }
  
  public void Receive(string sender, string msg)
  {
    string s = $"{sender}: '{message}'";
    chatLog.Add(d);
    WriteLine($"[{Name}'s chat session] {s}");
  }
}

/*
Here the ChatRoom class plays the role of mediator,
when Person tries to talk to another Person, they are not actually aware of other's
*/
public class ChatRoom
{
  private List<Person> people = new List<Person>();
  
  public void Join(Person p)
  {
    string joinMsg = $"{p.Name} joins the chat";
    Broadcast("room", joinMsg);
    
    p.Room = this;
    people.Add(p);
  }
  
  public void Broadcast(string source, string message)
  {
      foreach (var p in people)
      {
        if(p.Name != source)
        {
          p.Receive(source, message);
        }
      }
  }
  
  public void Message(string source, string destination, string message)
  {
    people.FirstOrDefault(p => p.Name == destination)?.Receive(source, message);
  }
}

public class Demo
{
  static void Main(string[] args)
  {
    var room = new ChatRoom();
    
    var john = new Person("John");
    var jane = new Person("Jane");
    
    room.Join(john);
    room.Join(jane);
    
    john.Say("hi");
    jane.Say("oh, hey john");
    
    var simon = new Person("simon");
    room.Join(simon);
    simon.Say("hi everyone!");
    
    jane.PrivateMessage("simon", "glas you are here");
  }
}