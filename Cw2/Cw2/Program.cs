using Cw2;
using Cw2.Classes;
using Cw2.Exceptions;

class Program
{
    static public void Main(String[] args)
    {
        KontenerChlodniczy k1 = new KontenerChlodniczy( 4, 1, 5, 100);
        k1.ZaladowanieKontenera("banany", 90);
        Console.WriteLine(k1.ToString());
        k1.OproznienieLadunku();
        Console.WriteLine(k1.ToString());
        
        
        KontenerGaz k2 = new KontenerGaz( 4, 1, 5, 100);
        k2.ZaladowanieKontenera("hel", 98);
        Console.WriteLine(k2.ToString());
        k2.OproznienieLadunku();
        Console.WriteLine(k2.ToString());
        
    }
}