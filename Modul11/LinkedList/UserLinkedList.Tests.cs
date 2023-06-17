using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinkedList.Tests
{
    [TestClass]
    public class LinkedList_Tests
    {
        /*TestAddFirst: Denne metode tester, om AddFirst-metoden
        fungerer korrekt ved at tilføje en bruger som det første element i listen og derefter kontrollere,
        om den første bruger i listen er den samme som den tilføjede bruger.*/
        [TestMethod]
        public void TestAddFirst()
        {
            // Opretter brugerobjekter
            User kristian = new User("Kristian", 1);
            User mads = new User("Mads", 2);
            User torill = new User("Torill", 3);

            // Opretter en brugerlinket liste
            UserLinkedList list = new UserLinkedList();

            // Tilføjer brugerobjektet som den første i listen
            list.AddFirst(kristian);

            // Tester om den første bruger i listen er den samme som den tilføjede bruger
            Assert.AreEqual(kristian, list.GetFirst());
        }
        /*
        TestRemoveFirst: Denne metode tester, om RemoveFirst-metoden fungerer korrekt ved at
        tilføje flere brugere til listen og derefter fjerne den første bruger.
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

            // Tilføjer brugerobjekterne til listen som de første elementer
            list.AddFirst(kristian);
            list.AddFirst(mads);
            list.AddFirst(torill);

            // Fjerner den første bruger fra listen og tester om den fjernede bruger er den forventede
            Assert.AreEqual(torill, list.RemoveFirst());
        }

        /*TestCountUsers: Denne metode tester, om CountUsers-metoden returnerer det korrekte
        antal brugere i listen.Den tilføjer flere brugere til listen og kontrollerer,
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

            // Tilføjer brugerobjekterne til listen som de første elementer
            list.AddFirst(kristian);
            list.AddFirst(mads);
            list.AddFirst(torill);

            // Tester om antallet af brugere i listen er det forventede antal
            Assert.AreEqual(3, list.CountUsers());
        }
        /*
        TestRemoveUser: Denne metode tester, om RemoveUser-metoden fungerer korrekt ved at tilføje flere brugere
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

            // Tilføjer brugerobjekterne til listen som de første elementer
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
        den korrekte sidste bruger i listen.Den tilføjer flere brugere til listen og
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

            // Tilføjer brugerobjekterne til listen som de første elementer
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
