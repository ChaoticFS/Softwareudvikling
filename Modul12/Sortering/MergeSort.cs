namespace Sortering
{
    public static class MergeSort
    {
        public static void Sort(int[] array)
        {
            _mergeSort(array, 0, array.Length - 1);
        }

        private static void _mergeSort(int[] array, int l, int h)
        {
            if (l < h)
            {
                int m = (l + h) / 2;
                _mergeSort(array, l, m);
                _mergeSort(array, m + 1, h);
                Merge(array, l, m, h);
            }
        }

        private static void Merge(int[] array, int low, int middle, int high)
        {
            int[] temp = new int[array.Length];

            // Kopier de to delområder til den midlertidige hjælpearray
            for (int i = low; i <= high; i++)
            {
                temp[i] = array[i];
            }

            int left = low;     // Startindeks for venstre delområde
            int right = middle + 1;  // Startindeks for højre delområde
            int current = low;  // Startindeks for sammenlægningen

            // Sammenlæg de to delområder i den oprindelige array
            while (left <= middle && right <= high)
            {
                if (temp[left] <= temp[right])
                {
                    array[current] = temp[left];
                    left++;
                }
                else
                {
                    array[current] = temp[right];
                    right++;
                }
                current++;
            }

            // Kopier resterende elementer fra venstre delområde til den oprindelige array
            while (left <= middle)
            {
                array[current] = temp[left];
                left++;
                current++;
            }

            // Bemærk: Elementer fra højre delområde kopieres ikke,
            // da de allerede er på deres rette plads i den oprindelige array
        }
    }
}
/*
I denne implementering bruger vi en hjælpearray (temp) til at gemme de to delområder, som vi ønsker at sammenlægge.
Vi kopierer elementerne fra de to delområder til hjælpearrayet og udfører derefter sammenlægningen ved at sammenligne elementerne
fra de to delområder og placere dem i den oprindelige array i den korrekte rækkefølge.

Denne Merge-metode bliver kaldt rekursivt som en del af MergeSort-algoritmen og 
hjælper med at flette de sorterede delområder sammen for at opnå den endelige sorteringsrækkefølge.
*/