namespace Sortering
{
    public class InsertionSort
    {
        public static void Sort(int[] array)
        {
            // Start fra andet element (indeks 1) og gennemløb arrayet
            for (int i = 1; i < array.Length; i++)
            {
                int key = array[i]; // Vælg det aktuelle element som nøgle
                int j = i - 1;

                // Flyt elementer større end nøglen til højre
                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j--;
                }

                array[j + 1] = key; // Indsæt nøglen på den rigtige position
            }
        }
    }
}

/*
Forklaring:
Insertion Sort-algoritmen fungerer ved at opdele arrayet i to dele: det sorterende område og
det ubesortede område. Ved starten af algoritmen antages det, at det første element allerede er i det sorterende område. Derefter tages hvert efterfølgende element i det ubesortede område og indsættes på den rigtige position i det sorterende område ved at sammenligne og flytte elementer.

Kommentar til koden:

Vi starter ved indeks 1, da det første element allerede anses for at være i det sorterende område.
Vi vælger det aktuelle element som nøgle.
Vi initialiserer en variabel j til at være indekset af det forrige element.
Vi flytter elementer større end nøglen til højre for at gøre plads til indsættelse af nøglen.
Vi indsætter nøglen på den rigtige position i det sorterende område.
Denne proces gentages for hvert efterfølgende element i det ubesortede område, indtil hele arrayet er sorteret.
Efter implementeringen af Insertion Sort-algoritmen kan du kalde InsertionSort.Sort(array) for at sortere et array af heltal ved hjælp af Insertion Sort-metoden.
*/