using System.Text.Json;
using System.Text.Json.Nodes;
using RoadToStobbs.Data;

namespace RoadToStobbs.Api
{
    public abstract class AbstractPlayer
    {
        public static string GetHeadshotSource(string player_id)
        {
            return $"https://assets.leaguestat.com/pjhlon/240x240/{player_id}.jpg";
        }
    }
}