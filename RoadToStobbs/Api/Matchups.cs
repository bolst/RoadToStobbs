using System.Text.Json;

namespace RoadToStobbs.Api
{
    public class Matchups
    {
        private static Matchups? instance = null;
        private Matchups() { }
        public static Matchups Instance()
        {
            if (instance == null) instance = new Matchups();
            return instance;
        }

        public List<Data.Matchups>? GetMatchups()
        {
            string fileContent = File.ReadAllText("Api/matchups.json");
            List<Data.Matchups>? data = JsonSerializer.Deserialize<List<Data.Matchups>>(fileContent);
            return data;
        }


    }
}