using Task;

class Program
{
    static void Main()
    {

        Console.Clear();
        #region Task 1

        int squareResult = Task1.Square(5);
        double rootResult = Task1.Root(25.0);
        int cubeResult = Task1.Cube(3);
        double lengthInMmResult = Task1.LengthInMm(10.0);
        double areaOfCircleResult = Task1.AreaOfCircle(5.0);
        string greetingResult = Task1.Greeting("John");

        Console.WriteLine($"Square: {squareResult}");
        Console.WriteLine($"Root: {rootResult}");
        Console.WriteLine($"Cube: {cubeResult}");
        Console.WriteLine($"Length in mm: {lengthInMmResult}");
        Console.WriteLine($"Area of Circle: {areaOfCircleResult}");
        Console.WriteLine($"Greeting: {greetingResult}");

        Console.WriteLine(new string('-', Console.WindowWidth));

        #endregion

        #region Task 2

        Task2.PrintFlattenedArray("arrays.json");

        Console.WriteLine(new string('-', Console.WindowWidth));

        #endregion

        #region Task 3

        Task3.SumOfStructure("nodes.json");
        Task3.DeepestLevel("nodes.json");
        Task3.NumberOfNodes("nodes.json");

        Console.WriteLine(new string('-', Console.WindowWidth));

        #endregion

        #region Task 4

        Task4.ReturnBooksWithThe("books.json");
        Console.WriteLine(new string('-', Console.WindowWidth));
        Task4.ReturnBooksWithTInName("books.json");
        Console.WriteLine(new string('-', Console.WindowWidth));
        Task4.ReturnBooksWrittenBeforeOrAfter("books.json", 1992, true);
        Task4.ReturnBooksWrittenBeforeOrAfter("books.json", 2004, false);
        Console.WriteLine(new string('-', Console.WindowWidth));
        Task4.ReturnISBN("books.json", "Terry Pratchett");
        Console.WriteLine(new string('-', Console.WindowWidth));
        Task4.ListBooksAlphabetically("books.json", true);
        Console.WriteLine(new string('-', Console.WindowWidth));
        Task4.ListAllBooksChronologically("books.json", true);
        Console.WriteLine(new string('-', Console.WindowWidth));
        Task4.BooksGroupedByLastName("books.json");
        Console.WriteLine(new string('-', Console.WindowWidth));
        Task4.BooksGroupedByFirstName("books.json");



        #endregion
    }
}