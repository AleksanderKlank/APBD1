using Cw2.Exceptions;

namespace Cw2;

public abstract class Kontener
{
    public double
        masaLadunku,
        wysokosc,
        wagaWlasna,
        glebokosc,
        maksymalnaLadownosc;

    public string numerSeryjny;
    public static int ostatniNumerSeryjny;

    public Kontener(double wysokosc, double wagaWlasna, double glebokosc, double maksymalnaLadownosc)
    {
        this.masaLadunku = 0;
        this.wysokosc = wysokosc;
        this.wagaWlasna = wagaWlasna;
        this.glebokosc = glebokosc;
        this.maksymalnaLadownosc = maksymalnaLadownosc;
    }

    public void OproznienieLadunku()
    {
        masaLadunku = 0;
    }

    public void ZaladowanieKontenera(string ladunek, double masa)
    {
        if (masaLadunku + masa > maksymalnaLadownosc)
        {
            throw new OverfillException();
        }
        else
        {
            masaLadunku += masa;
        }
    }

    public override string ToString()
    {
        return numerSeryjny+" -  masaladunku: "+masaLadunku
               + "kg, wysokosc: "+wysokosc+"cm, wagaWlasna: "
               +wagaWlasna+"kg, glebokosc: "+glebokosc
               +"cm, maksymalna ladownosc: "+maksymalnaLadownosc+"kg";
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || this.GetType() != obj.GetType())
        {
            return false;
        }

        Kontener kontener = (Kontener)obj;

        return (numerSeryjny == kontener.numerSeryjny);
    }
}