using System;

namespace Totolotek
{
    public class ZarzadzanieGra
    {
        public static bool koniecGry = false;
        public static int[] wylosowaneLiczby = new int[6];

        public static void start(int liczbaGraczy)
        {
            Gracz[] gracz = new Gracz[liczbaGraczy];
            for(int j=0;j<liczbaGraczy;j++)
            {
                gracz[j] = new Gracz();
            }
            int nrGracza = 0; //gracz 1
            while (koniecGry == false)
            {
            ponownyWybor:
                Console.WriteLine("Tura gracza " + (nrGracza + 1) + "\nStan konta: " + gracz[nrGracza].pieniadze + " zł\n1. Kup kupon(- 10 zł / sztuka)\n" +
                    "2. Wyświetl swoje kupony\n3. Koniec tury\n");
            bladKonwersji:
                if (int.TryParse(Console.ReadLine(), out int wybor) == false)
                {
                    goto bladKonwersji;
                }
                switch (wybor)
                {
                    case 1:
                        {
                            gracz[nrGracza].zakupKuponu();
                            Console.Clear();
                            goto ponownyWybor;
                            //gracz[i].pieniadze = gracz[i].pieniadze-10;
                        }
                        break;
                    case 2:
                        {
                            gracz[nrGracza].wyswietlKupony();
                            goto ponownyWybor;
                        }
                        break;
                    case 3:
                        {
                            nrGracza++;
                            if (nrGracza > liczbaGraczy - 1) //po turach wszystkich graczy 
                            { 
                                wyniki(liczbaGraczy, gracz);
                                nrGracza = 0; 
                            }
                            
                        }
                        break;
                    default:
                        {
                            Console.Clear();
                            goto ponownyWybor;
                        }
                }

            }
            
        }

        static void wyniki(int liczbaGraczy, Gracz[] gracz)
        {
            losowanie();
            Console.WriteLine("Wyniki:\nWylosowane liczby: " + wylosowaneLiczby[0] + ", " + wylosowaneLiczby[1] + ", " + wylosowaneLiczby[2] + ", " +
                    wylosowaneLiczby[3] + ", " + wylosowaneLiczby[4] + ", " + wylosowaneLiczby[5]);

            int iloscWylosowanychLiczb = 0;
            for (int i = 0; i < liczbaGraczy; i++)
            {
                Console.WriteLine("Gracz nr. "+(i+1));
                gracz[i].wyswietlKupony();
                Console.WriteLine();
                for (int j = 0; j < gracz[i].liczbaKuponow; j++)
                {
                    for (int k = 0; k < 6; k++)
                    {
                        if (gracz[i].kupon[j].liczby[k] == wylosowaneLiczby[k])
                        { iloscWylosowanychLiczb++; }
                        przyznanieNagrody(iloscWylosowanychLiczb, gracz[i]);
                        iloscWylosowanychLiczb = 0;
                    }
                }
            }
        }

        static void przyznanieNagrody(int iloscWylosowanychLiczb, Gracz gracz)
        {
            
        }

        static void losowanie()
        { // 0-50, 15-60, 30-70, 45-80, 60-90, 75-100
            int start = 0; //0-60
            int stop = 50; //0-100
            Random rand = new Random();
            for (int j = 0; j < 6; j++)
            {
                wylosowaneLiczby[j] = rand.Next(start, stop);
                start = start + 15;
                stop = stop + 10;
            }

        }
        
    }

}
