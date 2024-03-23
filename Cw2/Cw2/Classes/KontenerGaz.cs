using Cw2.Interfaces;

namespace Cw2.Classes;

public class KontenerGaz : Kontener, IHazardNotifier
{
    public KontenerGaz(
        double wysokosc,
        double wagaWlasna,
        double glebokosc,
        double maksymalnaLadownosc
    ) : base( wysokosc, wagaWlasna, glebokosc, maksymalnaLadownosc)
    {
        numerSeryjny = "KON-G-" + ++ostatniNumerSeryjny;
    }

    new public void OproznienieLadunku()
    {
        masaLadunku *= 0.05;
    }

    public void niebezpiecznaSytuacja()
    {
        Console.WriteLine("Niebezpieczna sytuacja: "+numerSeryjny);
    }
}