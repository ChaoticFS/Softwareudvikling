using System;
using LinkedList;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            // Opretter brugerobjekter
            User kristian = new User("Kristian", 1);
            User mads = new User("Mads", 2);
            User torill = new User("Torill", 3);
            User kell = new User("Kell", 4);
            User henrik = new User("Henrik", 5);
            User klaus = new User("Klaus", 6);

            // Opretter en ny brugerliste
            UserLinkedList list = new UserLinkedList();

            // Tilføjer brugerobjekter til listen
            list.AddFirst(kristian);
            list.AddFirst(mads);
            list.AddFirst(torill);
            list.AddFirst(henrik);
            list.AddFirst(klaus);

            // Udskriver antallet af brugere i listen
            Console.WriteLine(list.CountUsers());

            // Udskriver listen
            Console.WriteLine(list);

            // Fjerner et brugerobjekt fra listen
            list.RemoveUser(mads);

            // Fjerner det første brugerobjekt fra listen
            list.RemoveFirst();

            // Udskriver antallet af brugere i listen igen
            Console.WriteLine(list.CountUsers());

            // Udskriver listen igen
            Console.WriteLine(list);
        }
    }
}

/*
 * 
 Koden opretter brugerobjekter og demonstrerer brugen af UserLinkedList-klassen. Først oprettes en liste, 
 og brugerobjekterne tilføjes til listen ved hjælp af AddFirst-metoden. 
Derefter udskrives antallet af brugere i listen ved hjælp af CountUsers-metoden, og listen udskrives ved hjælp af ToString-metoden.

Derefter fjernes et brugerobjekt fra listen ved hjælp af RemoveUser-metoden, 
og det første brugerobjekt fjernes fra listen ved hjælp af RemoveFirst-metoden. 
Antallet af brugere i listen og listen selv udskrives igen for at vise ændringerne.
*/