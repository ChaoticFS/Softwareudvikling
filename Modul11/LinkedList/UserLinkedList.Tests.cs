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

            // Tilføjer brugerobjektet som det første element i listen
            list.AddFirst(kristian);

            // Kontrollerer, om den første bruger i listen er den samme som den tilføjede bruger
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

            // Tilføjer brugerobjekterne til listen som de første elementer
            list.AddFirst(kristian);
            list.AddFirst(mads);
            list.AddFirst(torill);

            // Kontrollerer, om det første fjernede element er det forventede brugerobjekt
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

            // Tilføjer brugerobjekterne til listen som de første elementer
            list.AddFirst(kristian);
            list.AddFirst(mads);
            list.AddFirst(torill);

            // Kontrollerer, om antallet af brugere i listen er det forventede
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

            // Tilføjer brugerobjekterne til listen som de første elementer
            list.AddFirst(kristian);
            list.AddFirst(mads);
            list.AddFirst(torill);
            list.AddFirst(henrik);
            list.AddFirst(klaus);

            // Fjerner en bruger fra listen og kontrollerer, om antallet af brugere er korrekt
            list.RemoveUser(mads);
            Assert.AreEqual(4, list.CountUsers());

            // Fjerner en anden bruger fra listen og kontrollerer, om antallet af brugere er korrekt
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

            // Tilføjer brugerobjekterne til listen som de første elementer
            list.AddFirst(kristian);
            list.AddFirst(mads);
            list.AddFirst(torill);
            list.AddFirst(henrik);
            list.AddFirst(klaus);

            // Kontrollerer, om den sidste bruger i listen er den forventede
            Assert.AreEqual(kristian.Name, list.GetLast().Name);
        }

        [TestMethod]
        public void TestContains()
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

            // Kontrollerer, om listen indeholder de forventede brugerobjekter
            Assert.IsTrue(list.Contains(kristian));
            Assert.IsTrue(list.Contains(mads));
            Assert.IsTrue(list.Contains(torill));
            Assert.IsFalse(list.Contains(klaus));
        }
    }
}
