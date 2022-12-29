using System;
using System.IO;

namespace Totolotek
{
    public class Zapis
    {
        public int liczbaGraczy;
        public int nrGracza;
        public int liczbaDni;
        public Zapis(int liczbaGraczy, int nrGracza, int liczbaDni)
        {
            this.liczbaGraczy = liczbaGraczy;
            this.nrGracza = nrGracza;
            this.liczbaDni = liczbaDni;
        }

        public static void zapisGry(Gracz[] gracz)
        {
            var jsonsettings = new Newtonsoft.Json.JsonSerializerSettings();
            jsonsettings.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.All;
            Zapis zapis = new Zapis(Program.liczbaGraczy, ZarzadzanieGra.nrGracza, ZarzadzanieGra.numerDnia);
            var serializedGracz = Newtonsoft.Json.JsonConvert.SerializeObject(gracz, Newtonsoft.Json.Formatting.Indented, jsonsettings);
            var serializedZapis = Newtonsoft.Json.JsonConvert.SerializeObject(zapis, Newtonsoft.Json.Formatting.Indented, jsonsettings);

            string path1 = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filepath1 = Path.Combine(path1, "saveFileTotolotek_Gracze.txt");
            using (StreamWriter sw = new StreamWriter(filepath1))
            {
                sw.Write(serializedGracz);
            }
            //drugi plik
            string path2 = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filepath2 = Path.Combine(path2, "saveFileTotolotek_Dane.txt");
            using (StreamWriter sw = new StreamWriter(filepath2))
            {
                sw.Write(serializedZapis);
            }
        }

        public static void wczytanieGry()
        {
            var jsonsettings = new Newtonsoft.Json.JsonSerializerSettings();
            jsonsettings.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.All;

            string content1 = null;
            string content2 = null;

            string path1 = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filepath1 = Path.Combine(path1, "saveFileTotolotek_Gracze.txt");
            using (StreamReader sr = new StreamReader(filepath1))
            {
                content1 = sr.ReadToEnd();
            }

            string path2 = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filepath2 = Path.Combine(path2, "saveFileTotolotek_Dane.txt");
            using (StreamReader sr = new StreamReader(filepath2))
            {
                content2 = sr.ReadToEnd();
            }
            ZarzadzanieGra.graczWczytany = Newtonsoft.Json.JsonConvert.DeserializeObject<Gracz[]>(content1, jsonsettings);
            Zapis zapis = Newtonsoft.Json.JsonConvert.DeserializeObject<Zapis>(content2, jsonsettings);
            Program.liczbaGraczy = zapis.liczbaGraczy;
            ZarzadzanieGra.nrGracza = zapis.nrGracza;
            ZarzadzanieGra.numerDnia = zapis.liczbaDni;
            ZarzadzanieGra.wczytano = true;
        }

    }
}
