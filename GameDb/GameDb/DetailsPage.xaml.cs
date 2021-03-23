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
        string pokeName, health, attack, defense, spAtk, spDef, spd;

        public DetailsPage(string name)
        {
            InitializeComponent();

            //List<string> names = new List<string>();
            using (WebClient wc = new WebClient())
            {
                try
                {
                    // offset is starting location
                    // limit is the number of entries
                    string jsonData = wc.DownloadString($@"https://pokeapi.co/api/v2/pokemon/{name.ToLower()}/");

                    // method 1
                    //JObject pokeDetails = JObject.Parse(jsonData);

                    // method 2 of deserialization
                    PokeDetails poke = JsonConvert.DeserializeObject<PokeDetails>(jsonData);

                    ImgPokemon.Source = poke.sprites.front_default;

                    // assign to class variables
                    pokeName = ConvertToUpper(poke.name);
                    health = poke.stats[0].base_stat.ToString();
                    attack = poke.stats[1].base_stat.ToString();
                    defense = poke.stats[2].base_stat.ToString();
                    spAtk = poke.stats[3].base_stat.ToString();
                    spDef = poke.stats[4].base_stat.ToString();
                    spd = poke.stats[5].base_stat.ToString();

                    SetStatValues();

                    AdjustBars();

                    AdjustMargins();

                    if (poke.types.Count == 2)
                    {
                        LblType1.Text = ConvertToUpper(poke.types[0].type.name.ToString());
                        LblType2.Text = ConvertToUpper(poke.types[1].type.name.ToString());

                        // need a method here to alter the color of the type to match
                    }
                    else
                    {
                        LblType1.Text = ConvertToUpper(poke.types[0].type.name.ToString());
                        Grid.SetColumnSpan(LblType1, 4);

                        // need a method here to alter the color of the type to match
                    }

                }
                catch (Exception)
                {
                    throw;
                }
            }
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