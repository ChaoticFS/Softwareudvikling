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

            // Kopier de to delomr�der til den midlertidige hj�lpearray
            for (int i = low; i <= high; i++)
            {
                temp[i] = array[i];
            }

            int left = low;     // Startindeks for venstre delomr�de
            int right = middle + 1;  // Startindeks for h�jre delomr�de
            int current = low;  // Startindeks for sammenl�gningen

            // Sammenl�g de to delomr�der i den oprindelige array
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

            // Kopier resterende elementer fra venstre delomr�de til den oprindelige array
            while (left <= middle)
            {
                array[current] = temp[left];
                left++;
                current++;
            }

            // Bem�rk: Elementer fra h�jre delomr�de kopieres ikke,
            // da de allerede er p� deres rette plads i den oprindelige array
        }
    }
}
/*
I denne implementering bruger vi en hj�lpearray (temp) til at gemme de to delomr�der, som vi �nsker at sammenl�gge.
Vi kopierer elementerne fra de to delomr�der til hj�lpearrayet og udf�rer derefter sammenl�gningen ved at sammenligne elementerne
fra de to delomr�der og placere dem i den oprindelige array i den korrekte r�kkef�lge.

Denne Merge-metode bliver kaldt rekursivt som en del af MergeSort-algoritmen og 
hj�lper med at flette de sorterede delomr�der sammen for at opn� den endelige sorteringsr�kkef�lge.
*/