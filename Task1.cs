namespace Task;


public class Task1
{

    public static int Square(int x)
    {
        return x * x;
    }

    public static double Root(double x)
    {
        return Math.Sqrt(x);
    }

    public static int Cube(int x)
    {
        return x * x * x;
    }

    public static double LengthInMm(double lengthInInches)
    {
        double conversionMultiplier = 25.4;
        return lengthInInches * conversionMultiplier;
    }

    public static double AreaOfCircle(double radius)
    {
        return Math.PI * radius * radius;
    }

    public static string Greeting(string name)
    {
        return "Hello, " + name;
    }
}
