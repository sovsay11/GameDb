﻿using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Text;

namespace GameDb
{
    abstract class PokeType
    {
        //Dictionary<string, Color> colorDictionary = new Dictionary<string, Color>
        //    {
        //        { "Normal", Color.FromHex("AAAA99") },
        //        { "Fire", Color.FromHex("FF4422") },
        //        { "Water", Color.FromHex("3399FF") },
        //        { "Electric", Color.FromHex("FFCC33") },
        //        { "Grass", Color.FromHex("77CC55") },
        //        { "Ice", Color.FromHex("66CCFF") },
        //        { "Fighting", Color.FromHex("BB5544") },
        //        { "Poison", Color.FromHex("AA5599") },
        //        { "Ground", Color.FromHex("DDBB55") },
        //        { "Flying", Color.FromHex("8899FF") },
        //        { "Psychic", Color.FromHex("FF5599") },
        //        { "Bug", Color.FromHex("AABB22") },
        //        { "Rock", Color.FromHex("BBAA66") },
        //        { "Ghost", Color.FromHex("6666BB") },
        //        { "Dragon", Color.FromHex("7766EE") },
        //        { "Dark", Color.FromHex("775544") },
        //        { "Steel", Color.FromHex("AAAABB") },
        //        { "Fairy", Color.FromHex("EE99EE") },
        //    };

        public string name { get; set; }
        public Color color { get; set; }

        public Dictionary<string, double> vulnerabilities { get; set; }
        public Dictionary<string, double> strengths { get; set; }
        public Dictionary<string, double> resistances { get; set; }
        public Dictionary<string, double> weaknesses { get; set; }

        // might not need these methods
        public void GetWeaknesses()
        {

        }

        public void GetStrengths()
        {

        }

        public void GetResistances()
        {

        }
    }

    class Water : PokeType
    {
        public Water()
        {
            name = "Water";
            color = Color.FromHex("3399FF");

            vulnerabilities = new Dictionary<string, double>
            {
                { "Electric", 2}
            };
            strengths = new Dictionary<string, double>
            {
                { "Electric", 2}
            };
            weaknesses = new Dictionary<string, double>
            {
                { "Electric", 2}
            };
            resistances = new Dictionary<string, double>
            {
                { "Electric", 2}
            };
        }
    }
}
