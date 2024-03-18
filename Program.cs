#region Task 1


//Output
Console.WriteLine(Square(5));
Console.WriteLine(LengthInMm(5));
Console.WriteLine(Root(5));
Console.WriteLine(Cube(5));
Console.WriteLine(AreaOfCircle(5));
Console.WriteLine(Greeting("John"));


// Functions

int Square(int x)
{
    return x * x;
}

double Root(double x)
{
    return Math.Sqrt(x);
}

int Cube(int x)
{
    return x * x * x;
}

double LengthInMm(double lengthInInches)
{
    return lengthInInches * 25.4;
}

double AreaOfCircle(double radius)
{
    return Math.PI * radius * radius;
}

string Greeting(string name)
{
    return "Hello, " + name;
}


#endregion