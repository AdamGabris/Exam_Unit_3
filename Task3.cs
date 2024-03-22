using System.Text.Json;

namespace Task;

public class Task3
{
    public static Node InitializeFile(string filename)
    {
        string jsonNodes = File.ReadAllText(filename);
        return JsonSerializer.Deserialize<Node>(jsonNodes);
    }

    public static void SumOfStructure(string filename)
    {
        Node node = InitializeFile(filename);
        int sum = CalculateSum(node);
        Console.WriteLine(sum);
    }

    public static void DeepestLevel(string filename)
    {
        Node node = InitializeFile(filename);
        int depth = CalculateDepth(node);
        Console.WriteLine(depth);
    }
    public static void NumberOfNodes(string filename)
    {
        Node node = InitializeFile(filename);
        int count = CountNodes(node);
        Console.WriteLine(count);
    }
    public static int CalculateSum(Node node)
    {
        if (node == null)
        {
            return 0;
        }

        return node.value + CalculateSum(node.left) + CalculateSum(node.right);
    }

    public static int CalculateDepth(Node node)
    {
        if (node == null)
        {
            return 0;
        }

        int leftDepth = CalculateDepth(node.left);
        int rightDepth = CalculateDepth(node.right);

        return Math.Max(leftDepth, rightDepth) + 1;
    }

    public static int CountNodes(Node node)
    {
        if (node == null)
        {
            return 0;
        }

        return 1 + CountNodes(node.left) + CountNodes(node.right);
    }
}

public class Node
{
    public int value { get; set; }
    public Node right { get; set; }
    public Node left { get; set; }
}