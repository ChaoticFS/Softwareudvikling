namespace shared.Model;

public class PN : Ordination
{
    public double antalEnheder { get; set; }
    public List<Dato> dates { get; set; } = new List<Dato>();

    public PN(DateTime startDen, DateTime slutDen, double antalEnheder, Laegemiddel laegemiddel) : base(laegemiddel, startDen, slutDen)
    {
        this.antalEnheder = antalEnheder;
    }

    public PN() : base(null!, new DateTime(), new DateTime())
    {
    }

    /// <summary>
    /// Registrerer at der er givet en dosis på dagen givesDen
    /// Returnerer true hvis givesDen er inden for ordinationens gyldighedsperiode og datoen huskes
    /// Returner false ellers og datoen givesDen ignoreres
    /// </summary>
    public bool givDosis(Dato givesDen)
    {
        if (givesDen.erIndenfor(startDen, slutDen))
        {
            dates.Add(givesDen);
            return true;
        }
        return false;
    }

    public override double doegnDosis()
    {
        //laver bare en homebrewet min/max function herinde fordi den esoteric dato model smadrer built in datetime funktioner
        if (dates.Count == 1)
        {
            return antalEnheder;
        }
        else if (dates.Count == 0)
        {
            return 0;
        }

        DateTime min = dates[0].dato;
        DateTime max = dates[0].dato;

        foreach (var date in dates.Skip(1))
        {
            if (date.dato < min)
            {
                min = date.dato;
            }

            if (date.dato > max) 
            {  
                max = date.dato; 
            }
        }

        double result = dates.Count * antalEnheder;

        result /= (max - min).TotalDays + 1;

        return result;
    }

    public override double samletDosis()
    {
        return dates.Count * antalEnheder;
    }

    public int getAntalGangeGivet()
    {
        return dates.Count;
    }

    public override String getType()
    {
        return "PN";
    }

}