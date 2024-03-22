using System.IO;
using System.Text.Json;




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

#region Task 2

// Output








// Functions



#endregion

#region Task 3

// Output




// Functions





#endregion


#region Task 4



// Output

ReadBooksFromFile("books.json");

// Functions




void ReadBooksFromFile(string filename)
{
    string jsonBooks = File.ReadAllText(filename);
    List<Book> books = JsonSerializer.Deserialize<List<Book>>(jsonBooks);
    List<Book> booksStartingWithThe = GetBooksStartingWithThe(books);
    List<Book> booksOfAuthorsWithT = GetBooksOfAuthorsWithT(books);
    List<Book> booksWrittenAfter = GetBooksWrittenAfterOrBefore(books, 2004, false);


    /*  foreach (var book in books)
     {
         Console.WriteLine($"Title: {book.title}, Author: {book.author}, Publication Year: {book.publication_year}, ISBN: {book.isbn}");
     } */

    /*     foreach (var book in booksStartingWithThe)
        {
            Console.WriteLine($"Title: {book.title}, Author: {book.author}, Publication Year: {book.publication_year}, ISBN: {book.isbn}");
        } */

    /*     foreach (var book in booksOfAuthorsWithT)
        {
            Console.WriteLine($"Title: {book.title}, Author: {book.author}, Publication Year: {book.publication_year}, ISBN: {book.isbn}");
        } */

    foreach (var book in booksWrittenAfter)
    {
        Console.WriteLine($"Title: {book.title}, Author: {book.author}, Publication Year: {book.publication_year}, ISBN: {book.isbn}");
    }
}

List<Book> GetBooksStartingWithThe(List<Book> books)
{
    List<Book> result = new List<Book>();
    string prefix = "The";

    foreach (var book in books)
    {
        bool startsWithThe = true;
        if (book.title.Length >= prefix.Length)
        {
            for (int i = 0; i < prefix.Length; i++)
            {
                if (book.title[i] != prefix[i])
                {
                    startsWithThe = false;
                    break;
                }
            }
            if (startsWithThe)
            {
                result.Add(book);
            }
        }
    }
    return result;
}

List<Book> GetBooksOfAuthorsWithT(List<Book> books)
{
    List<Book> result = new List<Book>();
    foreach (var book in books)
    {
        bool foundT = false;
        foreach (char c in book.author)
        {
            if (c == 't' || c == 'T')
            {
                foundT = true;
                break;
            }
        }
        if (foundT)
        {
            result.Add(book);
        }
    }
    return result;
}

List<Book> GetBooksWrittenAfterOrBefore(List<Book> books, int year, bool after)
{
    List<Book> result = new List<Book>();
    foreach (var book in books)
    {
        if (after)
        {
            if (book.publication_year > year)
            {
                result.Add(book);
            }
        }
        else
        {
            if (book.publication_year < year)
            {
                result.Add(book);
            }
        }
    }
    return result;
}


public class Book
{
    public string? title { get; set; }
    public int? publication_year { get; set; }
    public string? author { get; set; }
    public string? isbn { get; set; }
}

#endregion