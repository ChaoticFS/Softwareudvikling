namespace ordination_test;

using shared.Model;

[TestClass]
public class DatoTest
{
    [TestMethod]
    public void TestComparisonMethod()
    {
        DateTime before = new DateTime(2023, 1, 1);
        DateTime after = new DateTime(2023, 12, 12);

        DateTime between = new DateTime(2023, 6, 6);

        Dato dt = new Dato { dato = between };

        Assert.IsTrue(dt.erIndenfor(before, after));
    }
}