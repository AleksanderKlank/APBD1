namespace Cw2.Classes;

public class KontenerChlodniczy : Kontener
{
    public KontenerChlodniczy(
        double wysokosc,
        double wagaWlasna,
        double glebokosc,
        double maksymalnaLadownosc
    ) : base( wysokosc, wagaWlasna, glebokosc, maksymalnaLadownosc)
    {
        numerSeryjny = "KON-C-" + ++ostatniNumerSeryjny;
    }

    new public void OproznienieLadunku()
    {
        masaLadunku = 0;
    }
    
}