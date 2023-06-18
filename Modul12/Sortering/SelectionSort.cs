namespace Sortering
{
    public class SelectionSort
    {
        private static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        public static void Sort(int[] array)
        {
            // Genneml�b arrayet og marker den mindste v�rdi i hvert trin
            for (int i = 0; i < array.Length - 1; i++)
            {
                int minIndex = i;

                // Find det mindste element i det ubesortede omr�de
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }

                // Byt det mindste element med det f�rste element i det ubesortede omr�de
                Swap(array, i, minIndex);
            }
        }
    }
}

/*
Forklaring:
Selection Sort-algoritmen fungerer ved at opdele arrayet i to dele: det sorterende omr�de og det ubesortede omr�de. 
I hvert trin markeres det mindste element i det ubesortede omr�de og byttes med det f�rste element i det ubesortede omr�de. Derved vokser det sorterende omr�de, mens det ubesortede omr�de formindskes.

Kommentar til koden:
Vi genneml�ber arrayet fra 0 til array.Length - 1.
Vi antager, at det f�rste element i det ubesortede omr�de er det mindste og markerer det som minIndex.
Vi s�ger efter det mindste element i det ubesortede omr�de ved at sammenligne det med de efterf�lgende elementer.
Hvis vi finder et mindre element, opdaterer vi minIndex til det mindste elements indeks.
N�r vi har gennemg�et hele det ubesortede omr�de, bytter vi det mindste element med det f�rste element i det ubesortede omr�de ved at kalde Swap-metoden.
Dette gentages, indtil hele arrayet er sorteret.
Efter implementeringen af Selection Sort-algoritmen kan du kalde SelectionSort.Sort(array) for at sortere et array af heltal ved hj�lp af Selection Sort-metoden.
*/