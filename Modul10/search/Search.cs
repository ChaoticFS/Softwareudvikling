namespace SearchMethods
{
    public class Search
    {
        /// <summary>
        /// Finder tallet i arrayet med en lineær søgning.
        /// </summary>
        /// <param name="array">Det array der søges i.</param>
        /// <param name="tal">Det tal der skal findes.</param>
        /// <returns>Indexet for det fundne tal, eller -1 hvis det ikke findes.</returns>
        public static int FindNumberLinear(int[] array, int tal)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == tal)
                    return i;
            }
            return -1; // Returnerer -1 hvis tallet ikke findes
        }

        /// <summary>
        /// Finder tallet i arrayet med en binær søgning.
        /// </summary>
        /// <param name="array">Det array der søges i. Arrayet skal være sorteret i stigende rækkefølge.</param>
        /// <param name="tal">Det tal der skal findes.</param>
        /// <returns>Indexet for det fundne tal, eller -1 hvis det ikke findes.</returns>
        public static int FindNumberBinary(int[] array, int tal)
        {
            int left = 0;
            int right = array.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;

                if (array[mid] == tal)
                    return mid;

                if (array[mid] < tal)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return -1; // Returnerer -1 hvis tallet ikke findes
        }

        private static int[] sortedArray { get; set; } =
            new int[] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
        private static int next = 0;

        /// <summary>
        /// Indsætter et helt array. Arrayet skal være sorteret på forhånd.
        /// </summary>
        /// <param name="sortedArray">Array der skal indsættes.</param>
        /// <param name="next">Den næste ledige plads i arrayet.</param>
        public static void InitSortedArray(int[] sortedArray, int next)
        {
            Search.sortedArray = sortedArray;
            Search.next = next;
        }

        /// <summary>
        /// Indsætter et tal i et sorteret array. En kopi af arrayet returneres.
        /// Array er fortsat sorteret efter det nye tal er indsat.
        /// </summary>
        /// <param name="tal">Tallet der skal indsættes</param>
        /// <returns>En kopi af det sorterede array med det nye tal i.</returns>
        public static int[] InsertSorted(int tal)
        {
            int[] newArray = new int[next + 1]; // Opretter en ny kopi af arrayet med en størrelse, der rummer det nye tal

            int i = 0;
            int j = 0;

            // Kopierer elementer fra det oprindelige array til det nye array, indtil det rigtige sted at indsætte tallet er nået
            while (i < next && sortedArray[i] < tal)
            {
                newArray[j] = sortedArray[i];
                i++;
                j++;
            }

            // Indsætter det nye tal på det rigtige sted
            newArray[j] = tal;
            j++;

            // Kopierer resten af elementerne fra det oprindelige array til det nye array
            while (i < next)
            {
                newArray[j] = sortedArray[i];
                i++;
                j++;
            }

            sortedArray = newArray; // Opdaterer det oprindelige array med det nye array
            next++; // Opdaterer den næste ledige plads

            return newArray; // Returnerer det nye array
        }
    }
}
