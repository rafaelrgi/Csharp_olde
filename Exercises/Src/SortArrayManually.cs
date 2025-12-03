using System.Diagnostics;

namespace SortArrayManually;

/*
Sort an array of integers manually.
*/

public class Test
{
  static int swaps = 0;
  public static int[] Run(int[] array)
  {
    Test.swaps = 0;

    int[] numbers = new int[array.Length];
    array.CopyTo(numbers, 0);

    if (numbers.Length < 2)
      return numbers;

    int pivot;

    pivot = 1;
    Sort(numbers, pivot);

    Debug.WriteLine($"Total swaps: {Test.swaps}");
    return numbers;
  }

  static void Sort(int[] array, int pivot)
  {
    if (pivot >= array.Length) return;

    for (int i = 0; i < array.Length; i++)
    {
      if (array[i] > array[pivot])
        Swap(array, i, pivot);
    }

    Sort(array, pivot + 1);
  }

  static void Swap(int[] array, int index1, int index2)
  {
    Test.swaps++;
    (array[index2], array[index1]) = (array[index1], array[index2]);
  }

}