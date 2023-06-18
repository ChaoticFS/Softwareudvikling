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
            // Gennemløb arrayet og marker den mindste værdi i hvert trin
            for (int i = 0; i < array.Length - 1; i++)
            {
                int minIndex = i;

                // Find det mindste element i det ubesortede område
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }

                // Byt det mindste element med det første element i det ubesortede område
                Swap(array, i, minIndex);
            }
        }
    }
}

/*
Forklaring:
Selection Sort-algoritmen fungerer ved at opdele arrayet i to dele: det sorterende område og det ubesortede område. 
I hvert trin markeres det mindste element i det ubesortede område og byttes med det første element i det ubesortede område. Derved vokser det sorterende område, mens det ubesortede område formindskes.

Kommentar til koden:
Vi gennemløber arrayet fra 0 til array.Length - 1.
Vi antager, at det første element i det ubesortede område er det mindste og markerer det som minIndex.
Vi søger efter det mindste element i det ubesortede område ved at sammenligne det med de efterfølgende elementer.
Hvis vi finder et mindre element, opdaterer vi minIndex til det mindste elements indeks.
Når vi har gennemgået hele det ubesortede område, bytter vi det mindste element med det første element i det ubesortede område ved at kalde Swap-metoden.
Dette gentages, indtil hele arrayet er sorteret.
Efter implementeringen af Selection Sort-algoritmen kan du kalde SelectionSort.Sort(array) for at sortere et array af heltal ved hjælp af Selection Sort-metoden.
*/