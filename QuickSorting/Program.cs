using System.Globalization;

Console.Write("Input elements count: ");
var nStr = Console.ReadLine();

if (!int.TryParse(nStr, NumberStyles.Integer, CultureInfo.InvariantCulture, out var n))
{
    Console.WriteLine("Can not parse your request");
    return;
}

if (n < 2)
{
    Console.WriteLine("Value can not be less 2");
    return;
}

var random = new Random();
var array = new int[n];

// Fill array with generated elements
for (var i = 0; i < n; i++)
{
    array[i] = random.Next(0, 1000);
}

Console.WriteLine("Generated array:");
PrintArray(ref array);

for (var i = 0; i < n - 1; i++)
{
    // Find the minimum element in unsorted array
    var minIdx = i;
    for (var j = i + 1; j < n; j++)
    {
        if (array[j] < array[minIdx])
        {
            minIdx = j;
        }
    }
    
    // Swap the founded minimum element with the first element
    (array[minIdx], array[i]) = (array[i], array[minIdx]);
    
    Console.WriteLine(i + 1 + " iteration:");
    PrintArray(ref array);
}

Console.WriteLine("Sorted array:");
PrintArray(ref array);

void PrintArray(ref int[] arr)
{
    foreach (var item in arr)
    {
        Console.Write(item.ToString() + '\t');
    }
    
    Console.WriteLine();
}