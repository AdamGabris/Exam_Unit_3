using System.Text.Json;

namespace Task;

public class Task2
{
    public static void PrintFlattenedArray(string filename)
    {
        string jsonArray = File.ReadAllText(filename);
        JsonDocument source = JsonDocument.Parse(jsonArray);
        List<int> flattenedArray = FlattenArray(source.RootElement);

        Console.WriteLine(string.Join(", ", flattenedArray));
    }

    public static List<int> FlattenArray(JsonElement element)
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
}
