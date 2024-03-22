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
    List<string> isbnForAuthor = GetISBNForAuthor(books, "Terry Pratchett");
    List<Book> booksAlphabetically = ListAllBooksAlphabetically(books, true);
    List<Book> booksChronologically = ListAllBooksChronologically(books, true);
    List<Book> booksGroupedByLastName = GroupBooksByLastName(books);
    List<Book> booksGroupedByFirstName = GroupBooksByFirstName(books);


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

    /*     foreach (var book in booksWrittenAfter)
        {
            Console.WriteLine($"Title: {book.title}, Author: {book.author}, Publication Year: {book.publication_year}, ISBN: {book.isbn}");
        } */
    /*    foreach (var isbn in isbnForAuthor)
       {
           Console.WriteLine(isbn);
       } */
    /*     foreach (var book in booksAlphabetically)
        {
            Console.WriteLine($"Title: {book.title}, Author: {book.author}, Publication Year: {book.publication_year}, ISBN: {book.isbn}");
        } */

    /*     foreach (var book in booksChronologically)
        {
            Console.WriteLine($"Title: {book.title}, Author: {book.author}, Publication Year: {book.publication_year}, ISBN: {book.isbn}");
        } */
    /*     foreach (var book in booksGroupedByLastName)
        {
            Console.WriteLine($"Title: {book.title}, Author: {book.author}, Publication Year: {book.publication_year}, ISBN: {book.isbn}");
        } */
    foreach (var book in booksGroupedByFirstName)
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
        string authorName = book.author.Split(new string[] { "(Translated by" }, StringSplitOptions.None)[0];
        foreach (char c in authorName)
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

List<string> GetISBNForAuthor(List<Book> books, string author)
{
    List<string> result = new List<string>();
    foreach (var book in books)
    {
        string authorName = book.author.Split(new string[] { "(Translated by" }, StringSplitOptions.None)[0].Trim();
        if (authorName == author)
        {
            result.Add(book.isbn);
        }
    }
    return result;
}

List<string> GetAuthorLastName(List<Book> books)
{
    List<string> result = new List<string>();
    foreach (var book in books)
    {
        string authorName = book.author.Split(new string[] { "(Translated by" }, StringSplitOptions.None)[0].Trim();
        string[] names = authorName.Split(' ');
        result.Add(names[names.Length - 1]);
    }
    return result;
}

List<string> GetAuthorFirstName(List<Book> books)
{
    List<string> result = new List<string>();
    foreach (var book in books)
    {
        string authorName = book.author.Split(new string[] { "(Translated by" }, StringSplitOptions.None)[0].Trim();
        string[] names = authorName.Split(' ');
        result.Add(names[0]);
    }
    return result;
}

List<Book> ListAllBooksAlphabetically(List<Book> books, bool ascending)
{
    Book temporary;
    for (int i = 0; i < books.Count - 1; i++)
    {
        for (int j = i + 1; j < books.Count; j++)
        {
            if (ascending)
            {
                if (string.Compare(books[i].title, books[j].title) > 0)
                {
                    temporary = books[i];
                    books[i] = books[j];
                    books[j] = temporary;
                }
            }
            else
            {
                if (string.Compare(books[i].title, books[j].title) < 0)
                {
                    temporary = books[i];
                    books[i] = books[j];
                    books[j] = temporary;
                }
            }
        }
    }
    return books;
}

List<Book> ListAllBooksChronologically(List<Book> books, bool ascending)
{
    Book temporary;
    for (int i = 0; i < books.Count - 1; i++)
    {
        for (int j = i + 1; j < books.Count; j++)
        {
            if (ascending)
            {
                if (books[i].publication_year > books[j].publication_year)
                {
                    temporary = books[i];
                    books[i] = books[j];
                    books[j] = temporary;
                }
            }
            else
            {
                if (books[i].publication_year < books[j].publication_year)
                {
                    temporary = books[i];
                    books[i] = books[j];
                    books[j] = temporary;
                }
            }
        }
    }
    return books;
}

List<Book> GroupBooksByLastName(List<Book> books)
{
    List<Book> result = new List<Book>();
    List<string> lastNames = GetAuthorLastName(books);
    List<string> firstNames = GetAuthorFirstName(books);
    for (int i = 0; i < lastNames.Count; i++)
    {
        for (int j = i + 1; j < lastNames.Count; j++)
        {
            if (lastNames[i] == lastNames[j])
            {
                if (firstNames[i] == firstNames[j])
                {
                    result.Add(books[i]);
                    result.Add(books[j]);
                }
            }
        }
    }
    return result;
}

List<Book> GroupBooksByFirstName(List<Book> books)
{
    List<Book> result = new List<Book>();
    List<string> lastNames = GetAuthorLastName(books);
    List<string> firstNames = GetAuthorFirstName(books);
    for (int i = 0; i < lastNames.Count; i++)
    {
        for (int j = i + 1; j < lastNames.Count; j++)
        {
            if (firstNames[i] == firstNames[j])
            {
                if (lastNames[i] == lastNames[j])
                {
                    result.Add(books[i]);
                    result.Add(books[j]);
                }
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