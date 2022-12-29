using System;
using System.IO;


namespace Totolotek
{
    public class Menu
    {
        public Zapis zapis;
        public static int liczbaGraczy;

        public Menu()
        {
        
        }

        public static void wyswietl()
        {
        menu:
            Console.WriteLine("Witaj w grze totolotek!\nWybierz opcję z MENU:\n");
            Console.WriteLine("1. Graj\n2. Wczytaj grę\n3. Ilość pieniędzy na początku gry");

            switch ((char)Console.Read())
            {
                case '1':
                    {
                        Console.Clear();
                        Console.WriteLine("Wybierz liczbę graczy:\n");

                    bladKonwersji:
                        if (int.TryParse(Console.ReadLine(), out liczbaGraczy) == false)
                        {
                            goto bladKonwersji;
                        }
                        ZarzadzanieGra.start(liczbaGraczy);
                        Console.Clear();
                        goto menu;
                    }
                    break;

                case '2':
                    {
                        Console.Clear();
                        Zapis.wczytanieGry();
                        ZarzadzanieGra.start(liczbaGraczy);
                        Console.Clear();
                        goto menu;
                    }
                    break;
                case '3':
                    {
                        Console.WriteLine("Wprowadź nowy stan konta (domyślnie 100): ");
                    bladKonwersji:
                        if (double.TryParse(Console.ReadLine(), out ZarzadzanieGra.startowePieniadze) == false)
                        {
                            goto bladKonwersji;
                        }
                        goto menu;
                    }
                    break;
                default:
                    break;
            }
        }
        
    }
}
