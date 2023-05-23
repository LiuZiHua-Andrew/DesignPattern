public class Point
{
  private double x, y;
  
  //This becomes not extendable as you cannot overload a constructor with exact argument types
  // public Point(double rho, double theta) { } THIS IS INVALID BECAUSE THE ARGUMENT TYPES ARE DUPLICATED
  public Point(double x, double y)
  {
    this.x = x;
    this.y = y;
  }
  
  enum SomeEnum {...}
  
  //Another mitigation 
  public Point(double a, double b, SomeEnum enumVal) {
    switch (enumVal) {
      case xxx
       //assign a and b to fields with some operation
      case xxx
       //assign a and b to different fields with some operation
    }
  }
  
  
}