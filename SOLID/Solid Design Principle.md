## Single Responsibility Principle
Any class should have only single reason to change.
An typical class should only handle one thing and one reason to change.

## Open-Closed Principle
Class should be open for extension, but closed for modification.

An example could be Specification Pattern
```
public class xxxSpecification : ISpecification<T>
public class xxx2Specification: ISpecification<T>

public interface IFilter<T>
{
  public IEnumerable<Product> Filter(IEnumerable<T>, ISpecification<T>)
}
```