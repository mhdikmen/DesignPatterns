

Point point = Point.Factory.NewPolarPoint(1.0, Math.PI / 4);
Console.WriteLine(point);
var origin = Point.Origin;

public class Point
{
    private double x, y;
    //in assambly
    internal Point(double x, double y)
    {
        this.x = x;
        this.y = y;
    }
    public override string ToString()
    {
        return $"{nameof(x)} : {x} , {nameof(y)} : {y}";
    }
    public static Point Origin => new Point(0.0, 0.0);
    public static Point Origin2 = new Point(0.0, 0.0);//better
    public static class Factory
    {
        //factory method
        public static Point NewCartesianPoint(double x, double y)
        {
            return new Point(x, y);
        }
        public static Point NewPolarPoint(double rho, double theta)
        {
            return new Point(rho * Math.Cos(theta), theta * Math.Sin(theta));
        }
    }

}