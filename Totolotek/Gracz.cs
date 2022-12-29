using System;
using System.Collections.Generic;
using System.Text;

namespace Totolotek
{
    public class Gracz
    {
        public int id;
        public int liczbaKuponow = 0;
        public Kupon[] kupon = new Kupon[10];
        public double pieniadze;
        public Gracz() {}
        public Gracz(double startowePieniadze, int id)
        {
            //this.nazwa = nazwa;
            this.id = id;
            this.pieniadze = startowePieniadze;
        }
        public void zakupKuponu()
        {
            if(pieniadze > 10){
                kupon[liczbaKuponow] = new Kupon();
                Console.WriteLine("Wybór liczb na kuponie (1-100)");
                for (int j = 0; j < 6; j++)
                {
                bladKonwersji:
                    Console.WriteLine("Wybierz " + (j + 1) + " liczbę na kuponie: ");
                    if (int.TryParse(Console.ReadLine(), out kupon[liczbaKuponow].liczby[j]) == false || kupon[liczbaKuponow].liczby[j] > 100
                        || kupon[liczbaKuponow].liczby[j] <= 0) 
                    {
                        goto bladKonwersji;
                    }
                }
                liczbaKuponow++;
                pieniadze = pieniadze - 10;
            }
            else Console.WriteLine("Nie stać cię na kolejny kupon!\n");
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

        public void usunKupony()
        {
            liczbaKuponow = 0;
        }

        /* public double Pieniadze
        {
            get { return pieniadze; }
            set { pieniadze = value; }
        }*/
    }
}
