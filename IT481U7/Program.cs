using System.Diagnostics;
using System.Linq;

namespace IT481U7
{
    class Program
    {
        //Creating stopwatch object
        private static Stopwatch stopWatch;

        //Creating debug for printing
        private static bool debug = false;

        static void Main(string[] args)
        {
            //Set type by number
            // 1 = Bubble sort
            // 2 = quicksort
            int type = 1;

            //*******************************//
            //Bubble sort

            /***********
            *Small Array
            ***********/
            //Creating small integer array(10)
            int[] smallArray = getArray(10, 100);

            //Deep Copy to array to remove duplicates
            int[] newSmallArray = new int[smallArray.Length];
            Array.Copy(smallArray, 0, newSmallArray, 0, newSmallArray.Length);

            //Deep Copy to another array for quick sorting
            int[] quickSmallArray = new int[newSmallArray.Length];
            Array.Copy(newSmallArray, 0, quickSmallArray, 0, quickSmallArray.Length);

            //Running small bubble sort
            String size = "small";
            runSortArray(smallArray, size, type);

            /***********
            *Medium Array
            ***********/
            //Creating medium integer array(1,000)
            int[] mediumArray = getArray(1000, 100);

            //Deep Copy to array to remove duplicates
            int[] newMediumArray = new int[smallArray.Length];
            Array.Copy(mediumArray, 0, newMediumArray, 0, newMediumArray.Length);

            //Deep Copy to another array for quick sorting
            int[] quickMediumArray = new int[newMediumArray.Length];
            Array.Copy(newMediumArray, 0, quickMediumArray, 0, quickMediumArray.Length);

            //Running medium bubble sort
            size = "medium";
            runSortArray(mediumArray, size, type);

            /***********
            *Large Array
            ***********/
            //Creating large integer array(10,000)
            int[] largeArray = getArray(10000, 100);

            //Deep Copy to array to remove duplicates
            int[] newLargeArray = new int[largeArray.Length];
            Array.Copy(largeArray, 0, newLargeArray, 0, newLargeArray.Length);

            //Deep Copy to another array for quick sorting
            int[] quickLargeArray = new int[newLargeArray.Length];
            Array.Copy(newLargeArray, 0, quickLargeArray, 0, quickLargeArray.Length);

            //Running large bubble sort
            size = "large";
            runSortArray(largeArray, size, type);

            //**********************//
            //Remove duplicate set

            /*********
             *Removing duplicates and re-running tests
             *********/

            //Removing small array duplicates
            newSmallArray = onlyUniqueElements(newSmallArray);
            size = "new small unique";
            runSortArray(newSmallArray, size, type);

            //Removing medium array duplicates
            newMediumArray = onlyUniqueElements(newMediumArray);
            size = "new medium unique";
            runSortArray(newMediumArray, size, type);

            //Removing large array duplicates
            newLargeArray = onlyUniqueElements(newLargeArray);
            size = "new large unique";
            runSortArray(newLargeArray, size, type);

            //********************//
            //Quicksort method

            //Setting the type to quicksort
            type = 2;

            /**********
             * Running quick sorts with duplicates
             **********/
            //Using quick sort
            size = "quick small";
            //Running arrray for timing
            runSortArray(quickSmallArray, size, type);

            //Using quick sort
            size = "quick medium";
            //Running arrray for timing
            runSortArray(quickMediumArray, size, type);

            //Using quick sort
            size = "quick large";
            //Running arrray for timing
            runSortArray(quickLargeArray, size, type);
        }

        //Getting array of the integers sizes determined by parameters passed
        private static int[] getArray(int size, int randomMaxSize)
        {
            //Creating array with size
            int[] myArray = new int[size];

            //Getting random values for array
            for(int i = 0; i< myArray.Length; i++)
            {
                //Getting random number with randomMaxSize as the upper limit of 1 - randomMaxSize
                myArray[i] = GetRandomNumber(1, randomMaxSize);
            }
            //Returning filled array
            return myArray;
        }

