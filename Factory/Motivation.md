## 1) Object creation logic becomes too convoluted.
## 2) Constructor is not descriptive
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