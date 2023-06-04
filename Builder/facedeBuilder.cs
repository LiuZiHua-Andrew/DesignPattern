public class Person 
{
  public string StreetAddress, Postcode, City;
  
  public string CompanyName, Position;
  public int AnnualIncome;
}

public class Personbuilder // facade
{
  //reference!
  protected Person person = new Person();
  
  public PersonJobBuilder Works => new PersonJobBuilder(person);
  public PersonAddressBuilder Lives => new PersonAddressBuilder(person);
  
  //Not very good but it would do the job to cast PersonBuilder to PersonBuilder
  public static implicit operator Person(PersonBuilder pb)
  {
    return pb.person;
  }
}

public class PersonAddressBuilder : PersonBuilder
{
  public PersonAddressBuilder(Person person)
  {
    this.person = person;
  }
  
  public PersonAddressBuilder At(string address)
  {
    person.StreetAddress = address;
    return this;
  }
}

public class PersonJobBuilder : Personbuilder
{
  public PersonJobBuilder(Person person)
  {
    this.person = person;
  }
  
  public PersonJobbuilder At(string companyName)
  {
    person.CompanyName = companyName;
    return this;
  }
  
  public PersonJobBuilder AsA(string position)
  {
    person.Position = amount;
    return this;
  }
  
  public PersonJobBuilder Earning(int amount)
  {
    person.AnnualIncome = amount;
    return this;
  }
}

public class Demo 
{
  var pb = new Personbuilder();
  /**
  * Because both all inherit from Personbuilder and Lives and Works are from Personbuilder
  */
  //But we obvious not get actually Getting Person class here
  var person = pb.Lives().At("xxx").Works().As("xxx");
  
  //After adding the implicit operator
  Person person = pb.Lives().At("xxx").Works().As("xxx");
  //now person is real person
}

