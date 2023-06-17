using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinkedList.Tests
{
    [TestClass]
    public class LinkedList_Tests
    {
        /*TestAddFirst: Denne metode tester, om AddFirst-metoden
        fungerer korrekt ved at tilf�je en bruger som det f�rste element i listen og derefter kontrollere,
        om den f�rste bruger i listen er den samme som den tilf�jede bruger.*/
        [TestMethod]
        public void TestAddFirst()
        {
            // Opretter brugerobjekter
            User kristian = new User("Kristian", 1);
            User mads = new User("Mads", 2);
            User torill = new User("Torill", 3);

            // Opretter en brugerlinket liste
            UserLinkedList list = new UserLinkedList();

            // Tilf�jer brugerobjektet som den f�rste i listen
            list.AddFirst(kristian);

            // Tester om den f�rste bruger i listen er den samme som den tilf�jede bruger
            Assert.AreEqual(kristian, list.GetFirst());
        }
        /*
        TestRemoveFirst: Denne metode tester, om RemoveFirst-metoden fungerer korrekt ved at
        tilf�je flere brugere til listen og derefter fjerne den f�rste bruger.
        Testen kontrollerer, om den fjernede bruger er den forventede.*/
        [TestMethod]
        public void TestRemoveFirst()
        {
            // Opretter brugerobjekter
            User kristian = new User("Kristian", 1);
            User mads = new User("Mads", 2);
            User torill = new User("Torill", 3);

            // Opretter en brugerlinket liste
            UserLinkedList list = new UserLinkedList();

            // Tilf�jer brugerobjekterne til listen som de f�rste elementer
            list.AddFirst(kristian);
            list.AddFirst(mads);
            list.AddFirst(torill);

            // Fjerner den f�rste bruger fra listen og tester om den fjernede bruger er den forventede
            Assert.AreEqual(torill, list.RemoveFirst());
        }

        /*TestCountUsers: Denne metode tester, om CountUsers-metoden returnerer det korrekte
        antal brugere i listen.Den tilf�jer flere brugere til listen og kontrollerer,
        om antallet af brugere er det forventede.*/
        [TestMethod]
        public void TestCountUsers()
        {
            // Opretter brugerobjekter
            User kristian = new User("Kristian", 1);
            User mads = new User("Mads", 2);
            User torill = new User("Torill", 3);

            // Opretter en brugerlinket liste
            UserLinkedList list = new UserLinkedList();

            // Tilf�jer brugerobjekterne til listen som de f�rste elementer
            list.AddFirst(kristian);
            list.AddFirst(mads);
            list.AddFirst(torill);

            // Tester om antallet af brugere i listen er det forventede antal
            Assert.AreEqual(3, list.CountUsers());
        }
        /*
        TestRemoveUser: Denne metode tester, om RemoveUser-metoden fungerer korrekt ved at tilf�je flere brugere
        til listen og derefter fjerne en bruger.
        Testen kontrollerer, om antallet af brugere i listen er korrekt efter fjernelsen.*/
        [TestMethod]
        public void TestRemoveUser()
        {
            // Opretter brugerobjekter
            User kristian = new User("Kristian", 1);
            User mads = new User("Mads", 2);
            User torill = new User("Torill", 3);
            User henrik = new User("Henrik", 5);
            User klaus = new User("Klaus", 6);

            // Opretter en brugerlinket liste
            UserLinkedList list = new UserLinkedList();

            // Tilf�jer brugerobjekterne til listen som de f�rste elementer
            list.AddFirst(kristian);
            list.AddFirst(mads);
            list.AddFirst(torill);
            list.AddFirst(henrik);
            list.AddFirst(klaus);

            // Fjerner en bruger fra listen og tester om antallet af brugere er det forventede antal
            list.RemoveUser(mads);
            Assert.AreEqual(4, list.CountUsers());

            // Fjerner en anden bruger fra listen og tester igen om antallet af brugere er det forventede antal
            list.RemoveUser(kristian);
            Assert.AreEqual(3, list.CountUsers());
        }

        /*TestGetLast: Denne metode tester, om GetLast-metoden returnerer 
        den korrekte sidste bruger i listen.Den tilf�jer flere brugere til listen og
        kontrollerer, om den sidste bruger i listen er den forventede.*/
        [TestMethod]
        public void TestGetLast()
        {
            // Opretter brugerobjekter
            User kristian = new User("Kristian", 1);
            User mads = new User("Mads", 2);
            User torill = new User("Torill", 3);
            User henrik = new User("Henrik", 5);
            User klaus = new User("Klaus", 6);

            // Opretter en brugerlinket liste
            UserLinkedList list = new UserLinkedList();

            // Tilf�jer brugerobjekterne til listen som de f�rste elementer
            list.AddFirst(kristian);
            list.AddFirst(mads);
            list.AddFirst(torill);
            list.AddFirst(henrik);
            list.AddFirst(klaus);

            // Tester om den sidste bruger i listen er den forventede bruger
            Assert.AreEqual(kristian.Name, list.GetLast().Name);
        }
    }
}
