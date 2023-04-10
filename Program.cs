using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Algorithms
{
    internal class Program
    {
        static int dataLength = 50;
        static int dataRangeMin = 0;
        static int dataRangeMax = 100;

        static void Main(string[] args)
        {
            Random rnd = new Random();

            // generate array of random values
            int[] unsorted = new int[dataLength];
            for (int i = 0; i < dataLength; i++)
                unsorted[i] = rnd.Next(dataRangeMin, dataRangeMax);

            foreach (int val in InsertionSort(unsorted))
            {
                Console.WriteLine(val);
            }

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
            
            // continues to sort, incrementing sortPos until array is sorted
            if (!ArrSorted(data))
                InsertionSort(data, sortPos + 1);

            return data;
        }
    }
}
