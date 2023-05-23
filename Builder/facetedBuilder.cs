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
}

public class PersonAddressBuilder : PersonBuilder
{
  public PersonAddressBuilder(Person person)
  {>
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

var pb = new Personbuilder()
var person = pb.Lives().At("xxx").Works().As("xxx");