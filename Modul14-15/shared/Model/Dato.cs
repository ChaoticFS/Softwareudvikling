namespace shared.Model;

public class Dato {
    public int DatoId { get; set; }
    public DateTime dato { get; set; }

    // tjekker om datoen er indenfor den givne tidsramme
    public bool erIndenfor(DateTime startDen, DateTime slutDen)
    {
        if (startDen <= dato && dato <= slutDen)
        {
            return true;
        }
        return false;
    }
}