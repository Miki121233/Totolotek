using System;
using System.Collections.Generic;
using System.Text;

namespace Totolotek
{
    public class Gracz
    {
        Kupon[] kupon = new Kupon[10];
        public double pieniadze;
        //public string nazwa;
        //Kupon kupon;

        public Gracz()
        {
            //this.nazwa = nazwa;
            pieniadze = 100;
        }
        public void zakupKuponow(int ileKuponow)
        {
            for(int i=0;i<ileKuponow;i++)
            {
                Console.WriteLine("Wybór liczb na kuponie (0-100)");
                for (int j = 0; j < 6; j++)
                {
                    Console.WriteLine("Wybierz "+(j + 1) + " liczbę na kuponie: ");
                bladKonwersji:
                    if (int.TryParse(Console.ReadLine(), out kupon[i].liczby[j]) == false)
                    {
                        goto bladKonwersji;
                    }
                }
            }
            
        }
        public void wyswietl(int i)
        {
            Console.WriteLine("Gracz: "+ (i + 1) + ", stan konta: "+pieniadze+" zł\n");
        }

        /* public double Pieniadze
        {
            get { return pieniadze; }
            set { pieniadze = value; }
        }*/
    }
}
