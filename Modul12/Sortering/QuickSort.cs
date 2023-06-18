namespace Sortering
{
    public static class QuickSort
    {
        private static void Swap(int[] array, int k, int j)
        {
            int tmp = array[k];
            array[k] = array[j];
            array[j] = tmp;
        }

        private static void _quickSort(int[] array, int low, int high)
        {
            if (low < high)
            {
                int pivot = Partition(array, low, high);
                _quickSort(array, low, pivot - 1);
                _quickSort(array, pivot + 1, high);
            }
        }

        private static int Partition(int[] array, int low, int high)
        {
            int pivotIndex = ChoosePivot(array, low, high);
            int pivotValue = array[pivotIndex];

            // Flyt pivot til slutningen af delomr�det
            Swap(array, pivotIndex, high);

            int i = low;
            for (int j = low; j < high; j++)
            {
                if (array[j] <= pivotValue)
                {
                    Swap(array, i, j);
                    i++;
                }
            }

            // Flyt pivot til den korrekte position
            Swap(array, i, high);

            return i;
        }

        private static int ChoosePivot(int[] array, int low, int high)
        {
            // Her kan du implementere forskellige strategier til valg af pivot.
            // For eksempel kunne du v�lge et tilf�ldigt index eller et median-index.
            // I denne implementering v�lges den f�rste som pivot.
            return low;
        }

        public static void Sort(int[] array)
        {
            _quickSort(array, 0, array.Length - 1);
        }
    }
}

/*
I denne implementering af QuickSort-algoritmen bruger vi en partitionsfunktion til at opdele arrayet i to delomr�der 
baseret p� en pivot-v�rdi. I partitionsdelen v�lger vi pivot ved hj�lp af ChoosePivot-metoden. 
Du kan implementere forskellige strategier til valg af pivot afh�ngigt af dine pr�ferencer eller ydeevnebehov.

I Partition-metoden flytter vi pivot-elementet til slutningen af delomr�det og 
udf�rer partitionering ved at sammenligne hvert element med pivot og placere det mindre element til venstre og 
det st�rre element til h�jre. Til sidst flytter vi pivot til den korrekte position, hvor alle 
elementer til venstre er mindre end pivot, og alle elementer til h�jre er st�rre end pivot.

Du kan nu bruge QuickSort.Sort(array) til at sortere et array af heltal ved hj�lp af QuickSort-metoden. 
Husk at fjerne kommentartegnet (//) foran _quickSort-kaldet i Sort-metoden.
*/