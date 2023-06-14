namespace ordination_test;

using shared.Model;

[TestClass]
public class LaegemiddelTest
{
    Laegemiddel lm;

    string navn;
    double enhedLet;
    double enhedNormal;
    double enhedTung;
    string enhed;

    [TestInitialize]
    public void InitTest()
    {
        navn = "Paracetamol";
        enhedLet = 1;
        enhedNormal = 1.5;
        enhedTung = 2;
        enhed = "Ml";

        lm = new Laegemiddel(navn, enhedLet, enhedNormal, enhedTung, enhed);
    }

    [TestMethod]
    public void TestFields()
    {
        Assert.AreEqual(navn, lm.navn);
        Assert.AreEqual(enhedLet, lm.enhedPrKgPrDoegnLet);
        Assert.AreEqual(enhedNormal, lm.enhedPrKgPrDoegnNormal);
        Assert.AreEqual(enhedTung, lm.enhedPrKgPrDoegnTung);
        Assert.AreEqual(enhed, lm.enhed);
    }
}