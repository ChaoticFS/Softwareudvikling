namespace ordination_test;

using shared.Model;

[TestClass]
public class PatientTest
{
    string cpr;
    string navn;
    double vægt;

    Patient patient;

    [TestInitialize]
    public void InitTest()
    {
        cpr = "160563-1234";
        navn = "John";
        vægt = 83;

        patient = new Patient(cpr, navn, vægt);
    }

    [TestMethod]
    public void PatientHasName()
    {
        Assert.AreEqual(navn, patient.navn);
    }

    [TestMethod]
    public void TestForkertNavn()
    {
        Assert.AreNotEqual("Egon", patient.navn);
    }
}