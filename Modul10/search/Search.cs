namespace SearchMethods
{
    public class Search
    {
        /// <summary>
        /// Finder tallet i arrayet med en lineær søgning.
        /// </summary>
        /// <param name="array">Det array der søges i.</param>
        /// <param name="tal">Det tal der skal findes.</param>
        /// <returns></returns>
        public static int FindNumberLinear(int[] array, int tal) {
            int count = 0;
            
            foreach (int i in array)
            {
                if (i == tal)
                {
                    return count;
                }
                count++;
            }

            return -1;
        }
        /// <summary>
        /// Finder tallet i arrayet med en binær søgning.
        /// </summary>
        /// <param name="array">Det array der søges i.</param>
        /// <param name="tal">Det tal der skal findes.</param>
        /// <returns></returns>
        public static int FindNumberBinary(int[] array, int tal) {
            // L M og R = Left, Middle, Right, de bruges til at holde styr på hvor algoritmen i øjeblikket er ved at tjekke i forhold til
            int L = 0;
            int R = array.Length - 1;

            while (L <= R)
            {
                int M = (L + R) / 2;

                if (array[M] == tal)
                {
                    return M;
                }
                else if (array[M] < tal) 
                {
                    L = M + 1;
                }
                else
                {
                    R = M - 1;
                }
            }

            return -1;
        }

        /// <summary>
        /// Indsætter et tal i et sorteret array. En kopi af arrayet returneres.
        /// Array er fortsat sorteret efter det nye tal er indsat.
        /// </summary>
        /// <param name="tal">Tallet der skal indsættes</param>
        /// <returns>En kopi af det sorterede array med det nye tal i.</returns>
        public static int[] InsertSorted(int[] array, int tal) {
            if (array[array.Length - 1] == -1) //tjekker om sidste indeks er -1, altså at der er plads til insertion i arrayet
            {
                int currentIndex = 0;

                while (array[currentIndex] != -1)
                {
                    currentIndex++;
                }

                // shuffle elementer til højre indtil tallet er mindre end vores input
                while (currentIndex > 0 && tal < array[currentIndex - 1])
                {
                    array[currentIndex] = array[currentIndex - 1];
                    currentIndex--;
                }

                // indsæt tal ved tom plads
                array[currentIndex] = tal;
            }
            
            return array;
        }
    }
}