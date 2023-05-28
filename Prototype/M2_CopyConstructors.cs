//Not best, but work

//Core idea here is to have a constructor to accept its type to make the copy
public class Person()
{
  public Person(string[] name, Address address)
  {
    //xxx
  }
  
  public Person(Person personToCopy)
  {
    //do copy here, for all reference type you need to have same copy constructor as Person
    
  }
}