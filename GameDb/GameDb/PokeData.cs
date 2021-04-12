using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GameDb
{
    class PokeData
    {
        public Dictionary<string, PokeType> typeDict { get; set; }
        public Dictionary<string, Color> colorDict { get; set; }
        public List<string> typeList { get; set; }


        public PokeData()
        {
            typeDict = new Dictionary<string, PokeType>
            {
                { "Normal", new Normal() },
                { "Fire", new Fire() },
                { "Water", new Water() },
                { "Electric", new Electric() },
                { "Grass", new Grass() },
                { "Ice", new Ice() },
                { "Fighting", new Fighting() },
                { "Poison", new Poison() },
                { "Ground", new Ground() },
                { "Flying", new Flying() },
                { "Psychic", new Psychic() },
                { "Bug", new Bug() },
                { "Rock", new Rock() },
                { "Ghost", new Ghost() },
                { "Dragon", new Dragon() },
                { "Dark", new Dark() },
                { "Steel", new Steel() },
                { "Fairy", new Fairy() },
            };

            colorDict = new Dictionary<string, Color>
            {
                { "Normal", Color.FromHex("AAAA99") },
                { "Fire", Color.FromHex("FF4422") },
                { "Water", Color.FromHex("3399FF") },
                { "Electric", Color.FromHex("FFCC33") },
                { "Grass", Color.FromHex("77CC55") },
                { "Ice", Color.FromHex("66CCFF") },
                { "Fighting", Color.FromHex("BB5544") },
                { "Poison", Color.FromHex("AA5599") },
                { "Ground", Color.FromHex("DDBB55") },
                { "Flying", Color.FromHex("8899FF") },
                { "Psychic", Color.FromHex("FF5599") },
                { "Bug", Color.FromHex("AABB22") },
                { "Rock", Color.FromHex("BBAA66") },
                { "Ghost", Color.FromHex("6666BB") },
                { "Dragon", Color.FromHex("7766EE") },
                { "Dark", Color.FromHex("775544") },
                { "Steel", Color.FromHex("AAAABB") },
                { "Fairy", Color.FromHex("EE99EE") },
            };

            typeList = new List<string>
            {
                { "Normal" },
                { "Fire" },
                { "Water" },
                { "Electric" },
                { "Grass" },
                { "Ice" },
                { "Fighting" },
                { "Poison" },
                { "Ground" },
                { "Flying" },
                { "Psychic" },
                { "Bug" },
                { "Rock" },
                { "Ghost" },
                { "Dragon" },
                { "Dark" },
                { "Steel" },
                { "Fairy" },
            };
        }
    }
}
