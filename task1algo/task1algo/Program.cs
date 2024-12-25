using System;

class CountingSort
{
    public static void PerformCountingSort(int[] array)
    {
        int max = FindMax(array);

        int[] count = new int[max + 1];

        // Populate the count array
        for (int i = 0; i < array.Length; i++)
        {
            count[array[i]]++;
        }

        // Modify the count array to store cumulative sums
        for (int i = 1; i < count.Length; i++)
        {
            count[i] += count[i - 1];
        }

        int[] output = new int[array.Length];

        for (int i = array.Length - 1; i >= 0; i--)
        {
            output[count[array[i]] - 1] = array[i];
            count[array[i]]--;
        }

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = output[i];
        }
    }

    private static int FindMax(int[] array)
    {
        int max = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > max)
            {
                max = array[i];
            }
        }
        return max;
    }

    static void Main(string[] args)
    {
        int[] array = { 4, 2, 2, 8, 3, 3, 1 };

        Console.WriteLine("Original Array:");
        Console.WriteLine(string.Join(" ", array));

        PerformCountingSort(array);

        Console.WriteLine("\nSorted Array:");
        Console.WriteLine(string.Join(" ", array));
    }
}

