using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinkedList.Tests
{
    [TestClass]
    public class LinkedList_Tests
    {
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
