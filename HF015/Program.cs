using System;

namespace HF015;

class Program
{
    static void Main(string[] args)
    {
        int dominokSzama = int.Parse(Console.ReadLine());
        int[] darab = new int[7];
        int[] csoport = { 0, 1, 2, 3, 4, 5, 6 };
        int szam = 0;

        for (int i = 0; i < dominokSzama; i++)
        {
            string[] reszek = Console.ReadLine().Split('|');
            int a = int.Parse(reszek[0]);
            int b = int.Parse(reszek[1]);

            darab[a]++;
            darab[b]++;

            int regiCsoport = csoport[b];
            int ujCsoport = csoport[a];
            for (int k = 0; k < 7; k++)
            {
                if (csoport[k] == regiCsoport)
                {
                    csoport[k] = ujCsoport;
                }
            }

            szam = a;
        }

        int paratlanokSzama = 0;
        bool osszefuggo = true;

        for (int k = 0; k < 7; k++)
        {
            if (darab[k] % 2 == 1)
            {
                paratlanokSzama++;
            }
            if (darab[k] > 0 && csoport[k] != csoport[szam])
            {
                osszefuggo = false;
            }
        }

        bool lehetseges = osszefuggo && (paratlanokSzama == 0 || paratlanokSzama == 2);
        Console.WriteLine(lehetseges ? "Y" : "N");

        Console.ReadLine();
    }
}
