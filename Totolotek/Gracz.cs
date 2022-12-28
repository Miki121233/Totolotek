using System;
using System.Collections.Generic;
using System.Text;

namespace Totolotek
{
    public class Gracz
    {
        public int liczbaKuponow = 0;
        public Kupon[] kupon = new Kupon[10];
        public double pieniadze;
        //public string nazwa;
        //Kupon kupon;

        public Gracz()
        {
            //this.nazwa = nazwa;
            pieniadze = 100;
        }
        public void zakupKuponu()
        {
            
            kupon[liczbaKuponow] = new Kupon();
            Console.WriteLine("Wybór liczb na kuponie (0-100)");
            for (int j = 0; j < 6; j++)
            {
            bladKonwersji:
                Console.WriteLine("Wybierz " + (j + 1) + " liczbę na kuponie: ");
                if (int.TryParse(Console.ReadLine(), out kupon[liczbaKuponow].liczby[j]) == false)
                {
                    Console.WriteLine(kupon[liczbaKuponow].liczby[j]);
                    goto bladKonwersji;
                }
            }
            liczbaKuponow++;
            pieniadze = pieniadze - 10;
        }
        public void wyswietl(int i)
        {
            Console.WriteLine("Gracz: "+ (i + 1) + ", stan konta: "+pieniadze+" zł\n");
        }

        public void wyswietlKupony()
        {
            if(liczbaKuponow==0)
            {
                Console.WriteLine("Nie masz aktualnie żadnych kuponów!\n");
            }
            else
            for (int i = 0; i < liczbaKuponow; i++)
            {
                Console.WriteLine("Kupon nr."+(i+1)+": "+kupon[i].liczby[0] + ", " + kupon[i].liczby[1] + ", " + kupon[i].liczby[2] + ", " +
                    kupon[i].liczby[3] + ", " + kupon[i].liczby[4] + ", " + kupon[i].liczby[5]);
            }
        }

        /* public double Pieniadze
        {
            get { return pieniadze; }
            set { pieniadze = value; }
        }*/
    }
}
