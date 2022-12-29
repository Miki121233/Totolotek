using System;
using System.IO;


namespace Totolotek
{
    public class Program
    {
        public Zapis zapis;
        public static int liczbaGraczy;
        static void Main(string[] args)
        {
            menu:
            Console.WriteLine("Witaj w grze totolotek!\nWybierz opcję z MENU:\n");
            Console.WriteLine("1. Graj\n2. Wczytaj grę\n3. Ilość pieniędzy na początku gry");

            switch ((char)Console.Read())
            {
                case  '1':
                    {
                        Console.Clear();
                        Console.WriteLine("Wybierz liczbę graczy:\n");
               
                    bladKonwersji:
                        if (int.TryParse(Console.ReadLine(), out liczbaGraczy) == false)
                        {
                            goto bladKonwersji;
                        }
                        ZarzadzanieGra.start(liczbaGraczy);
                        goto menu;
                    }
                    break;
                
                case '2':
                    {
                        ZarzadzanieGra.wczytanieGry();
                        ZarzadzanieGra.start(liczbaGraczy);
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
