// See https://aka.ms/new-console-template for more information

Task<int[]> task1 = CreateRandomArrayAsync(10);
Task<int[]> task2 = MultiplyArrayAsync(await task1);

//Task<int[]> task3 = SortArrayAscending(await task2);
//Task<double> task4 = CalculateArrayAverage(await task3);

await Task.WhenAll(task1, task2);

int[] array = SortArrayAscending(task2.Result);
double average = CalculateArrayAverage(array);

Console.WriteLine("Task 1: Created array of 10 random integers.");
Console.WriteLine(string.Join(", ", task1.Result));

Console.WriteLine("Task 2: Multiplied the array by a random number.");
Console.WriteLine(string.Join(", ", task2.Result));

Console.WriteLine("Task 3: Sorted the array in ascending order.");
Console.WriteLine(string.Join(", ", array));

Console.WriteLine("Task 4: Calculated the average value of the array.");
Console.WriteLine(average);


static async Task<int[]> CreateRandomArrayAsync(int length)
{
    Random random = new Random();
    return await Task.Run(() =>
        Enumerable.Range(1, length).Select(i => random.Next(1, 100)).ToArray());
}

static async Task<int[]> MultiplyArrayAsync(int[] array)
{
    Random random = new Random();
    int multiplier = random.Next(1, 11);
    return await Task.Run(() =>
        array.Select(i => i * multiplier).ToArray());
}

static int[] SortArrayAscending(int[] array)
{
    //return await Task.Run(() => array.OrderBy(i => i).ToArray());
    return array.OrderBy(i => i).ToArray();
}

static double CalculateArrayAverage(int[] array)
{
    //return await Task.Run(() => array.Average());
    return array.Average();
}