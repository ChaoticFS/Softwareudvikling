namespace ordination_test;

using shared.Model;
using static shared.Util;

[TestClass]
public class OrdinationTest
{
    DateTime start;
    DateTime slut;
    Laegemiddel lm;

    [TestInitialize]
    public void InitSharedValues()
    {
        start = new DateTime(2023, 1, 1);
        slut = new DateTime(2023, 12, 12);
        lm = new Laegemiddel("Acetylsalicylsyre", 0.1, 0.15, 0.16, "Styk");
    }

    [TestMethod]
    public void TestPNFields()
    {
        double antalenheder = 1;

        PN pn = new PN(start, slut, antalenheder, lm);

        Assert.AreEqual(start, pn.startDen);
        Assert.AreEqual(slut, pn.slutDen);
        Assert.AreEqual(antalenheder, pn.antalEnheder);
        Assert.AreEqual(lm, pn.laegemiddel);
    }

    [TestMethod]
    public void TestPNDosis()
    {
        double antalenheder = 1;

        PN pn = new PN(start, slut, antalenheder, lm);

        DateTime givelsesdato = new DateTime(2023, 6, 6);
        Dato dato = new Dato { dato = givelsesdato };

        pn.givDosis(dato);

        Assert.AreEqual(1, pn.dates.Count);
    }

    [TestMethod]
    public void TestDagligFastFields()
    {
        double morgen = 1;
        double middag = 2;
        double aften = 3;
        double nat = 4;

        Dosis MorgenDosis = new Dosis(CreateTimeOnly(6, 0, 0), morgen);
        Dosis MiddagDosis = new Dosis(CreateTimeOnly(12, 0, 0), middag);
        Dosis AftenDosis = new Dosis(CreateTimeOnly(18, 0, 0), aften);
        Dosis NatDosis = new Dosis(CreateTimeOnly(23, 59, 0), nat);

        DagligFast df = new DagligFast(start, slut, lm, morgen, middag, aften, nat);

        Assert.AreEqual(start, df.startDen);
        Assert.AreEqual(slut, df.slutDen);
        Assert.AreEqual(lm, df.laegemiddel);

        // Kalder ToString fordi equals sammenligner objekterne, ikke værdierne deraf
        Assert.AreEqual(MorgenDosis.ToString(), df.MorgenDosis.ToString());
        Assert.AreEqual(MiddagDosis.ToString(), df.MiddagDosis.ToString());
        Assert.AreEqual(AftenDosis.ToString(), df.AftenDosis.ToString());
        Assert.AreEqual(NatDosis.ToString(), df.NatDosis.ToString());
    }

    [TestMethod]
    public void TestDagligFastDosis()
    {
        double morgen = 1;
        double middag = 2;
        double aften = 3;
        double nat = 4;

        DagligFast df = new DagligFast(start, slut, lm, morgen, middag, aften, nat);

        int daysDelta = (slut - start).Days + 1;
        double dosis = morgen + middag + aften + nat;

        dosis *= daysDelta;

        Assert.AreEqual(dosis, df.samletDosis(), 0.001);
    }

    [TestMethod]
    public void TestDagligSkævFields()
    {
        DagligSkæv ds = new DagligSkæv(start, slut, lm);

        Assert.AreEqual(start, ds.startDen);
        Assert.AreEqual(slut, ds.slutDen);
        Assert.AreEqual(lm, ds.laegemiddel);
    }

    [TestMethod]
    public void TestDagligSkævOpretDose()
    {
        DagligSkæv ds = new DagligSkæv(start, slut, lm);

        DateTime dosis = CreateTimeOnly(12, 0, 0);

        ds.opretDosis(dosis, 1);

        Assert.AreEqual(1, ds.doser.Count);
    }
}