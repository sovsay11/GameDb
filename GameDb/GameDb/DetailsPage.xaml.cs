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
        // local variable for the pokemon name... might not even need this
        public string pokeName { get; set; }
        public DetailsPage(string name)
        {
            InitializeComponent();

            pokeName = name;

            //LblName.Text = pokeName;

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

                    LblName.Text = ConvertToUpper(poke.name);
                    LblHP.Text = poke.stats[0].base_stat.ToString();
                    LblAttack.Text = poke.stats[1].base_stat.ToString();
                    LblDefense.Text = poke.stats[2].base_stat.ToString();
                    LblSpecialAttack.Text = poke.stats[3].base_stat.ToString();
                    LblSpecialDefense.Text = poke.stats[4].base_stat.ToString();
                    LblSpeed.Text = poke.stats[5].base_stat.ToString();

                    if (poke.types.Count == 2)
                    {
                        LblType1.Text = ConvertToUpper(poke.types[0].type.name.ToString());
                        LblType2.Text = ConvertToUpper(poke.types[1].type.name.ToString());
                    }
                    else
                    {
                        LblType1.Text = ConvertToUpper(poke.types[0].type.name.ToString());
                        Grid.SetColumnSpan(LblType1, 4);
                    }
                    
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        private string ConvertToUpper(string text)
        {
            text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text);
            return text;
        }
    }
}