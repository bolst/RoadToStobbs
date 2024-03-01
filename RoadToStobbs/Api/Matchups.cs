using System.Text.Json;
using RoadToStobbs.Data;

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

        public List<Data.Matchups>? GetMatchups(Divisions.DIVISION division = Divisions.DIVISION.NULL)
        {
            string fileContent = File.ReadAllText("Api/matchups.json");
            List<Data.Matchups>? data = JsonSerializer.Deserialize<List<Data.Matchups>>(fileContent);
            data = FilterByDivision(data, division);
            return data;
        }

        public List<Data.Matchups>? FilterByDivision(List<Data.Matchups>? data, Divisions.DIVISION division)
        {
            if (data == null || division == Divisions.DIVISION.NULL) return data;

            List<Data.Matchups> retval = data;
            List<Data.Matchup> filtered_matchups = new List<Data.Matchup>();

            // each round
            for (int i = 0; i < retval.Count(); i++)
            {
                Data.Matchups round = retval[i];
                List<Data.Matchup> matchups = round.matchups;

                // each matchup
                foreach (Data.Matchup matchup in matchups)
                {
                    string strDiv = division.ToString().ToLower();
                    if (matchup.series_name.ToLower().Contains(strDiv))
                    {
                        filtered_matchups.Add(matchup);
                    }
                }

                retval[i].matchups = filtered_matchups;
            }

            return retval;
        }

        public Data.Matchup? GetMatchupBySeriesLetter(string seriesLetter)
        {
            List<Data.Matchups>? matchups = GetMatchups();
            if (matchups == null) return null;

            // Each round
            foreach (Data.Matchups round in matchups)
            {
                // Each matchup
                foreach (Data.Matchup matchup in round.matchups)
                {
                    if (matchup.series_letter == seriesLetter)
                    {
                        return matchup;
                    }
                }

            }

            return null;
        }


    }
}