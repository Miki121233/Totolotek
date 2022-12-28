using System;

namespace Totolotek
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Console.WriteLine("Witaj w grze totolotek!\nWybierz opcję z MENU:\n");
            Console.WriteLine("1. Graj");

            switch ((char)Console.Read())
            {
                case  '1':
                    {
                        Console.Clear();
                        Console.WriteLine("Wybierz liczbę graczy (0-2):\n");
               
                    bladKonwersji:
                        if (int.TryParse(Console.ReadLine(), out int liczbaGraczy) == false)
                        {
                            goto bladKonwersji;
                        }
                        ZarzadzanieGra.start(liczbaGraczy);
                        
                    }
                    break;

                default:
                    break;
            }
        }
    }
}
