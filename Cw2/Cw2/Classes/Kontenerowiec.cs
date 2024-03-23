namespace Cw2.Classes;

public class Kontenerowiec
{
    private List<Kontener> kontenery;
    private double predkosc;
    private int maxKontenerow;
    private double maksymalnaWaga;
    private double obecnaWaga;
    
    public Kontenerowiec(double predkosc, int maxKontenerow, double maksymalnaWaga)
    {
        this.kontenery = new List<Kontener>();
        this.predkosc = predkosc;
        this.maxKontenerow = maxKontenerow;
        this.maksymalnaWaga = maksymalnaWaga;
        this.obecnaWaga = 0;
    }

    public void ZaladujKontener(Kontener kontener)
    {
        if (kontenery.Count < maxKontenerow)
        {
            if (maksymalnaWaga >= kontener.wagaWlasna + kontener.masaLadunku)
            {
                kontenery.Add(kontener);
                obecnaWaga += kontener.wagaWlasna + kontener.masaLadunku;
                Console.WriteLine("Zaladowano kontener na statek - " + kontener.numerSeryjny);
            }
            else
            {
                Console.WriteLine("Przekroczono wage maksymalna na kontenerowcu!");
            }
        }
        else
        {
            Console.WriteLine("Przekroczono liczbe kontenrow!");
        }
        
    }

    public void ZaladujKontener(List<Kontener> noweKontenery)
    {
        foreach(Kontener k in noweKontenery)
        {
            ZaladujKontener(k);
        }
        
    }

    public void UsunKontener(Kontener kontener)
    {
        if (kontenery.Remove(kontener))
        {
            Console.WriteLine("Usunieto kontener");
        }
        else
        {
            Console.WriteLine("Blad. Nie znaleziono kontenera o podanym numerze seryjnym!");
        }
            
    }

    public override string ToString()
    {
        string strKontener = "Kontenerowiec: \npredkosc: "+predkosc +
                             "wezlow, maksymalna waga: "+maksymalnaWaga+
                             "kg, maksymalna ilosc konterow: "+maxKontenerow+
                             "\nkontenery: \n";
        foreach (Kontener kontener in kontenery)
        {
            strKontener += kontener.ToString() +"\n";
        }

        return strKontener;
    }
}