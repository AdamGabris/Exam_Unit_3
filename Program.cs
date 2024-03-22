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


ReadArrayFile("arrays.json");





// Functions

void ReadArrayFile(string filename)
{
    string jsonArray = File.ReadAllText(filename);
    JsonDocument source = JsonDocument.Parse(jsonArray);
    List<int> flattenedArray = FlattenArray(source.RootElement);
    Console.WriteLine(string.Join(", ", flattenedArray));
}


List<int> FlattenArray(JsonElement element)
{
    List<int> result = new List<int>();

    if (element.ValueKind == JsonValueKind.Array)
    {
        foreach (JsonElement item in element.EnumerateArray())
        {
            result.AddRange(FlattenArray(item));
        }
    }
    else if (element.ValueKind == JsonValueKind.Number)
    {
        result.Add(element.GetInt32());
    }

    return result;
}
#endregion

#region Task 3

// Output

//ReadNodeFile("nodes.json");


// Functions


void ReadNodeFile(string filename)
{
    string jsonNodes = File.ReadAllText(filename);
    Node node = JsonSerializer.Deserialize<Node>(jsonNodes);
    int sum = CalculateSum(node);
    Console.WriteLine(sum);
    int depth = CalculateDepth(node);
    Console.WriteLine(depth);
    int count = CountNodes(node);
    Console.WriteLine(count);
}


int CalculateSum(Node node)
{
    if (node == null)
    {
        return 0;
    }

    return node.value + CalculateSum(node.left) + CalculateSum(node.right);
}

int CalculateDepth(Node node)
{
    if (node == null)
    {
        return 0;
    }

    int leftDepth = CalculateDepth(node.left);
    int rightDepth = CalculateDepth(node.right);

    return Math.Max(leftDepth, rightDepth) + 1;
}

int CountNodes(Node node)
{
    if (node == null)
    {
        return 0;
    }

    return 1 + CountNodes(node.left) + CountNodes(node.right);
}


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
    //Dictionary<string, List<string>> booksGroupedByLastName = GroupBooksByAuthorLastName(books);
    //PrintBooksByAuthorLastName(booksGroupedByLastName);
    Dictionary<string, List<string>> booksGroupedByFirstName = GroupBooksByAuthorFirstName(books);
    PrintBooksByAuthorFirstName(booksGroupedByFirstName);




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
    /*     foreach (var book in booksGroupedByFirstName)
        {
            Console.WriteLine($"Title: {book.title}, Author: {book.author}, Publication Year: {book.publication_year}, ISBN: {book.isbn}");
        } */

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

Dictionary<string, List<string>> GroupBooksByAuthorLastName(List<Book> books)
{
    Dictionary<string, List<string>> result = new Dictionary<string, List<string>>();
    foreach (var book in books)
    {
        string authorLastName = GetAuthorLastName(new List<Book> { book })[0];
        if (result.ContainsKey(authorLastName))
        {
            result[authorLastName].Add(book.title);
        }
        else
        {
            result[authorLastName] = new List<string> { book.title };
        }
    }
    return result;
}

Dictionary<string, List<string>> GroupBooksByAuthorFirstName(List<Book> books)
{
    Dictionary<string, List<string>> result = new Dictionary<string, List<string>>();
    foreach (var book in books)
    {
        string authorFirstName = GetAuthorFirstName(new List<Book> { book })[0];
        if (result.ContainsKey(authorFirstName))
        {
            result[authorFirstName].Add(book.title);
        }
        else
        {
            result[authorFirstName] = new List<string> { book.title };
        }
    }
    return result;
}

void PrintBooksByAuthorLastName(Dictionary<string, List<string>> booksByAuthorLastName)
{
    List<string> authors = new List<string>(booksByAuthorLastName.Keys);
    int n = authors.Count;

    for (int i = 0; i < n - 1; i++)
    {
        for (int j = 0; j < n - i - 1; j++)
        {
            if (string.Compare(authors[j], authors[j + 1]) > 0)
            {
                string temp = authors[j];
                authors[j] = authors[j + 1];
                authors[j + 1] = temp;
            }
        }
    }

    foreach (var author in authors)
    {
        Console.WriteLine($"Author: {author}; Books: {string.Join(", ", booksByAuthorLastName[author])}");
    }
}

void PrintBooksByAuthorFirstName(Dictionary<string, List<string>> booksByAuthorFirstName)
{
    List<string> authors = new List<string>(booksByAuthorFirstName.Keys);
    int n = authors.Count;

    for (int i = 0; i < n - 1; i++)
    {
        for (int j = 0; j < n - i - 1; j++)
        {
            if (string.Compare(authors[j], authors[j + 1]) > 0)
            {
                string temp = authors[j];
                authors[j] = authors[j + 1];
                authors[j + 1] = temp;
            }
        }
    }

    foreach (var author in authors)
    {
        Console.WriteLine($"Author: {author}; Books: {string.Join(", ", booksByAuthorFirstName[author])}");
    }
}

#endregion

#region Classes

public class Node
{
    public int value { get; set; }
    public Node right { get; set; }
    public Node left { get; set; }
}


public class Book
{
    public string? title { get; set; }
    public int? publication_year { get; set; }
    public string? author { get; set; }
    public string? isbn { get; set; }
}

#endregion