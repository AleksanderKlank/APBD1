using Cw2;
using Cw2.Classes;
using Cw2.Exceptions;

class Program
{
    static public void Main(String[] args)
    {
        try
        {
            //Tworzenie przykladowych kontenerow
            KontenerChlodniczy k1 = new KontenerChlodniczy(4, 1, 5, 100, 5);
            k1.ZaladowanieKontenera("banany", 90, 13.3);
            Console.WriteLine(k1);
            k1.OproznienieLadunku();
            Console.WriteLine(k1);


            KontenerGaz k2 = new KontenerGaz(4, 1, 5, 100);
            k2.ZaladowanieKontenera("hel", 98);
            Console.WriteLine(k2);
            k2.OproznienieLadunku();
            Console.WriteLine(k2);

            KontenerPlyny k3 = new KontenerPlyny(4, 1, 5, 100);
            k3.ZaladowanieKontenera("coca cola", 80);
            Console.WriteLine(k3);
            k3.OproznienieLadunku();
            Console.WriteLine(k3);
            
            //Przykladowy kontenerowiec
            Kontenerowiec kontenerowiec = new Kontenerowiec(50,10,50000);
            
            //Zaladowanie kontenera
            kontenerowiec.ZaladujKontener(k1);

            //Zaladowanie listy kontenerow
            List<Kontener> kontenery = new List<Kontener>();
            kontenery.Add(k2);
            kontenery.Add(k3);
            kontenerowiec.ZaladujKontener(kontenery);
            
            //Usuniecie kontenera
            Console.WriteLine(kontenerowiec);
            kontenerowiec.UsunKontener(k1);
            Console.WriteLine(kontenerowiec);
        }
        catch (OverfillException e)
        {
            Console.WriteLine(e);
        }
    }
}