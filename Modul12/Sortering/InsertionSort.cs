namespace Sortering
{
    public class InsertionSort
    {
        public static void Sort(int[] array)
        {
            // Start fra andet element (indeks 1) og genneml�b arrayet
            for (int i = 1; i < array.Length; i++)
            {
                int key = array[i]; // V�lg det aktuelle element som n�gle
                int j = i - 1;

                // Flyt elementer st�rre end n�glen til h�jre
                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j--;
                }

                array[j + 1] = key; // Inds�t n�glen p� den rigtige position
            }
        }
    }
}

/*
Forklaring:
Insertion Sort-algoritmen fungerer ved at opdele arrayet i to dele: det sorterende omr�de og
det ubesortede omr�de. Ved starten af algoritmen antages det, at det f�rste element allerede er i det sorterende omr�de. Derefter tages hvert efterf�lgende element i det ubesortede omr�de og inds�ttes p� den rigtige position i det sorterende omr�de ved at sammenligne og flytte elementer.

Kommentar til koden:

Vi starter ved indeks 1, da det f�rste element allerede anses for at v�re i det sorterende omr�de.
Vi v�lger det aktuelle element som n�gle.
Vi initialiserer en variabel j til at v�re indekset af det forrige element.
Vi flytter elementer st�rre end n�glen til h�jre for at g�re plads til inds�ttelse af n�glen.
Vi inds�tter n�glen p� den rigtige position i det sorterende omr�de.
Denne proces gentages for hvert efterf�lgende element i det ubesortede omr�de, indtil hele arrayet er sorteret.
Efter implementeringen af Insertion Sort-algoritmen kan du kalde InsertionSort.Sort(array) for at sortere et array af heltal ved hj�lp af Insertion Sort-metoden.
*/