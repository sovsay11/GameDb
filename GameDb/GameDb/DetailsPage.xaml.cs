using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Globalization;

namespace GameDb
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPage : ContentPage
    {
        // local variables for stats
        string pokeName, health, attack, defense, spAtk, spDef, spd;
        Dictionary<string, Color> pokeTypes = new Dictionary<string, Color>();
        Color typeColor;

        // dictionary for colors and type match
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
            };

        public DetailsPage(string name)
        {
            InitializeComponent();

            // connecting to the API
            using (WebClient wc = new WebClient())
            {
                try
                {
                    // offset is starting location
                    // limit is the number of entries
                    string jsonData = wc.DownloadString($@"https://pokeapi.co/api/v2/pokemon/{name.ToLower()}/");

                    // deserialize JSON response to new class instance
                    PokeDetails poke = JsonConvert.DeserializeObject<PokeDetails>(jsonData);

                    // image
                    ImgPokemon.Source = poke.sprites.front_default;

                    // assign to class variables
                    pokeName = ConvertToUpper(poke.name);
                    health = poke.stats[0].base_stat.ToString();
                    attack = poke.stats[1].base_stat.ToString();
                    defense = poke.stats[2].base_stat.ToString();
                    spAtk = poke.stats[3].base_stat.ToString();
                    spDef = poke.stats[4].base_stat.ToString();
                    spd = poke.stats[5].base_stat.ToString();

                    // assign values to labels
                    SetStatValues();

                    // assign initial stat bar values
                    AdjustBars();

                    // margins for bar resizing
                    AdjustMargins();

                    // type check
                    if (poke.types.Count == 2)
                    {
                        LblType1.Text = ConvertToUpper(poke.types[0].type.name.ToString());
                        LblType2.Text = ConvertToUpper(poke.types[1].type.name.ToString());

                        // alter colors of labels
                        ColorLabel(LblType1, LblType1.Text);
                        ColorBars(typeColor);
                        ColorLabel(LblType2, LblType2.Text);

                        pokeTypes.Add(LblType1.Text, GetColorCode(LblType1.Text));
                        pokeTypes.Add(LblType2.Text, GetColorCode(LblType2.Text));
                    }
                    else
                    {
                        LblType2.IsEnabled = false;
                        LblType1.Text = ConvertToUpper(poke.types[0].type.name.ToString());
                        Grid.SetColumnSpan(LblType1, 4);

                        // alter label color
                        ColorLabel(LblType1, LblType1.Text);
                        ColorBars(typeColor);

                        pokeTypes.Add(LblType1.Text, GetColorCode(LblType1.Text));
                    }

                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private void ColorBars(Color typeColor)
        {
            BarHP.Stroke = new SolidColorBrush(typeColor);
            BarAttack.Stroke = new SolidColorBrush(typeColor);
            BarDefense.Stroke = new SolidColorBrush(typeColor);
            BarSpecialAttack.Stroke = new SolidColorBrush(typeColor);
            BarSpecialDefense.Stroke = new SolidColorBrush(typeColor);
            BarSpeed.Stroke = new SolidColorBrush(typeColor);
        }

        // will navigate to the type page
        private void LblType1_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TypesPage(pokeTypes));
        }

        private void LblType2_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TypesPage(pokeTypes));
        }

        private void ColorLabel(Label lblType, string text)
        {
            Color color = GetColorCode(text);
            lblType.BackgroundColor = color;
            typeColor = color;
            lblType.TextColor = Color.White;
        }

        private Color GetColorCode(string text)
        {
            foreach (var colorType in colorDictionary)
            {
                if (colorType.Key == text)
                {
                    return colorType.Value;
                }
            }
            return Color.White;
        }

        // adjusts stat bars
        private void AdjustBars()
        {
            // ratio, max value of 200, calculate a percentage of that
            BarHP.X2 = MaxStat(double.Parse(health));
            BarAttack.X2 = MaxStat(double.Parse(attack));
            BarDefense.X2 = MaxStat(double.Parse(defense));
            BarSpecialAttack.X2 = MaxStat(double.Parse(spAtk));
            BarSpecialDefense.X2 = MaxStat(double.Parse(spDef));
            BarSpeed.X2 = MaxStat(double.Parse(spd));
        }

        private double MaxStat(double stat)
        {
            if (stat > 200)
            {
                stat = 200;
            }
            return stat;
        }

        // adjusts margins for stat values
        private void AdjustMargins()
        {
            // ratio, max value of 120, calculate percentage of that
            LblHP.Margin = new Thickness(MaxStat(double.Parse(health)) + 10, 0, 0, 0);
            LblAttack.Margin = new Thickness(MaxStat(double.Parse(attack)) + 10, 0, 0, 0);
            LblDefense.Margin = new Thickness(MaxStat(double.Parse(defense)) + 10, 0, 0, 0);
            LblSpecialAttack.Margin = new Thickness(MaxStat(double.Parse(spAtk)) + 10, 0, 0, 0);
            LblSpecialDefense.Margin = new Thickness(MaxStat(double.Parse(spDef)) + 10, 0, 0, 0);
            LblSpeed.Margin = new Thickness(MaxStat(double.Parse(spd)) + 10, 0, 0, 0);
        }

        private void SetStatValues()
        {
            LblName.Text = pokeName;
            LblHP.Text = health;
            LblAttack.Text = attack;
            LblDefense.Text = defense;
            LblSpecialAttack.Text = spAtk;
            LblSpecialDefense.Text = spDef;
            LblSpeed.Text = spd;
        }

        private string ConvertToUpper(string text)
        {
            text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text);
            return text;
        }
    }
}