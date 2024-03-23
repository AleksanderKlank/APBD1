using System.Collections;

namespace Cw2.Classes;

public class KontenerChlodniczy : Kontener
{
    public double temperatura;
    public List<string> towary;
    public Dictionary<string, double> productTemperatures = new Dictionary<string, double>()
    {
        {"Bananas", 13.3},
        {"Chocolate", 18},
        {"Fish", 2},
        {"Meat", -15},
        {"Ice cream", -18},
        {"Frozen pizza", -30},
        {"Cheese", 7.2},
        {"Sausages", 5},
        {"Butter", 20.5},
        {"Eggs", 19}
    };
    public KontenerChlodniczy(
        double wysokosc,
        double wagaWlasna,
        double glebokosc,
        double maksymalnaLadownosc,
        double temperatura
    ) : base( wysokosc, wagaWlasna, glebokosc, maksymalnaLadownosc)
    {
        numerSeryjny = "KON-C-" + ++ostatniNumerSeryjny;
        towary = new List<string>();
        this.temperatura = temperatura;
    }

    new public void OproznienieLadunku()
    {
        masaLadunku = 0;
    }

    new public void ZaladowanieKontenera(string ladunek, double masa, double temperaturaLadunku)
    {
        if (towary.Count > 0)
        {
            if (towary.Contains(ladunek))
            {
                base.ZaladowanieKontenera(ladunek, masa);
            }
            else
            {
                Console.WriteLine("Kontener zawiera inne towary, niepoprawna temperatura!");
            }
        }
        else
        {
            if (temperatura < temperaturaLadunku){ 
                towary.Add(ladunek); 
                base.ZaladowanieKontenera(ladunek, masa);
            }
            else
            {
                Console.WriteLine("Temperatura kontenera jest za wysoka!");
            } 
        }
    }
    
}