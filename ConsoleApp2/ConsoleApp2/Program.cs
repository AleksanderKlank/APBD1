// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

int a = 5;

for (int i = 0; i < a; i++)
{
    Console.WriteLine(i);
}

Console.WriteLine("MOdyfikacja");

static int feadture_average(int[] tab)
{
    int average = 0;
    for (int i = 0; i < tab.Length; i++)
    {
        average += tab[i];
    }
    
    return average/tab.Length;
}