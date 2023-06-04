## Single Responsibility Principle
Any class should have only single reason to change.
An typical class should only handle one thing and one reason to change.

## Open-Closed Principle
Class should be open for extension, but closed for modification.

An example could be Specification Pattern
```
public class xxxSpecification : ISpecification<T>
public class xxx2Specification: ISpecification<T>
public class AndSpecification<T>: ISpecification<T>
{
  private ISpecification<T> first, second;
  
  public AndSpecification(ISpecification<T> first, ISpecification<T> second)
  {
    this.first = first;
    this.second = second
  }
  
  public bool IsSatisfied(T t)
  {
    return first.IsSatisfied() && second.IsSatisfied();
  }
}

public interface IFilter<T>
{
  public IEnumerable<Product> Filter(IEnumerable<T>, ISpecification<T>)
}
```

## Liskov Substitution Principle
You should be able to substitute a base type with a sub type.

## Interface Segregation Principle
Interface should not be too big so anyone who implements the interface will not implement functions that are not required for them.

## Dependency Inversion
High level parts of the system should not depend on low level parts of the system directly, instead, they should depends on some abstraction.



