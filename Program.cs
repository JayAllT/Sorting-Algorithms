using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Sorting_Algorithms
{
    internal class Program
    {
        static int delay = 100;  // ms
        static int dataLength = 50;
        static int dataRangeMin = 0;
        static int dataRangeMax = 10;

        static void Main(string[] args)
        {
            Random rnd = new Random();

            // generate array of random values
            int[] unsorted = new int[dataLength];
            for (int i = 0; i < dataLength; i++)
                unsorted[i] = rnd.Next(dataRangeMin, dataRangeMax);

            InsertionSort(unsorted);

            Console.ReadKey();
        }

        // checks if an array is sorted
        static bool ArrSorted(int[] arr)
        {
            int prevVal = -1;

            // iterates through array, checking if previous value is greater than current
            for (int i = 0; i < arr.Length; i++)
            {
                if (prevVal > arr[i])
                    return false;

                prevVal = arr[i];
            }

            return true;
        }

        // display array as vertical bars
        static void DisplayArr(int[] arr, string name)
        {
            // sleep
            System.Threading.Thread.Sleep(delay);

            // clear console
            Console.Clear();

            // write name to console
            Console.WriteLine($"{name}\n");

            for (int i = 0; i < dataRangeMax; i++)      // iterating through from top to bottom, i = how far down
            { 
                for (int j = 0; j < arr.Length; j++)  // iterate through each value in array
                    if (arr[j] >= dataRangeMax - i)  // checks if value at j in array is greater than inverse of i / how far up cursor is
                       Console.Write("#");          // write # to console if value at j in arr is great enough to be at that point
                
                    else                          // else write space
                        Console.Write(" ");
                
                Console.Write("\n");
            }
        }

        static int[] InsertionSort(int[] data, int sortPos = 0)
        {
            for (int i = 0; i < sortPos; i++)
            {
                // check if values before value at sortPos are greater than value at sortPos
                if (data[sortPos] < data[i])
                {
                    int valToMove = data[sortPos];

                    // move all values in between up 1, starting from end using offset
                    // e.g., (sortPos = 5) [1, 1, 8, 9, 12, 4, 60] ---> [1, 1, 8, 8, 9, 12, 60]
                    for (int j = 0; j < sortPos - i; j++)
                    {
                        int offset = sortPos - i - j - 1;  // reverse values of j, e.g., 3, 2, 1, 0 instead of 0, 1, 2, 3

                        // move data
                        data[i + offset + 1] = data[i + offset];
                    }

                    // insert value from sortPos
                    data[i] = valToMove;
                }
            }

            // display array at current point
            DisplayArr(data, "Insertion Sort");

            // continues to sort, incrementing sortPos until array is sorted
            if (!ArrSorted(data))
                InsertionSort(data, sortPos + 1);

            return data;
        }
    }
}
