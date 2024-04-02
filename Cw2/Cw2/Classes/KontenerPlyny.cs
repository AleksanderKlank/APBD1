using Cw2.Exceptions;
using Cw2.Interfaces;

namespace Cw2.Classes;

public class KontenerPlyny : Kontener, IHazardNotifier
{
    private bool _niebezpiecznyLadunek;
    public KontenerPlyny(
        double wysokosc,
        double wagaWlasna,
        double glebokosc,
        double maksymalnaLadownosc
        ) : base( wysokosc, wagaWlasna, glebokosc, maksymalnaLadownosc)
    {
        numerSeryjny = "KON-L-" + ++ostatniNumerSeryjny;
        _niebezpiecznyLadunek = false;
    }


    new public void ZaladowanieKontenera(string ladunek, double masa)
    {
        if (_niebezpiecznyLadunek)
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
        _niebezpiecznyLadunek = czyNiebezpiecznyLadunek;
        ZaladowanieKontenera(ladunek,masa);
    }

    public void niebezpiecznaSytuacja()
    {
        Console.WriteLine("Proba wykonania niebezpiecznej operacji! - "+numerSeryjny);
    }
}