Point p1 = new Point(1, 2);
Point p2 = new Point(3, 4);

Line l1 = new Line(p1, p2);
Line l2 = l1.DeepCopy();
l2.Start.X = 5;

Console.WriteLine(l1);
Console.WriteLine(l2);
public class Point
{
    public int X, Y;
    public Point()
    {

    }
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
    public Point(Point point)
    {
        X = point.X;
        Y = point.Y;
    }
    public override string ToString()
    {
        return $"{nameof(X)} : {X} , {nameof(Y)} : {Y}";
    }
}

public class Line
{
    public Point Start, End;
    public Line()
    {

    }
    public Line(Point start, Point end)
    {
        Start = start;
        End = end;
    }

    public Line DeepCopy()
    {
        return new Line(new Point(Start), new Point(End));
    }
    public override string ToString()
    {
        return string.Concat("Start:", Start, ", End : ", End);
    }
} 