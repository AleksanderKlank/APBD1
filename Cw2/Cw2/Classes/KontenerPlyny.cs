using Cw2.Exceptions;
using Cw2.Interfaces;

namespace Cw2.Classes;

public class KontenerPlyny : Kontener, IHazardNotifier
{
    public bool niebezpiecznyLadunek;
    public KontenerPlyny(
        double wysokosc,
        double wagaWlasna,
        double glebokosc,
        double maksymalnaLadownosc
        ) : base( wysokosc, wagaWlasna, glebokosc, maksymalnaLadownosc)
    {
        numerSeryjny = "KON-L-" + ++ostatniNumerSeryjny;
        niebezpiecznyLadunek = false;
    }


    new public void ZaladowanieKontenera(string ladunek, double masa)
    {
        if (niebezpiecznyLadunek)
        {
            if (masaLadunku + masa > maksymalnaLadownosc * 0.5)
            {
                niebezpiecznaSytuacja();
            }
            else
            {
                masaLadunku += masa;
            }
        }
        else
        {
            if (masaLadunku + masa > maksymalnaLadownosc * 0.9)
            {   
                niebezpiecznaSytuacja();
            }
            else
            {
                masaLadunku += masa;
            }
        }
    }
    public void ZaladowanieKontenera(string ladunek, double masa, bool czyNiebezpiecznyLadunek)
    {
        niebezpiecznyLadunek = czyNiebezpiecznyLadunek;
        ZaladowanieKontenera(ladunek,masa);
    }

    public void niebezpiecznaSytuacja()
    {
        Console.WriteLine("Proba wykonania niebezpiecznej operacji! - "+numerSeryjny);
    }
}