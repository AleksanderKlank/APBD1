﻿// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

int a = 5;

for (int i = 0; i < a; i++)
{
    Console.WriteLine(i);
}

Console.WriteLine("MOdyfikacja");

static int feadture_average(int[] tab)
{
    int avg = 0;
    for (int i = 0; i < tab.Length; i++)
    {
        avg += tab[i];
    }
    
    return avg/tab.Length;
}

static int feature_max(int[] tab)
{
    int max = tab[0];
    for (int i = 0; i < tab.Length; i++)
    {
        if (tab[i] > max)
            max = tab[i];
    }

    return max;
}