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

    public Kontener(double masaLadunku, double wysokosc, double wagaWlasna, double glebokosc, double maksymalnaLadownosc)
    {
        this.masaLadunku = masaLadunku;
        this.wysokosc = wysokosc;
        this.wagaWlasna = wagaWlasna;
        this.glebokosc = glebokosc;
        this.maksymalnaLadownosc = maksymalnaLadownosc;
    }

    public abstract void OproznienieLadunku();
    public abstract void ZaladowanieKontenera(string ladunek, double masa);


}