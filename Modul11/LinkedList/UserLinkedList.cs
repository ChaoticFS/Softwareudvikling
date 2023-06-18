namespace LinkedList
{
    class Node
    {
        public Node(User data, Node next)
        {
            this.Data = data;
            this.Next = next;
        }
        public User Data;
        public Node Next;
    }

    class UserLinkedList
    {
        private Node first = null!;

        // Tilføjer et brugerobjekt som det første element i listen
        public void AddFirst(User user)
        {
            Node node = new Node(user, first);
            first = node;
        }

        // Fjerner det første element i listen og returnerer det
        public User RemoveFirst()
        {
            if (first == null)
            {
                throw new InvalidOperationException("The list is empty.");
            }

            User removedUser = first.Data;
            first = first.Next;
            return removedUser;
        }

        // Fjerner et specifikt brugerobjekt fra listen
        public void RemoveUser(User user)
        {
            Node node = first;
            Node previous = null!;
            bool found = false;

            while (!found && node != null)
            {
                if (node.Data.Name == user.Name)
                {
                    found = true;
                    if (node == first)
                    {
                        RemoveFirst();
                    }
                    else
                    {
                        previous.Next = node.Next;
                    }
                }
                else
                {
                    previous = node;
                    node = node.Next;
                }
            }
        }

        // Returnerer det første brugerobjekt i listen
        public User GetFirst()
        {
            return first.Data;
        }

        // Returnerer det sidste brugerobjekt i listen
        public User GetLast()
        {
            if (first == null)
            {
                throw new InvalidOperationException("The list is empty.");
            }

            Node currentNode = first;
            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }

            return currentNode.Data;
        }

        // Returnerer antallet af brugere i listen
        public int CountUsers()
        {
            int count = 0;
            Node currentNode = first;

            while (currentNode != null)
            {
                count++;
                currentNode = currentNode.Next;
            }

            return count;
        }

        // Returnerer en strengrepræsentation af listen
        public override String ToString()
        {
            Node node = first;
            String result = "";
            while (node != null)
            {
                result += node.Data.Name + ", ";
                node = node.Next;
            }
            return result.Trim();
        }

        // Kontrollerer om listen indeholder et specifikt brugerobjekt
        public bool Contains(User user)
        {
            Node node = first;
            while (node != null)
            {
                if (node.Data.Equals(user))
                {
                    return true;
                }
                node = node.Next;
            }
            return false;
        }

    }
}


/*
AddFirst(User user): O(1) - Tilføjelse af et element i starten af listen kræver kun konstant tid, da det kun indebærer oprettelsen af en ny knude og opdateringen af referencer.

RemoveFirst(): O(1) - Fjernelse af det første element i listen tager konstant tid, da det kun indebærer opdatering af referencer.

RemoveUser(User user): O(n) - Fjernelse af et specifikt element i listen kræver en lineær søgning efter elementet, hvilket tager tid proportionalt med antallet af elementer i listen.

GetFirst(): O(1) - Hentning af det første element i listen tager konstant tid, da det kun involverer at få adgang til den første knude.

GetLast(): O(n) - Hentning af det sidste element i listen kræver en lineær søgning gennem hele listen for at finde den sidste knude.

CountUsers(): O(n) - Tælling af antallet af elementer i listen kræver en lineær gennemgang af alle knuder i listen for at tælle dem alle.

ToString(): O(n) - Konvertering af listen til en streng indebærer en lineær gennemgang af alle knuder for at sammensætte strengen.
*/
