using System.Text.Json;

namespace Task;

public class Task4
{



    public static List<Book> InitializeFile(string filename)
    {
        string jsonBooks = File.ReadAllText(filename);
        List<Book> books = JsonSerializer.Deserialize<List<Book>>(jsonBooks);
        return books;
    }

    public static void ReturnBooksWithThe(string filename)
    {
        List<Book> books = InitializeFile(filename);
        List<Book> booksStartingWithThe = GetBooksStartingWithThe(books);
        PrintBooks(booksStartingWithThe);
    }

    public static void ReturnBooksWithTInName(string filename)
    {
        List<Book> books = InitializeFile(filename);
        List<Book> booksOfAuthorsWithT = GetBooksOfAuthorsWithT(books);
        PrintBooks(booksOfAuthorsWithT);
    }

    public static void ReturnBooksWrittenBeforeOrAfter(string filename, int year, bool after = true)
    {
        List<Book> books = InitializeFile(filename);
        List<Book> booksWrittenAfter = GetBooksWrittenAfterOrBefore(books, year, after);
        //PrintBooks(booksWrittenAfter);
        Console.WriteLine(booksWrittenAfter.Count);
    }

    public static void ReturnISBN(string filename, string author)
    {
        List<Book> books = InitializeFile(filename);
        List<string> isbnForAuthor = GetISBNForAuthor(books, author);
        PrintISBNs(isbnForAuthor);
    }

    public static void ListBooksAlphabetically(string filename, bool ascending = true)
    {
        List<Book> books = InitializeFile(filename);
        List<Book> booksAlphabetically = GetAllBooksAlphabetically(books, ascending);
        PrintBooks(booksAlphabetically);
    }

    public static void ListAllBooksChronologically(string filename, bool ascending = true)
    {
        List<Book> books = InitializeFile(filename);
        List<Book> booksChronologically = GetAllBooksChronologically(books, ascending);
        PrintBooks(booksChronologically);
    }

    public static void BooksGroupedByLastName(string filename)
    {
        List<Book> books = InitializeFile(filename);
        Dictionary<string, List<string>> booksGroupedByLastName = GroupBooksByAuthorLastName(books);
        PrintBooksByAuthorLastName(booksGroupedByLastName);
    }

    public static void BooksGroupedByFirstName(string filename)
    {
        List<Book> books = InitializeFile(filename);
        Dictionary<string, List<string>> booksGroupedByFirstName = GroupBooksByAuthorFirstName(books);
        PrintBooksByAuthorFirstName(booksGroupedByFirstName);
    }

    public static void PrintBooks(List<Book> books)
    {
        foreach (var book in books)
        {
            Console.WriteLine($"Title: {book.title}, Author: {book.author}, Publication Year: {book.publication_year}, ISBN: {book.isbn}");
        }
    }

    public static void PrintISBNs(List<string> isbnList)
    {
        foreach (var isbn in isbnList)
        {
            Console.WriteLine(isbn);
        }
    }

    public static List<Book> GetBooksStartingWithThe(List<Book> books)
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

    public static List<Book> GetBooksOfAuthorsWithT(List<Book> books)
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

    public static List<Book> GetBooksWrittenAfterOrBefore(List<Book> books, int year, bool after)
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

    public static List<string> GetISBNForAuthor(List<Book> books, string author)
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

    public static List<string> GetAuthorLastName(List<Book> books)
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

    public static List<string> GetAuthorFirstName(List<Book> books)
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

    public static List<Book> GetAllBooksAlphabetically(List<Book> books, bool ascending)
    {
        BubbleSort(books, (book1, book2) => ascending ? string.Compare(book1.title, book2.title) > 0 : string.Compare(book1.title, book2.title) < 0);
        return books;
    }

    public static List<Book> GetAllBooksChronologically(List<Book> books, bool ascending)
    {
        BubbleSort(books, (book1, book2) => ascending ? book1.publication_year > book2.publication_year : book1.publication_year < book2.publication_year);
        return books;
    }

    public static void PrintBooksByAuthorLastName(Dictionary<string, List<string>> booksByAuthorLastName)
    {
        List<string> authors = new List<string>(booksByAuthorLastName.Keys);
        BubbleSort(authors, (author1, author2) => string.Compare(author1, author2) > 0);

        foreach (var author in authors)
        {
            Console.WriteLine($"Author: {author}; Books: {string.Join(", ", booksByAuthorLastName[author])}");
        }
    }

    public static void PrintBooksByAuthorFirstName(Dictionary<string, List<string>> booksByAuthorFirstName)
    {
        List<string> authors = new List<string>(booksByAuthorFirstName.Keys);
        BubbleSort(authors, (author1, author2) => string.Compare(author1, author2) > 0);

        foreach (var author in authors)
        {
            Console.WriteLine($"Author: {author}; Books: {string.Join(", ", booksByAuthorFirstName[author])}");
        }
    }

    public static Dictionary<string, List<string>> GroupBooksByAuthorLastName(List<Book> books)
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

    public static Dictionary<string, List<string>> GroupBooksByAuthorFirstName(List<Book> books)
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




    public static void BubbleSort<T>(List<T> list, Func<T, T, bool> compare)
    {
        T temporary;
        for (int i = 0; i < list.Count - 1; i++)
        {
            for (int j = i + 1; j < list.Count; j++)
            {
                if (compare(list[i], list[j]))
                {
                    temporary = list[i];
                    list[i] = list[j];
                    list[j] = temporary;
                }
            }
        }
    }


}

public class Book
{
    public string? title { get; set; }
    public int? publication_year { get; set; }
    public string? author { get; set; }
    public string? isbn { get; set; }
}