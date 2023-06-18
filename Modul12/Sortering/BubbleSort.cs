using System;
using System.Diagnostics;

namespace Sortering
{
    public class BubbleSort
    {
        private static void Swap(int[] array, int i, int j)
        {
            // Swapper elementerne på position i og j i arrayet
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        public static void Sort(int[] array)
        {
            int n = array.Length;

            // Itererer gennem arrayet n-1 gange
            for (int i = 0; i < n - 1; i++)
            {
                // For hvert gennemløb reduceres det ubesortede område med 1
                // og det største element i det ubesortede område "bobler" op til højre
                for (int j = 0; j < n - i - 1; j++)
                {
                    // Sammenligner hvert element med dets nabo
                    // Hvis det aktuelle element er større end dets nabo, byttes de
                    if (array[j] > array[j + 1])
                    {
                        Swap(array, j, j + 1);
                    }
                }
            }
        }

        public static void RunPerformanceTest()
        {
            int[] array = GenerateRandomArray(10000);
            Stopwatch stopwatch = new Stopwatch();

            Console.WriteLine("Bubble Sort Performance Test");
            Console.WriteLine("Array Size: 10000");

            stopwatch.Start();

            Sort(array);

            stopwatch.Stop();

            TimeSpan elapsedTime = stopwatch.Elapsed;
            Console.WriteLine("Elapsed Time: " + elapsedTime.TotalMilliseconds + " ms");
        }

        private static int[] GenerateRandomArray(int size)
        {
            int[] array = new int[size];
            Random random = new Random();

            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(100);
            }

            return array;
        }

        public static void Main(string[] args)
        {
            RunPerformanceTest();
        }
    }
}


/*
I Bubble Sort-algoritmen refererer "n-1 gange" til antallet af iterationer, hvor hvert element i arrayet sammenlignes og 
flyttes, når det er nødvendigt. Her er en forklaring:

I Bubble Sort-algoritmen er det nødvendigt at gennemløbe arrayet flere gange for at sikre, 
at alle elementer er placeret i den rigtige rækkefølge. Ved starten af hver iteration reduceres størrelsen af det ubesortede område med 1, 
da det største element i det ubesortede område "bobler" op til højre side af arrayet i hver iteration.

Antallet af iterationer er bestemt af antallet af elementer i arrayet. 
Hvis arrayet har n elementer, udføres der typisk n-1 iterationer. Dette skyldes, 
at efter den første iteration er det største element allerede blevet flyttet til den rigtige position. 
Ved hver efterfølgende iteration er det største element allerede placeret, og det ubesortede område reduceres med 1. 
Så antallet af iterationer bliver n-1 for at sikre, at alle elementer er blevet sorteret korrekt.

For eksempel, hvis der er 5 elementer i arrayet, vil Bubble Sort-algoritmen udføre 4 iterationer (n-1).
 Ved hver iteration sammenlignes og byttes elementer for at placere dem i den rigtige rækkefølge, indtil hele arrayet er sorteret.
*/