        //Running sort actions by printing and timing arrays
        private static void runSortArray(int[] arr, String size, int type)
        {
            long elapsedTime = 0;

            //Setting sort type as string
            String sort = null;

            if(type == 1)
            {
                sort = "bubble";
            }
            else if(type == 2)
            {
                sort = "quick";
            }

            //Printing array before bubble sort algorithm
            if(debug)
            {
                Console.WriteLine("Array before the " + sort + " sort");
                for(int i = 0; i < arr.Length; i++)
                {
                    Console.Write(arr[i] + " ");
                }
            }

            //Starting timer
            stopWatch = Stopwatch.StartNew();

            //Sorting array using bubble algorithm
            if(type == 1)
            {
                bubbleSort(arr);
            }
            else if (type == 2 )
            {
                //Setting low and high values for the quick sort
                int low = 0;
                int high = arr.Length - 1;
                sortAsc(arr, low, high);
            }
            Console.WriteLine();

            //Printing array after bubble sort algorithm
            if (debug)
            {
                Console.WriteLine("Array after the " + sort + " sort");
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.Write(arr[i] + " ");
                }
            }

            //Stopping wait timer
            stopWatch.Stop();

            //Getting time elapsed for waiting
            elapsedTime = stopWatch.ElapsedTicks;

            Console.WriteLine("\n");
            //Printing out time in nanseconds
            Console.WriteLine("The run time is for the " + size + " array in milliseconds is " + elapsedTime);
            Console.WriteLine("\n\n");
        }

        //Performing bubble sort
        private static void bubbleSort(int[] intArray)
        {
            /*
             * Bubble sort crosses the array from the first to the array.length - 1
             * position and compares the element with the next. Elements are swapped if it is greater.
             * 
             * Bubble sort steps below
             * 
             * 1. Compare array[0] & array[1] 2. If array[0] > array[1] swap it.
             * 3. Compare array[1] & array[2] 4. If array[1] > array[2] swap it.
             * 5. Compare array[n-1] & array[n]. 6. If [n-1] > array[n] swap it.
             * After this step we have the largest element at the last index
             * 
             * Repeat steps for array[1] to array[n-1]
             */

            int temp = 0;

            for(int i = 0; i < intArray.Length; i++)
            {
                for (int j = 0; j < intArray.Length - 1; j++)
                {
                    if (intArray[j] > intArray[j + 1])
                    {
                        temp = intArray[j + 1];
                        intArray[j + 1] = intArray[j];
                        intArray[j] = temp;
                    }
                }
            }
        }

        //Removing duplicates in array using set
        private static int[] onlyUniqueElements(int[] inputArray)
        {
            //Creating set
            HashSet<int> set = new HashSet<int>();

            //Creating temporary array
            int[] tmp = new int[inputArray.Length];
            int index = 0;

            //Using set to remove duplicates and add to new array
            foreach(int i in inputArray)
                if(set.Add(i))
                    tmp[index++] = i;
            //returning array
            return set.ToArray();
        }

        //Quicksort and comparing numbers
        private static void sortAsc(int[] x, int low, int high)
        {
            if (x == null || x.Length == 0)
                return;
            if (low >= high)
                return;

            //Picking pivot
            int middle = low + (high - low) / 2;
            int pivot = x[middle];

            //Making left < pivot and right > pivot
            int i = low, j = high;
            while (i <= j)
            {
                while (x[i] < pivot)
                {
                    i++;
                }
                while (x[j] > pivot)
                {
                    j--;
                }
                if (i <= j)
                {
                    int temp = x[i];
                    x[i] = x[j];
                    x[j] = temp;
                    i++;
                    j--;

                    //count = count + 1; //counts number of swaps when sorting
                }

            }

            //Recursively sorting two sub parts
            if (low < j)
                sortAsc(x, low, j);
            if (high < j)
                sortAsc(x, i, high);
        }

        //Random methods
        private static readonly Random getrandom = new Random();
        public static int GetRandomNumber(int min, int max)
        {
            lock(getrandom)
            {
                return getrandom.Next(min, max);
            }
        }
    }
}