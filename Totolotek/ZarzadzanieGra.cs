using System;

namespace Totolotek
{
    public class ZarzadzanieGra
    {
        public static bool koniecGry = false;


        public static void start(int liczbaGraczy)
        {
            Gracz[] gracz = new Gracz[liczbaGraczy];
            for(int j=0;j<liczbaGraczy;j++)
            {
                gracz[j] = new Gracz();
            }
            int i = 0; //gracz 1
            Console.WriteLine("");
            while (koniecGry == false)
            {
                Console.WriteLine("Tura gracza " + (i+1) + "\nStan konta: " + gracz[i].pieniadze + " zł\n1. Kup kupony(- 10 zł / sztuka)\n2. Graj dalej\n");
            ponownyWybor:
                switch ((char)Console.Read())
                {
                    case '1':
                        {
                            Console.WriteLine("Ile kuponów chcesz kupić (max 10): ");
                            string val = Console.ReadLine();
                            //int ileKuponow = Convert.ToInt32(val);
                            bladKonwersji:
                            if (int.TryParse(Console.ReadLine(), out int ileKuponow) == false)
                            {
                                goto bladKonwersji;
                            }
                            gracz[i].zakupKuponow(ileKuponow);
                            //gracz[i].pieniadze = gracz[i].pieniadze-10;
                        }
                        break;
                    default:
                        goto ponownyWybor;
                }

            }
            

            i++;
            if (i > liczbaGraczy-1) i = 0;
        } 
        
    }

}
