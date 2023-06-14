namespace shared.Model;

public class DagligSkæv : Ordination
{
    public List<Dosis> doser { get; set; } = new List<Dosis>();

    public DagligSkæv(DateTime startDen, DateTime slutDen, Laegemiddel laegemiddel) : base(laegemiddel, startDen, slutDen)
    {
    }

    public DagligSkæv(DateTime startDen, DateTime slutDen, Laegemiddel laegemiddel, Dosis[] doser) : base(laegemiddel, startDen, slutDen)
    {
        this.doser = doser.ToList();
    }

    public DagligSkæv() : base(null!, new DateTime(), new DateTime())
    {
    }

    public void opretDosis(DateTime tid, double antal)
    {
        doser.Add(new Dosis(tid, antal));
    }

    public override double samletDosis()
    {
        return antalDage() * doegnDosis();
    }

    public override double doegnDosis()
    {
        double totalDosis = 0;
        foreach (Dosis dosis in doser)
        {
            totalDosis += dosis.antal;
        }
        return totalDosis;
    }


    public override String getType()
    {
        return "DagligSkæv";
    }
}
