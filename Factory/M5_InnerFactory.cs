public class WithFactory
{
  public class Point 
  {
    private double x, y;
    
    //Because we are having Pointfactory class, so the constructor here will be public
    public Point(double x, double y)
    {
      this.x = x;
      this.y = y;
    }
  }
}

public static class PointFactory
{
    public static Point NewcartesianPoint(double x, double y)
    {
      return new Point(x, y);
    }
    
    public static Point NewPolarPoint(double rho, double theta)
    {
      return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
    }
}

/*
To resolve the public constructor
*/

public class Point
{
  private double x, y;
    
    //Now it is private
    private Point(double x, double y)
    {
      this.x = x;
      this.y = y;
    }
    
    //Now it can access the private constructor without issue
    public static class PointFactory
    {
      public static Point NewcartesianPoint(double x, double y)
      {
        return new Point(x, y);
      }
      
      public static Point NewPolarPoint(double rho, double theta)
      {
         return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
      }
    }
}


  
  Main ()
  {
    var polarPoint = PointFactory.NewPolarPoint(1, 2);
    var anotherPoint = PointFactory.NewcartesianPoint(1, 2);
    
    //new way
    var point = Point.Factory.NewPolarPoint(1, 2);
  }