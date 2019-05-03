using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace AppPrueba
{
    class Program
    {
        static void Main(string[] args)
        {
            //Prueba 2
            var Tracks = LoadJson();
            var timeplayed = Tracks.Sum(s => s.msPlayed);
            var index =  Tracks.Where(w => w.artistName == null).First(); 
            Console.WriteLine(timeplayed/3600000);          

           /* var sr = Tracks.GroupBy(g => g.trackName)
            .Select(s => ( name : s.Key, number:  s.Count()) )
            .OrderBy(p => p.number);

            var sr1 = Tracks.GroupBy(g => g.trackName)
            .Select(s => new { name = s.Key, number = s.Count()} ) 
            .OrderBy(p => p.number);

            var item = new StreamingHistoryItem();
            var tpl = (stritem: item, codigo: "C001");

            foreach(var track in sr)
            {
                Console.WriteLine(track.name + ": "+ track.number);    
            }

            //Console.WriteLine(Tracks.First().endTime);*/
            Console.ReadKey();
        }

        public static List<StreamingHistoryItem> LoadJson()
        {
            using (var r = new StreamReader("StreamingHistory.json"))
            {
                string json = r.ReadToEnd();
                var items = JsonConvert.DeserializeObject<List<StreamingHistoryItem>>(json);
                return items;
            }

        }
        public class StreamingHistoryItem
        {
            public DateTime endTime;
            public string artistName;
            public string trackName;
            public double msPlayed;
        }

    }
}
