/*
Similar to IClonable interface,
we create another interface and take generic T, and explicitly make a deepCopy function
So any derived class would implement it and consumer would understand it is deepCopy by its name
Also, it is strong typed

But we still have the problem that we need to recursively go through all the hierarchy element to make a deepClone method for them.
*/

public interface IDeepClone<T>
{
  public T DeepClone();
}

public Person : IDeepClone<Person>
{
  //xxx
  
  public Person DeepClone()
  {
    //xxx
  }
}