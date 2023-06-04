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
  
  //Another mitigation, normally requires a bit comments before the constructor for explanation on the generic arguments
  public Point(double a, double b, SomeEnum enumVal) {
    switch (enumVal) {
      case xxx
       //assign a and b to fields with some operation
      case xxx
       //assign a and b to different fields with some operation
    }
  }
  
  //Using inheritance is also an option here but it is not as simpler as using factory way
}

public class WithFactory
{
  public class Point 
  {
    private double x, y;
    
    //Resharper can automatically create factory method for you if you have one installed
    
    //Factory method
    public static Point NewcartesianPoint(double x, double y)
    {
      return new Point(x, y);
    }
    
    public static Point NewPolarPoint(double rho, double theta)
    {
      return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
    }
    
    //Here the unextendable constructor is made of private
    private Point(double x, double y)
    {
      this.x = x;
      this.y = y;
    }
  }
  
  Main ()
  {
    var polarPoint = new Point.NewPolarPoint(1, 2);
    var anotherPoint = new Point.NewcartesianPoint(1, 2);
  }
}