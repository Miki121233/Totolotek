using System;

namespace Totolotek
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Console.WriteLine("Witaj w grze totolotek!\nWybierz opcję z MENU:\n");
            Console.WriteLine("1. Graj");

            //char wybor = (char)Console.Read();
            switch ((char)Console.Read())
            {
                case  '1':
                    {
                    ponownyWybor:
                        Console.Clear();
                        Console.WriteLine("Wybierz liczbę graczy (0-2):\n");
               
                        int liczbaGraczy;
                        switch ((char)Console.Read())
                        {
                            case '1':
                                {
                                    liczbaGraczy = 1;
                                    ZarzadzanieGra.start(liczbaGraczy);
                                    
                                }
                                break;
                            case '2':
                                {
                                    liczbaGraczy = 2;
                                    ZarzadzanieGra.start(liczbaGraczy);
                                }
                                break;
                            default:
                                {
                                    //Console.WriteLine("Blędny wybór!");
                                    //System.Threading.Thread.Sleep(2000);
                                    goto ponownyWybor; 
                                }
                        }
                    }
                    break;

                default:
                    break;
            }
        }
    }
}
