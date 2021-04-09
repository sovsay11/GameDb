using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Text;

namespace GameDb
{
    public abstract class PokeType
    {
        Dictionary<string, Color> colorDictionary = new Dictionary<string, Color>
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
                { "None", Color.DimGray },
            };

        public string name { get; set; }
        public Color color { get; set; }
        public Dictionary<string, double> vulnerabilities { get; set; }
        public Dictionary<string, double> strengths { get; set; }
        public Dictionary<string, double> resistances { get; set; }
        public Dictionary<string, double> weaknesses { get; set; }

        public Color GetColor(string text)
        {
            colorDictionary.TryGetValue(text, out Color color);
            return color;
        }

        public Dictionary<string, double> GetAttribute(string text)
        {
            if (text == "v")
            {
                return vulnerabilities;
            }
            else if (text == "s")
            {
                return strengths;
            }
            else if (text == "r")
            {
                return resistances;
            }
            else
            {
                return weaknesses;
            }
        }
    }

    class Normal : PokeType
    {
        public Normal()
        {
            name = nameof(Normal);
            color = Color.FromHex("AAAA99");

            vulnerabilities = new Dictionary<string, double>
            {
                { "Fighting", 2 }
            };
            strengths = new Dictionary<string, double>
            {
                { "None", 0 }
            };
            weaknesses = new Dictionary<string, double>
            {
                { "Ghost", 0 },
                { "Rock", 0.5 },
                { "Steel", 0.5 },
            };
            resistances = new Dictionary<string, double>
            {
                { "Ghost", 0 }
            };
        }
    }

    class Fire : PokeType
    {
        public Fire()
        {
            name = nameof(Fire);
            color = Color.FromHex("FF4422");

            vulnerabilities = new Dictionary<string, double>
            {
                { "Ground", 2 },
                { "Rock", 2 },
                { "Water", 2 },
            };
            strengths = new Dictionary<string, double>
            {
                { "Grass", 2 },
                { "Ice", 2 },
                { "Bug", 2 },
                { "Steel", 2 },
            };
            weaknesses = new Dictionary<string, double>
            {
                { "Fire", 0.5 },
                { "Water", 0.5 },
                { "Rock", 0.5 },
                { "Dragon", 0.5 },
            };
            resistances = new Dictionary<string, double>
            {
                { "Fire", 0.5 },
                { "Grass", 0.5 },
                { "Ice", 0.5 },
                { "Bug", 0.5 },
                { "Steel", 0.5 },
                { "Fairy", 0.5 },
            };
        }
    }

    class Water : PokeType
    {
        public Water()
        {
            name = nameof(Water);
            color = Color.FromHex("3399FF");

            vulnerabilities = new Dictionary<string, double>
            {
                { "Electric", 2 },
                { "Grass", 2 },
            };
            strengths = new Dictionary<string, double>
            {
                { "Fire", 2 },
                { "Ground", 2 },
                { "Rock", 2 },
            };
            weaknesses = new Dictionary<string, double>
            {
                { "Water", 0.5 },
                { "Grass", 0.5 },
                { "Dragon", 0.5 },
            };
            resistances = new Dictionary<string, double>
            {
                { "Fire", 0.5 },
                { "Water", 0.5 },
                { "Ice", 0.5 },
                { "Steel", 0.5 },
            };
        }
    }

    class Electric : PokeType
    {
        public Electric()
        {
            name = nameof(Electric);
            color = Color.FromHex("FFCC33");

            vulnerabilities = new Dictionary<string, double>
            {
                { "Ground", 2 },
            };
            strengths = new Dictionary<string, double>
            {
                { "Water", 2 },
                { "Flying", 2 },
            };
            weaknesses = new Dictionary<string, double>
            {
                { "Electric", 0.5 },
                { "Grass", 0.5 },
                { "Ground", 0 },
                { "Dragon", 0 },
            };
            resistances = new Dictionary<string, double>
            {
                { "Electric", 0.5 },
                { "Flying", 0.5 },
                { "Steel", 0.5 },
            };
        }
    }

    class Grass : PokeType
    {
        public Grass()
        {
            name = nameof(Grass);
            color = Color.FromHex("77CC55");

            vulnerabilities = new Dictionary<string, double>
            {
                { "Fire", 2 },
                { "Ice", 2 },
                { "Poison", 2 },
                { "Flying", 2 },
                { "Bug", 2 },
            };
            strengths = new Dictionary<string, double>
            {
                { "Water", 2 },
                { "Ground", 2 },
                { "Rock", 2 },
            };
            weaknesses = new Dictionary<string, double>
            {
                { "Fire", 0.5 },
                { "Grass", 0.5 },
                { "Poison", 0.5 },
                { "Flying", 0.5 },
                { "Bug", 0.5 },
                { "Dragon", 0.5 },
                { "Steel", 0.5 },
            };
            resistances = new Dictionary<string, double>
            {
                { "Water", 0.5 },
                { "Electric", 0.5 },
                { "Grass", 0.5 },
                { "Ground", 0.5 },
            };
        }
    }

    class Ice : PokeType
    {
        public Ice()
        {
            name = nameof(Ice);
            color = Color.FromHex("66CCFF");

            vulnerabilities = new Dictionary<string, double>
            {
                { "Fire", 2 },
                { "Fighting", 2 },
                { "Rock", 2 },
                { "Steel", 2 },
            };
            strengths = new Dictionary<string, double>
            {
                { "Grass", 2 },
                { "Ground", 2 },
                { "Flying", 2 },
                { "Dragon", 2 },
            };
            weaknesses = new Dictionary<string, double>
            {
                { "Fire", 0.5 },
                { "Water", 0.5 },
                { "Ice", 0.5 },
                { "Steel", 0.5 },
            };
            resistances = new Dictionary<string, double>
            {
                { "Ice", 0.5 },
            };
        }
    }

    class Fighting : PokeType
    {
        public Fighting()
        {
            name = nameof(Fighting);
            color = Color.FromHex("BB5544");

            vulnerabilities = new Dictionary<string, double>
            {
                { "Flying", 2 },
                { "Psychic", 2 },
                { "Fairy", 2 },
            };
            strengths = new Dictionary<string, double>
            {
                { "Normal", 2 },
                { "Ice", 2 },
                { "Rock", 2 },
                { "Dark", 2 },
                { "Steel", 2 },
            };
            weaknesses = new Dictionary<string, double>
            {
                { "Poison", 0.5 },
                { "Flying", 0.5 },
                { "Psychic", 0.5 },
                { "Bug", 0.5 },
                { "Ghost", 0 },
                { "Fairy", 0.5 },
            };
            resistances = new Dictionary<string, double>
            {
                { "Bug", 0.5 },
                { "Rock", 0.5 },
                { "Dark", 0.5 },
            };
        }
    }
    class Poison : PokeType
    {
        public Poison()
        {
            name = nameof(Poison);
            color = Color.FromHex("AA5599");

            vulnerabilities = new Dictionary<string, double>
            {
                { "Ground", 2 },
                { "Psychic", 2 },
            };
            strengths = new Dictionary<string, double>
            {
                { "Grass", 2 },
                { "Fairy", 2 },
            };
            weaknesses = new Dictionary<string, double>
            {
                { "Poison", 0.5 },
                { "Ground", 0.5 },
                { "Rock", 0.5 },
                { "Ghost", 0.5 },
                { "Steel", 0 },
            };
            resistances = new Dictionary<string, double>
            {
                { "Grass", 0.5 },
                { "Fighting", 0.5 },
                { "Poison", 0.5 },
                { "Bug", 0.5 },
                { "Fairy", 0.5 },
            };
        }
    }
    class Ground : PokeType
    {
        public Ground()
        {
            name = nameof(Ground);
            color = Color.FromHex("DDBB55");

            vulnerabilities = new Dictionary<string, double>
            {
                { "Water", 2 },
                { "Grass", 2 },
                { "Ice", 2 },
            };
            strengths = new Dictionary<string, double>
            {
                { "Fire", 2 },
                { "Electric", 2 },
                { "Poison", 2 },
                { "Rock", 2 },
                { "Steel", 2 },
            };
            weaknesses = new Dictionary<string, double>
            {
                { "Grass", 0.5 },
                { "Flying", 0 },
                { "Bug", 0.5 },
            };
            resistances = new Dictionary<string, double>
            {
                { "Electric", 0 },
                { "Poison", 0.5 },
                { "Rock", 0.5 },
            };
        }
    }
    class Flying : PokeType
    {
        public Flying()
        {
            name = nameof(Flying);
            color = Color.FromHex("8899FF");

            vulnerabilities = new Dictionary<string, double>
            {
                { "Electric", 2 },
                { "Ice", 2 },
                { "Rock", 2 },
            };
            strengths = new Dictionary<string, double>
            {
                { "Grass", 2 },
                { "Fighting", 2 },
                { "Bug", 2 },
            };
            weaknesses = new Dictionary<string, double>
            {
                { "Electric", 0.5 },
                { "Rock", 0.5 },
                { "Steel", 0.5 },
            };
            resistances = new Dictionary<string, double>
            {
                { "Grass", 0.5 },
                { "Fighting", 0.5 },
                { "Ground", 0 },
                { "Bug", 0.5 },
            };
        }
    }
    class Psychic : PokeType
    {
        public Psychic()
        {
            name = nameof(Psychic);
            color = Color.FromHex("FF5599");

            vulnerabilities = new Dictionary<string, double>
            {
                { "Bug", 2 },
                { "Ghost", 2 },
                { "Dark", 2 },
            };
            strengths = new Dictionary<string, double>
            {
                { "Fighting", 2 },
                { "Poison", 2 },
            };
            weaknesses = new Dictionary<string, double>
            {
                { "Psychic", 0.5 },
                { "Dark", 0 },
                { "Steel", 0.5 },
            };
            resistances = new Dictionary<string, double>
            {
                { "Fighting", 0.5 },
                { "Psychic", 0.5 },
            };
        }
    }
    class Bug : PokeType
    {
        public Bug()
        {
            name = nameof(Bug);
            color = Color.FromHex("AABB22");

            vulnerabilities = new Dictionary<string, double>
            {
                { "Fire", 2 },
                { "Flying", 2 },
                { "Rock", 2 },
            };
            strengths = new Dictionary<string, double>
            {
                { "Grass", 2 },
                { "Psychic", 2 },
                { "Dark", 2 },
            };
            weaknesses = new Dictionary<string, double>
            {
                { "Fire", 0.5 },
                { "Fighting", 0.5 },
                { "Poison", 0.5 },
                { "Flying", 0.5 },
                { "Ghost", 0.5 },
                { "Steel", 0.5 },
                { "Fairy", 0.5 },
            };
            resistances = new Dictionary<string, double>
            {
                { "Grass", 0.5 },
                { "Fighting", 0.5 },
                { "Ground", 0.5 },
            };
        }
    }
    class Rock : PokeType
    {
        public Rock()
        {
            name = nameof(Rock);
            color = Color.FromHex("BBAA66");

            vulnerabilities = new Dictionary<string, double>
            {
                { "Water", 2 },
                { "Grass", 2 },
                { "Fighting", 2 },
                { "Ground", 2 },
                { "Steel", 2 },
            };
            strengths = new Dictionary<string, double>
            {
                { "Fire", 2 },
                { "Ice", 2 },
                { "Flying", 2 },
                { "Bug", 2 },
            };
            weaknesses = new Dictionary<string, double>
            {
                { "Fighting", 0.5 },
                { "Ground", 0.5 },
                { "Steel", 0.5 },
            };
            resistances = new Dictionary<string, double>
            {
                { "Normal", 0.5 },
                { "Fire", 0.5 },
                { "Poison", 0.5 },
                { "Flying", 0.5 },
            };
        }
    }

    class Ghost : PokeType
    {
        public Ghost()
        {
            name = nameof(Ghost);
            color = Color.FromHex("6666BB");

            vulnerabilities = new Dictionary<string, double>
            {
                { "Ghost", 2 },
                { "Dark", 2 },
            };
            strengths = new Dictionary<string, double>
            {
                { "Psychic", 2 },
                { "Ghost", 2 },
            };
            weaknesses = new Dictionary<string, double>
            {
                { "Normal", 0 },
                { "Dark", 0.5 },
            };
            resistances = new Dictionary<string, double>
            {
                { "Normal", 0 },
                { "Fighting", 0 },
                { "Poison", 0.5 },
                { "Bug", 0.5 },
            };
        }
    }
    class Dragon : PokeType
    {
        public Dragon()
        {
            name = nameof(Dragon);
            color = Color.FromHex("7766EE");

            vulnerabilities = new Dictionary<string, double>
            {
                { "Ice", 2 },
                { "Dragon", 2 },
                { "Fairy", 2 },
            };
            strengths = new Dictionary<string, double>
            {
                { "Dragon", 2 },
            };
            weaknesses = new Dictionary<string, double>
            {
                { "Steel", 0.5 },
                { "Fairy", 0.5 },
            };
            resistances = new Dictionary<string, double>
            {
                { "Fire", 0.5 },
                { "Water", 0.5 },
                { "Electric", 0.5 },
                { "Grass", 0.5 },
            };
        }
    }
    class Dark : PokeType
    {
        public Dark()
        {
            name = nameof(Dark);
            color = Color.FromHex("775544");

            vulnerabilities = new Dictionary<string, double>
            {
                { "Fighting", 2 },
                { "Bug", 2 },
                { "Fairy", 2 },
            };
            strengths = new Dictionary<string, double>
            {
                { "Psychic", 2 },
                { "Ghost", 2 },
            };
            weaknesses = new Dictionary<string, double>
            {
                { "Fighting", 0.5 },
                { "Dark", 0.5 },
                { "Fairy", 0.5 },
            };
            resistances = new Dictionary<string, double>
            {
                { "Psychic", 0 },
                { "Ghost", 0.5 },
                { "Dark", 0.5 },
            };
        }
    }
    class Steel : PokeType
    {
        public Steel()
        {
            name = nameof(Steel);
            color = Color.FromHex("AAAABB");

            vulnerabilities = new Dictionary<string, double>
            {
                { "Fire", 2 },
                { "Fighting", 2 },
                { "Ground", 2 },
            };
            strengths = new Dictionary<string, double>
            {
                { "Ice", 2 },
                { "Rock", 2 },
                { "Fairy", 2 },
            };
            weaknesses = new Dictionary<string, double>
            {
                { "Fire", 0.5 },
                { "Water", 0.5 },
                { "Electric", 0.5 },
                { "Steel", 0.5 },
            };
            resistances = new Dictionary<string, double>
            {
                { "Normal", 0.5 },
                { "Grass", 0.5 },
                { "Ice", 0.5 },
                { "Poison", 0 },
                { "Flying", 0.5 },
                { "Psychic", 0.5 },
                { "Bug", 0.5 },
                { "Rock", 0.5 },
                { "Dragon", 0.5 },
                { "Steel", 0.5 },
                { "Fairy", 0.5 },
            };
        }
    }
    class Fairy : PokeType
    {
        public Fairy()
        {
            name = nameof(Fairy);
            color = Color.FromHex("EE99EE");

            vulnerabilities = new Dictionary<string, double>
            {
                { "Poison", 2 },
                { "Steel", 2 },
            };
            strengths = new Dictionary<string, double>
            {
                { "Fighting", 2 },
                { "Dragon", 2 },
                { "Dark", 2 },
            };
            weaknesses = new Dictionary<string, double>
            {
                { "Fire", 0.5 },
                { "Poison", 0.5 },
                { "Steel", 0.5 },
            };
            resistances = new Dictionary<string, double>
            {
                { "Fighting", 0.5 },
                { "Bug", 0.5 },
                { "Dragon", 0 },
                { "Dark", 0.5 },
            };
        }
    }
}
