## Object creation logic becomes too convoluted.
## Constructor is not descriptive
  1. Name mandated by name of containing type
  2. Cannot overload with same sets of arguments with different names
  ```
  Constructor1(int x, int y) { }
  //Cannot have another one like, although you want x,y to be different from a,b
  Constructor2(int a, int b) { }
  ```
  3. Can turn into 'optional parameter hell'
  ```
  Constructor(int x, int y = 0, string z = "optional", char a = 'a') { }
  ```
## Object creation (non-piecewise, unlike Builder) can be outsourced to
  1. A separate function (Factory Method)
  2. That may exist in a separate class (Factory)
  3. Can create hierarchy of factories with abstract factory (Abstract factorty)

> Factory
>
> A component responsible solely for the wholesale (**not piecewise**) creation of objects.