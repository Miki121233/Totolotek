using Newtonsoft.Json;
using System;
using System.IO;

namespace Totolotek
{
    public class ZarzadzanieGra
    {
        public static bool wczytano = false;
        public static double startowePieniadze = 100;
        public static int nrGracza = 0; //gracz 1 zaczyna
        public int liczbaGraczy = Program.liczbaGraczy;
        public static bool koniecGry = false;
        public static int[] wylosowaneLiczby = new int[6];
        public static int numerDnia = 0;
        public static Gracz[] graczWczytany;




        public static void start(int liczbaGraczy)
        {
            Gracz[] gracz =  new Gracz[liczbaGraczy];

            for (int j = 0; j < liczbaGraczy; j++)
            {
                if (wczytano == true)
                {
                    gracz[j] = graczWczytany[j];
                }
                if (wczytano == false)
                {
                    gracz[j] = new Gracz(startowePieniadze); 
                }
            }
            

            while (koniecGry == false)
            {
            ponownyWybor:
                if (nrGracza + 1 != liczbaGraczy)
                {
                    Console.WriteLine("Dzień "+(numerDnia+1)+"\nTura gracza " + (nrGracza + 1) + "\nStan konta: " + gracz[nrGracza].pieniadze + " zł\n1. Kup kupon(- 10 zł / sztuka)\n" +
                      "2. Wyświetl swoje kupony\n3. Koniec tury\n4. Zapis gry\n5. Wróć do menu\n");
                }
                else 
                {
                    Console.WriteLine("Dzień " + (numerDnia + 1) + "\nTura gracza " + (nrGracza + 1) + "\nStan konta: " + gracz[nrGracza].pieniadze + " zł\n1. Kup kupon(- 10 zł / sztuka)\n" +
                      "2. Wyświetl swoje kupony\n3. Kumulacja\n4. Zapis gry\n5. Wróć do menu\n");
                }
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
                            Console.Clear();
                            nrGracza++;
                            if (nrGracza > liczbaGraczy - 1) //po turach wszystkich graczy 
                            { 
                                wyniki(liczbaGraczy, gracz);
                                for (int j = 0; j < liczbaGraczy; j++)
                                {
                                    if(gracz[j].pieniadze<=0)
                                        Console.WriteLine("Gracz "+(j+1)+" przegrywa!");
                                }
                                for(int i = 0;i<liczbaGraczy;i++)
                                {
                                    gracz[i].usunKupony();
                                }
                                numerDnia++;

                                nrGracza = 0; 
                            }
                            
                        }
                        break;
                    case 4:
                        {
                            Zapis.zapisGry(gracz);
                           
                            goto ponownyWybor;
                        }
                        break;
                    case 5:
                        {
                            return;
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
            switch (iloscWylosowanychLiczb)
            {
                case 1:
                    { gracz.pieniadze = gracz.pieniadze + 10; }
                    break;
                case 2:
                    { gracz.pieniadze = gracz.pieniadze + 100; }
                    break;
                case 3:
                    { gracz.pieniadze = gracz.pieniadze + 1000; }
                    break;
                case 4:
                    { gracz.pieniadze = gracz.pieniadze + 10000; }
                    break;
                case 5:
                    { gracz.pieniadze = gracz.pieniadze + 100000; }
                    break;
                case 6:
                    {  gracz.pieniadze = gracz.pieniadze + 2000000; }
                    break;
                default:
                    break;
            }
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
