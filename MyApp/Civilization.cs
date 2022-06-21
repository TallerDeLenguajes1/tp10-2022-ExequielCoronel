using System.Text.Json.Serialization;
using System.Text.Json;
using System.Collections.Generic;
namespace Tpn10
{
    public class Civilization
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("expansion")]
        public string Expansion { get; set; }

        [JsonPropertyName("army_type")]
        public string ArmyType { get; set; }

        [JsonPropertyName("unique_unit")]
        public List<string> UniqueUnit { get; set; }

        [JsonPropertyName("unique_tech")]
        public List<string> UniqueTech { get; set; }

        [JsonPropertyName("team_bonus")]
        public string TeamBonus { get; set; }

        [JsonPropertyName("civilization_bonus")]
        public List<string> CivilizationBonus { get; set; }
    }

    public class ListaDeCivilizaciones
    {
        [JsonPropertyName("civilizations")]
        public List<Civilization> Civilizations { get; set; }
    }
}